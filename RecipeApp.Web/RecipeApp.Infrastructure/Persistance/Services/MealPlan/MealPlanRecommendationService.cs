using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Clients.RecipeApiClient;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Models;
using RecipeApp.Domain.Repositories.ExternalUserRepository;
using RecipeApp.Domain.Repositories.ForbiddenNutrientRepository;
using RecipeApp.Domain.Repositories.RecipeRepository;
using RecipeApp.Domain.Services.MealPlan.MealPlanRecommendationService;
using RecipeApp.Infrastructure.Constants;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RecipeApp.Infrastructure.Persistance.Services.MealPlan
{
    public class MealPlanRecommendationService : IMealPlanRecommendationService
    {
        // TODO change cacheExpirationHours to 24 for release version
        private const int cacheExpirationHours = 1024;
        private const int defaultMealPlanDaysCount = 7;
        private readonly string _recipeNutrientsCachePath = Path.Combine(
            @$"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}",
               @"RecipeApp\Cache");
        private readonly IRecipeRepository _recipeRepository;
        private readonly IForbiddenNutrientRepository _forbiddenNutrientRepository;
        private readonly IExternalUserRepository _externalUserRepository;
        private readonly IRecipeApiClient _recipeApiClient;
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger _logger;
        private static readonly SemaphoreSlim getRecipesSemaphore = new(1, 1);

        public MealPlanRecommendationService(
            IRecipeRepository recipeRepository,
            IForbiddenNutrientRepository forbiddenNutrientRepository,
            IExternalUserRepository externalUserRepository,
            IRecipeApiClient recipeApiClient,
            IMemoryCache memoryCache,
            ILoggerFactory loggerFactory)
        {
            _recipeRepository = recipeRepository;
            _forbiddenNutrientRepository = forbiddenNutrientRepository;
            _externalUserRepository = externalUserRepository;
            _recipeApiClient = recipeApiClient;
            _memoryCache = memoryCache;
            _logger = loggerFactory?.CreateLogger(nameof(MealPlanRecommendationService));
        }

        public async Task<Domain.Entities.MealPlan> GetRecommendedMealPlan(int appUserId, int externalUserId)
        {
            ExternalUser externalUser = await _externalUserRepository.Get(externalUserId);
            if (externalUser == null)
            {
                return null;
            }

            IEnumerable<Domain.Entities.Recipe> recipes = await GetCachedRecipes();
            IEnumerable<ForbiddenNutrient> forbiddenNutrients = await _forbiddenNutrientRepository.GetUserForbiddenNutrients(externalUserId);
            IEnumerable<RecipeNutrients> recipeNutrition = await GetRecipesNutrition(recipes);

            List<MealPlanNutrients> mealPlans = new();

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

            Domain.Entities.MealPlan resultMealPlan = new()
            {
                AppUserId = appUserId,
                MealPlanDate = DateTime.Now,
                MealPlanDays = GetMealPlanDays(filteredMealPlans, recipes),
            };

            return resultMealPlan;
        }

        private static List<MealPlanDay> GetMealPlanDays(
            List<MealPlanNutrients> mealPlanNutrients,
            IEnumerable<Domain.Entities.Recipe> recipes)
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
            IEnumerable<Domain.Entities.Recipe> recipes)
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

        private async Task<IEnumerable<RecipeNutrients>> GetRecipesNutrition(IEnumerable<Domain.Entities.Recipe> recipes)
        {
            var recipesNutritionCachePath = Path.Combine(_recipeNutrientsCachePath, $"RecipesNutrients-{DateTime.Now:yyyy-MM}.json");
            if (!Directory.Exists(_recipeNutrientsCachePath))
            {
                Directory.CreateDirectory(_recipeNutrientsCachePath);
            }

            if (File.Exists(recipesNutritionCachePath))
            {
                FileInfo fileInfo = new(recipesNutritionCachePath);
                var expirationTimeSpan = DateTime.Now - fileInfo.LastWriteTime;
                if (expirationTimeSpan.TotalHours <= cacheExpirationHours)
                {
                    var content = await File.ReadAllTextAsync(recipesNutritionCachePath);
                    return JsonSerializer.Deserialize<IEnumerable<RecipeNutrients>>(content);
                }
            }

            List<RecipeNutrients> recipesNutrients = new();
            foreach (var recipe in recipes)
            {
                RecipeNutrients recipeNutrients = await GetRecipeNutrition(recipe);
                recipesNutrients.Add(recipeNutrients);
            }

            var jsonSerializationSettings = JsonSerializer.Serialize(recipesNutrients, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            });
            await File.WriteAllTextAsync(recipesNutritionCachePath, jsonSerializationSettings);
            return recipesNutrients;
        }

        private async Task<RecipeNutrients> GetRecipeNutrition(Domain.Entities.Recipe recipe)
        {
            List<RecipeNutrient> nutrients = new();
            RecipeNutrients recipeNutrients = new() { Recipe = recipe, Nutrients = nutrients };
            double recipeWeight = 0;
            foreach (var ingredient in recipe.RecipeIngredients)
            {
                double ingredientAmountGrams = await CalculateIngredientAmountInGrams(ingredient);
                recipeWeight += ingredientAmountGrams;
                foreach (var nutrientIngredient in ingredient.Ingredient.NutrientIngredients)
                {
                    var nutrientUnit = nutrientIngredient.Nutrient.Unit;
                    RecipeNutrient existingRecipeNutrient = nutrients.FirstOrDefault(n => n.Id == nutrientIngredient.Nutrient.Id);
                    RecipeNutrient recipeNutrient = existingRecipeNutrient ?? new()
                    {
                        Id = nutrientIngredient.Nutrient.Id,
                        Name = nutrientIngredient.Nutrient.Name,
                        Unit = nutrientUnit
                    };

                    recipeNutrient.Amount += nutrientIngredient.Amount * ingredientAmountGrams / 100;
                    recipeNutrient.PercentOfDailyNeeds = recipeNutrient.Amount * nutrientIngredient.PercentOfDailyNeeds / nutrientIngredient.Amount;

                    if (existingRecipeNutrient == null)
                    {
                        nutrients.Add(recipeNutrient);
                    }
                }
            }

            foreach (var nutrient in nutrients)
            {
                var nutrientAmountPerPortion = nutrient.Amount / recipe.Servings;
                nutrient.PercentOfDailyNeeds = nutrientAmountPerPortion * nutrient.PercentOfDailyNeeds / nutrient.Amount;
            }

            return recipeNutrients;
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

        private async Task<double> CalculateIngredientAmountInGrams(RecipeIngredient recipeIngredient)
        {
            switch (recipeIngredient.Ingredient.Unit)
            {
                case Unit.Grams:
                    return recipeIngredient.Amount;
                case Unit.Kilograms:
                    return recipeIngredient.Amount * 1000;
                case Unit.Milligrams:
                    return recipeIngredient.Amount / 1000;
                case Unit.Micrograms:
                    return recipeIngredient.Amount / 1000_000;
                default:
                    var conversionResult = await _recipeApiClient.Convert(
                        new IngredientConversionParameters
                        {
                            IngredientName = recipeIngredient.Ingredient.Name,
                            SourceAmount = recipeIngredient.Amount,
                            SourceUnit = recipeIngredient.Ingredient.Unit == Unit.Milliliters ? "ml" : "l",
                            TargetUnit = "g"
                        });

                    if (conversionResult == null || conversionResult.TargetAmount == null)
                    {
                        return recipeIngredient.Ingredient.Unit == Unit.Milliliters ?
                            recipeIngredient.Amount : recipeIngredient.Amount * 1000;
                    }

                    return conversionResult.TargetAmount.Value;
            }
        }

        private async Task<IEnumerable<Domain.Entities.Recipe>> GetCachedRecipes()
        {
            bool isRecipesAvaiable = _memoryCache.TryGetValue(CacheKeys.Recipes, out IEnumerable<Domain.Entities.Recipe> recipes);
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
                    AbsoluteExpiration = DateTime.Now.AddHours(cacheExpirationHours),
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
