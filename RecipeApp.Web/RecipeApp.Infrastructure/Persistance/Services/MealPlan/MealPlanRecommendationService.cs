using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Models;
using RecipeApp.Domain.Repositories.ExternalUserRepository;
using RecipeApp.Domain.Repositories.ForbiddenIngredientRepository;
using RecipeApp.Domain.Repositories.ForbiddenNutrientRepository;
using RecipeApp.Domain.Repositories.NutrientRecipeRepository;
using RecipeApp.Domain.Repositories.RecipeRepository;
using RecipeApp.Domain.Services.MealPlanN.MealPlanRecommendationService;
using RecipeApp.Domain.Services.RecipeN.IncludeIngredientsService;
using RecipeApp.Infrastructure.Constants;
using System.Diagnostics;

namespace RecipeApp.Infrastructure.Persistance.Services.MealPlanN
{
    public class MealPlanRecommendationService : IMealPlanRecommendationService
    {
        private const int cacheExpirationMinutes = 20;
        private const int defaultMealPlanDaysCount = 7;
        private const int defaultMandatoryDishesPerDayCount = 3;
        private const int macroNutrientsScatterPercentage = 10;
        private const int defaultMealPlanGenerationSecondsLimit = 100;
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
            var watch = Stopwatch.StartNew();
            var breakRequired = false;
            foreach (var breakfast in recipes
                .Where(r => r.DishType == DishType.Breakfast))
            {
                if (breakRequired) break;
                var breakfastNutrients = recipeNutrition.First(rn => rn.Recipe.Id == breakfast.Id);

                foreach (var lunch in recipes
                    .Where(r => r.DishType == DishType.Lunch))
                {
                    if (breakRequired) break;
                    var lunchNutrients = recipeNutrition.First(rn => rn.Recipe.Id == lunch.Id);

                    foreach (var dinner in recipes
                        .Where(r => r.DishType == DishType.Dinner))
                    {
                        if (breakRequired) break;
                        var dinnerNutrients = recipeNutrition.First(rn => rn.Recipe.Id == dinner.Id);
                        MealPlanNutrients mealPlan = new()
                        {
                            RecipeIds = new int[] { breakfast.Id, lunch.Id, dinner.Id },
                            Nutrients = MergeNutrients(breakfastNutrients, lunchNutrients, dinnerNutrients),
                            Calories = breakfast.Calories + lunch.Calories + dinner.Calories,
                            Carbs = breakfast.Carbs + lunch.Carbs + dinner.Carbs,
                            Fat = breakfast.Fat + lunch.Fat + dinner.Fat,
                            Protein = breakfast.Protein + lunch.Protein + dinner.Protein,
                        };
                        mealPlans.Add(mealPlan);

                        var elapsedSeconds = watch.ElapsedMilliseconds / 1000.0;
                        var mealPlanGenerationSecondsLimit = mealPlanRecommendationParameters.MealPlanGenerationSecondsLimit ?? defaultMealPlanGenerationSecondsLimit;
                        if (elapsedSeconds >= mealPlanGenerationSecondsLimit)
                        {
                            _logger.LogWarning("Terminating dishes combination as maximum time limit was reached." +
                                " Combinations count: {CombinationsCount}. Elapsed seconds: {ElapsedSeconds}", mealPlans.Count, elapsedSeconds);
                            breakRequired = true;
                            watch.Stop();
                            break;
                        }
                    }
                }
            }

            _logger.LogDebug("Made {CombinationsCount} possible combinations. Elapsed seconds: {ElapsedSeconds}", mealPlans.Count, watch.ElapsedMilliseconds / 1000.0);
            watch.Stop();

            _logger.LogDebug("Filtering meal plans by user's macro nutrients limitations (calories, protein, fat, carbs)");
            mealPlans = FilterMealPlansByMacroNutrients(mealPlans, mealPlanRecommendationParameters);

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

            TryAddSnacks(resultMealPlan, recipeNutrition, forbiddenNutrients, mealPlanRecommendationParameters);
            return resultMealPlan;
        }

        private void TryAddSnacks(
            MealPlan baseMealPlan,
            IEnumerable<RecipeNutrients> recipeNutrients,
            IEnumerable<ForbiddenNutrient> forbiddenNutrients,
            MealPlanRecommendationParameters mealPlanRecommendationParameters)
        {
            try
            {
                var daysAmount = baseMealPlan.MealPlanDays.Count / defaultMandatoryDishesPerDayCount;
                var snacks = recipeNutrients.Where(r => r.Recipe.DishType == DishType.Snack);

                Random rng = new();
                var mealPlanDaySnacks = new List<MealPlanDay>();
                for (int i = 0; i < daysAmount; i++)
                {
                    var shuffledSnacks = snacks.OrderBy(s => rng.Next());
                    Recipe[] recipesForDay =
                    {
                        baseMealPlan.MealPlanDays.ElementAt(i * defaultMandatoryDishesPerDayCount).Recipe,
                        baseMealPlan.MealPlanDays.ElementAt(i * defaultMandatoryDishesPerDayCount + 1).Recipe,
                        baseMealPlan.MealPlanDays.ElementAt(i * defaultMandatoryDishesPerDayCount + 2).Recipe
                    };

                    var breakfast = recipeNutrients.First(rn => recipesForDay[0].Id == rn.Recipe.Id);
                    var lunch = recipeNutrients.First(rn => recipesForDay[1].Id == rn.Recipe.Id);
                    var dinner = recipeNutrients.First(rn => recipesForDay[2].Id == rn.Recipe.Id);

                    foreach (var snack in shuffledSnacks)
                    {
                        RecipeNutrients[] recipeNutrientsForDay = { breakfast, lunch, dinner, snack };
                        var totalNutrients = MergeNutrients(recipeNutrientsForDay);
                        bool includeSnackByNutrients = true;
                        foreach (var forbiddenNutrient in forbiddenNutrients)
                        {
                            var mealPlanNutrient = totalNutrients.FirstOrDefault(n => n.Id == forbiddenNutrient.NutrientId);
                            if (mealPlanNutrient != null && mealPlanNutrient.PercentOfDailyNeeds >= forbiddenNutrient.RequiredPercentageOfDailyNeeds)
                            {
                                includeSnackByNutrients = false;
                                break;
                            }
                        }

                        if (includeSnackByNutrients)
                        {
                            // checking by macro nutrients
                            var resultMealPlan = FilterMealPlansByMacroNutrients(
                                new List<MealPlanNutrients>()
                                {
                                    new()
                                    {
                                        Calories = breakfast.Recipe.Calories + lunch.Recipe.Calories + dinner.Recipe.Calories + snack.Recipe.Calories,
                                        Carbs = breakfast.Recipe.Carbs + lunch.Recipe.Carbs + dinner.Recipe.Carbs + snack.Recipe.Carbs,
                                        Fat = breakfast.Recipe.Fat + lunch.Recipe.Fat + dinner.Recipe.Fat + snack.Recipe.Fat,
                                        Protein = breakfast.Recipe.Protein + lunch.Recipe.Protein + dinner.Recipe.Protein + snack.Recipe.Protein,
                                    }
                                }, mealPlanRecommendationParameters);

                            if (resultMealPlan.Any())
                            {
                                var currentDayLastDish = baseMealPlan.MealPlanDays.ElementAt(i * defaultMandatoryDishesPerDayCount + 2);
                                MealPlanDay mealPlanDay = new()
                                {
                                    RecipeId = snack.Recipe.Id,
                                    Servings = snack.Recipe.Servings,
                                    Recipe = snack.Recipe,
                                    Ingestion = new()
                                    {
                                        Order = defaultMandatoryDishesPerDayCount + 1,
                                        DishType = DishType.Snack,
                                        DayOfWeek = currentDayLastDish.Ingestion.DayOfWeek
                                    }
                                };

                                mealPlanDaySnacks.Add(mealPlanDay);
                                break;
                            }
                        }
                    }
                }

                for (int i = 0; i < mealPlanDaySnacks.Count; i++)
                {
                    baseMealPlan.MealPlanDays.Add(mealPlanDaySnacks[i]);
                }

                baseMealPlan.MealPlanDays = baseMealPlan.MealPlanDays
                    .OrderBy(m => m.Ingestion.DayOfWeek)
                    .ThenBy(m => m.Ingestion.Order)
                    .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred when trying to add snacks to meal plan");
            }
        }

        private static List<MealPlanNutrients> FilterMealPlansByMacroNutrients(
            List<MealPlanNutrients> mealPlans,
            MealPlanRecommendationParameters mealPlanRecommendationParameters)
        {
            List<MealPlanNutrients> filteredMealPlans = mealPlans;
            if (mealPlanRecommendationParameters.Calories != null)
            {
                var allowableCaloriesDispersion = mealPlanRecommendationParameters.Calories / macroNutrientsScatterPercentage;
                filteredMealPlans = filteredMealPlans
                    .Where(p => p.Calories >= mealPlanRecommendationParameters.Calories - allowableCaloriesDispersion &&
                           p.Calories <= mealPlanRecommendationParameters.Calories + allowableCaloriesDispersion)
                    .ToList();
            }

            if (mealPlanRecommendationParameters.Protein != null)
            {
                var allowableProteinDispersion = mealPlanRecommendationParameters.Protein / macroNutrientsScatterPercentage;
                filteredMealPlans = filteredMealPlans
                    .Where(p => p.Protein >= mealPlanRecommendationParameters.Protein - allowableProteinDispersion &&
                           p.Protein <= mealPlanRecommendationParameters.Protein + allowableProteinDispersion)
                    .ToList();
            }

            if (mealPlanRecommendationParameters.Fat != null)
            {
                var allowableFatDispersion = mealPlanRecommendationParameters.Fat / macroNutrientsScatterPercentage;
                filteredMealPlans = filteredMealPlans
                    .Where(p => p.Protein >= mealPlanRecommendationParameters.Fat - allowableFatDispersion &&
                           p.Protein <= mealPlanRecommendationParameters.Fat + allowableFatDispersion)
                    .ToList();
            }

            if (mealPlanRecommendationParameters.Carbs != null)
            {
                var allowableCarbsDispersion = mealPlanRecommendationParameters.Carbs / macroNutrientsScatterPercentage;
                filteredMealPlans = filteredMealPlans
                    .Where(p => p.Protein >= mealPlanRecommendationParameters.Carbs - allowableCarbsDispersion &&
                           p.Protein <= mealPlanRecommendationParameters.Carbs + allowableCarbsDispersion)
                    .ToList();
            }

            return filteredMealPlans;
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
