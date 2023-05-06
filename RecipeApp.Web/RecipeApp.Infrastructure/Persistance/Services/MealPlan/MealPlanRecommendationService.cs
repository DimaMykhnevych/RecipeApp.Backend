using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Models;
using RecipeApp.Domain.Repositories.ExternalUserRepository;
using RecipeApp.Domain.Repositories.ForbiddenIngredientRepository;
using RecipeApp.Domain.Repositories.ForbiddenNutrientRepository;
using RecipeApp.Domain.Repositories.NutrientRecipeRepository;
using RecipeApp.Domain.Repositories.RecipeRepository;
using RecipeApp.Domain.Repositories.StoredIngredientRepository;
using RecipeApp.Domain.Services.MealPlanN.MealPlanRecommendationService;
using RecipeApp.Domain.Services.RecipeN.IncludeIngredientsService;
using RecipeApp.Infrastructure.Constants;

namespace RecipeApp.Infrastructure.Persistance.Services.MealPlanN
{
    public class MealPlanRecommendationService : IMealPlanRecommendationService
    {
        private const int cacheExpirationMinutes = 20;
        private const int defaultMealPlanDaysCount = 7;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IForbiddenNutrientRepository _forbiddenNutrientRepository;
        private readonly IForbiddenIngredientRepository _forbiddenIngredientRepository;
        private readonly IExternalUserRepository _externalUserRepository;
        private readonly INutrientRecipeRepository _nutrientRecipeRepository;
        private readonly IIncludeIngredientsService _includeIngredientsService;
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger _logger;
        private static readonly SemaphoreSlim getRecipesSemaphore = new(1, 1);

        public MealPlanRecommendationService(
            IRecipeRepository recipeRepository,
            IForbiddenNutrientRepository forbiddenNutrientRepository,
            IForbiddenIngredientRepository forbiddenIngredientRepository,
            IExternalUserRepository externalUserRepository,
            INutrientRecipeRepository nutrientRecipeRepository,
            IIncludeIngredientsService includeIngredientsService,
            IMemoryCache memoryCache,
            ILoggerFactory loggerFactory)
        {
            _recipeRepository = recipeRepository;
            _forbiddenNutrientRepository = forbiddenNutrientRepository;
            _forbiddenIngredientRepository = forbiddenIngredientRepository;
            _externalUserRepository = externalUserRepository;
            _nutrientRecipeRepository = nutrientRecipeRepository;
            _includeIngredientsService = includeIngredientsService;
            _memoryCache = memoryCache;
            _logger = loggerFactory?.CreateLogger(nameof(MealPlanRecommendationService));
        }

        public async Task<MealPlan> GetRecommendedMealPlan(MealPlanRecommendationParameters mealPlanRecommendationParameters)
        {
            _logger.LogInformation("Getting meal plan recommendation for user with External Id: {ExternalUserId}", mealPlanRecommendationParameters.ExternalUserId);

            ExternalUser externalUser = await _externalUserRepository.Get(mealPlanRecommendationParameters.ExternalUserId);
            if (externalUser == null)
            {
                return null;
            }

            // getting cached recieps
            IEnumerable<Recipe> recipes = await GetCachedRecipes();

            // excluding recipes with forbidden ingredeines
            IEnumerable<ForbiddenIngredient> forbiddenIngredients = await _forbiddenIngredientRepository.GetUserForbiddenIngredients(mealPlanRecommendationParameters.ExternalUserId);
            var forbiddenIngredientIds = forbiddenIngredients.Select(fi => fi.IngredientId);
            recipes = recipes.Where(r => r.RecipeIngredients.All(ri => !forbiddenIngredientIds.Contains(ri.IngredientId)));

            // considering stored ingredients
            var recipesWithStoredIngredients = await _includeIngredientsService.SetIncludeIngredients(new()
            {
                UserId = mealPlanRecommendationParameters.AppUserId,
                FilteredRecipes = recipes,
                AcceptableMatchIngredientsPercentage = mealPlanRecommendationParameters.AcceptableMatchIngredientsPercentage,
                ConsiderIngredientsAmount = mealPlanRecommendationParameters.ConsiderIngredientsAmount
            });

            recipes = recipesWithStoredIngredients.FilteredRecipes;

            IEnumerable<ForbiddenNutrient> forbiddenNutrients = await _forbiddenNutrientRepository.GetUserForbiddenNutrients(mealPlanRecommendationParameters.ExternalUserId);
            IEnumerable<NutrientRecipe> recipeNutrients = await _nutrientRecipeRepository.GetRecipeNutrients();

            IEnumerable<RecipeNutrients> recipeNutrition = GetRecipesNutrition(recipes, recipeNutrients);

            List<MealPlanNutrients> mealPlans = new();

            _logger.LogDebug("Making all possible combinations of dishes");
            foreach (var breakfast in recipes
                .Where(r => r.DishType == DishType.Breakfast || r.DishType == DishType.Any))
            {
                var breakfastNutrients = recipeNutrition.First(rn => rn.Recipe.Id == breakfast.Id);

                foreach (var lunch in recipes
                    .Where(r => r.DishType == DishType.Lunch || r.DishType == DishType.Snack))
                {
                    var lunchNutrients = recipeNutrition.First(rn => rn.Recipe.Id == lunch.Id);

                    foreach (var dinner in recipes
                        .Where(r => r.DishType == DishType.Dinner || r.DishType == DishType.Snack))
                    {
                        var dinnerNutrients = recipeNutrition.First(rn => rn.Recipe.Id == dinner.Id);
                        if (lunch.Id != dinner.Id)
                        {
                            MealPlanNutrients mealPlan = new()
                            {
                                RecipeIds = new int[] { breakfast.Id, lunch.Id, dinner.Id },
                                Nutrients = MergeNutrients(breakfastNutrients, lunchNutrients, dinnerNutrients)
                            };
                            mealPlans.Add(mealPlan);
                        }
                    }
                }
            }

            _logger.LogDebug("Filtering meal plans by user's nutrients limitations");
            List<MealPlanNutrients> filteredMealPlans = new();

            foreach (var plan in mealPlans)
            {
                bool includeMealPlan = true;
                foreach (var forbiddenNutrient in forbiddenNutrients)
                {
                    var mealPlanNutrient = plan.Nutrients.FirstOrDefault(n => n.Id == forbiddenNutrient.NutrientId);
                    if (mealPlanNutrient != null && mealPlanNutrient.PercentOfDailyNeeds >= forbiddenNutrient.RequiredPercentageOfDailyNeeds)
                    {
                        includeMealPlan = false;
                        break;
                    }
                }

                if (includeMealPlan)
                {
                    filteredMealPlans.Add(plan);
                }
            }

            _logger.LogDebug("Building meal plan");
            MealPlan resultMealPlan = new()
            {
                AppUserId = mealPlanRecommendationParameters.AppUserId,
                MealPlanDate = DateTime.Now,
                MealPlanDays = GetMealPlanDays(filteredMealPlans, recipes),
            };

            return resultMealPlan;
        }

        private static List<MealPlanDay> GetMealPlanDays(
            List<MealPlanNutrients> mealPlanNutrients,
            IEnumerable<Recipe> recipes)
        {
            if (mealPlanNutrients.Count <= defaultMealPlanDaysCount)
            {
                return BuildMealPlanDays(mealPlanNutrients, recipes);
            }

            var plansDistributionLength = mealPlanNutrients.Count / defaultMealPlanDaysCount;
            List<MealPlanNutrients> selectedMealPlans = new();
            Random rnd = new();
            for (int i = 0; i < defaultMealPlanDaysCount; i++)
            {
                int mealPlanIndex = rnd.Next(i * plansDistributionLength, i * plansDistributionLength + plansDistributionLength);
                if (i == defaultMealPlanDaysCount - 1)
                {
                    mealPlanIndex = rnd.Next(i * plansDistributionLength, mealPlanNutrients.Count);
                }
                selectedMealPlans.Add(mealPlanNutrients[mealPlanIndex]);
            }

            return BuildMealPlanDays(selectedMealPlans, recipes);
        }

        private static List<MealPlanDay> BuildMealPlanDays(
            List<MealPlanNutrients> mealPlanNutrients,
            IEnumerable<Recipe> recipes)
        {
            var mealPlanDays = new List<MealPlanDay>();
            var weekDays = new List<DayOfWeek>()
            {
                DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday,
                DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday,
                DayOfWeek.Sunday
            };
            for (int i = 0; i < mealPlanNutrients.Count; i++)
            {
                var mealPlan = mealPlanNutrients[i];
                var mealPlanRecipes = mealPlan.RecipeIds.Select(id => recipes.First(r => r.Id == id)).ToList();
                for (int j = 0; j < mealPlanRecipes.Count; j++)
                {
                    var recipe = mealPlanRecipes[j];
                    MealPlanDay mealPlanDay = new()
                    {
                        RecipeId = recipe.Id,
                        Servings = recipe.Servings,
                        Recipe = recipe,
                        Ingestion = new()
                        {
                            Order = j + 1,
                            DishType = recipe.DishType,
                            DayOfWeek = weekDays[i]
                        }
                    };

                    mealPlanDays.Add(mealPlanDay);
                }
            }

            return mealPlanDays;
        }

        private static IEnumerable<RecipeNutrients> GetRecipesNutrition(
            IEnumerable<Recipe> recipes,
            IEnumerable<NutrientRecipe> storedRecipeNutrients)
        {
            List<RecipeNutrients> recipesNutrients = new();
            foreach (var recipe in recipes)
            {
                RecipeNutrients recipeNutrientsModel = new()
                {
                    Recipe = recipe,
                };
                var currentRecipeStoredNutrients = storedRecipeNutrients.Where(rn => rn.RecipeId == recipe.Id);
                var currentRecipeNutrientsModel = currentRecipeStoredNutrients
                    .Select(rn => new RecipeNutrient
                    {
                        Id = rn.NutrientId,
                        Name = rn.Nutrient.Name,
                        Unit = rn.Nutrient.Unit,
                        Amount = rn.Amount,
                        PercentOfDailyNeeds = rn.PercentOfDailyNeeds,
                    });
                recipeNutrientsModel.Nutrients = currentRecipeNutrientsModel;

                recipesNutrients.Add(recipeNutrientsModel);
            }

            return recipesNutrients;
        }

        private static List<RecipeNutrient> MergeNutrients(params RecipeNutrients[] recipeNutrients)
        {
            List<RecipeNutrient> totalNutrients = new();
            foreach (var nutrient in recipeNutrients.SelectMany(r => r.Nutrients))
            {
                RecipeNutrient recipeNutrient = nutrient.ShallowCopy();
                var existingNutrient = totalNutrients.FirstOrDefault(n => n.Id == nutrient.Id);
                if (existingNutrient == null)
                {
                    totalNutrients.Add(recipeNutrient);
                    continue;
                }

                existingNutrient.Amount += nutrient.Amount;
                existingNutrient.PercentOfDailyNeeds = existingNutrient.Amount * nutrient.PercentOfDailyNeeds / nutrient.Amount;
            }

            return totalNutrients;
        }

        private async Task<IEnumerable<Recipe>> GetCachedRecipes()
        {
            bool isRecipesAvaiable = _memoryCache.TryGetValue(CacheKeys.Recipes, out IEnumerable<Recipe> recipes);
            if (isRecipesAvaiable)
            {
                return recipes;
            }

            try
            {
                await getRecipesSemaphore.WaitAsync();
                isRecipesAvaiable = _memoryCache.TryGetValue(CacheKeys.Recipes, out recipes);
                if (isRecipesAvaiable)
                {
                    return recipes;
                }

                recipes = await _recipeRepository.GetRecipesWithNutritionInfo();
                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(cacheExpirationMinutes),
                    Size = 1024,
                };
                _memoryCache.Set(CacheKeys.Recipes, recipes, cacheEntryOptions);
            }
            catch
            {
                throw;
            }
            finally
            {
                getRecipesSemaphore.Release();
            }
            return recipes;
        }
    }
}
