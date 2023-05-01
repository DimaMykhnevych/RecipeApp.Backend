using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Clients.RecipeApiClient;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Models;
using RecipeApp.Domain.Repositories.NutrientRecipeRepository;
using RecipeApp.Domain.Repositories.RecipeRepository;
using RecipeApp.Domain.Services.RecipeN.AddRecipeNutritionService;

namespace RecipeApp.Infrastructure.Persistance.Services.RecipeN
{
    public class AddRecipeNutritionService : IAddRecipeNutritionService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly INutrientRecipeRepository _nutrientRecipeRepository;
        private readonly IRecipeApiClient _recipeApiClient;
        private readonly ILogger _logger;

        public AddRecipeNutritionService(
            IRecipeRepository recipeRepository,
            INutrientRecipeRepository nutrientRecipeRepository,
            IRecipeApiClient recipeApiClient,
            ILoggerFactory loggerFactory)
        {
            _recipeRepository = recipeRepository;
            _nutrientRecipeRepository = nutrientRecipeRepository;
            _recipeApiClient = recipeApiClient;
            _logger = loggerFactory?.CreateLogger(nameof(AddRecipeNutritionService));
        }

        public async Task AddRecipeNutrition(int? recipeId)
        {
            _logger.LogInformation("Adding recipe nutrition. Recipe Id: {RecipeId}", recipeId == null ? "empty" : recipeId.Value);
            List<Recipe> recipes = new();
            if (recipeId != null)
            {
                var recipe = await _recipeRepository.GetRecipeWithNutritionInfo(recipeId.Value);
                if (recipe is null)
                {
                    return;
                }
                recipes.Add(recipe);
            }
            else
            {
                recipes = (await _recipeRepository.GetRecipesWithNutritionInfo()).ToList();
            }

            IEnumerable<RecipeNutrients> recipeNutrients = await GetRecipesNutrition(recipes);
            foreach (var recipeNutrient in recipeNutrients)
            {
                foreach (var nutrient in recipeNutrient.Nutrients)
                {
                    await _nutrientRecipeRepository.Insert(new()
                    {
                        Amount = nutrient.Amount,
                        PercentOfDailyNeeds = nutrient.PercentOfDailyNeeds,
                        NutrientId = nutrient.Id,
                        RecipeId = recipeNutrient.Recipe.Id
                    });
                }
            }

            await _nutrientRecipeRepository.Save();
        }

        private async Task<IEnumerable<RecipeNutrients>> GetRecipesNutrition(IEnumerable<Recipe> recipes)
        {
            List<RecipeNutrients> recipesNutrients = new();
            foreach (var recipe in recipes)
            {
                bool nutrientExists = await _nutrientRecipeRepository.NutrientsForRecipeExist(recipe.Id);
                if (!nutrientExists)
                {
                    RecipeNutrients recipeNutrients = await GetRecipeNutrition(recipe);
                    recipesNutrients.Add(recipeNutrients);
                }
            }
            return recipesNutrients;
        }

        private async Task<RecipeNutrients> GetRecipeNutrition(Recipe recipe)
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
    }
}
