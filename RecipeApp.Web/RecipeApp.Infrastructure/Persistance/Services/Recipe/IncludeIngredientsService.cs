using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Models;
using RecipeApp.Domain.Repositories.StoredIngredientRepository;
using RecipeApp.Domain.Services.Recipe.IncludeIngredientsService;

namespace RecipeApp.Infrastructure.Persistance.Services.Recipe
{
    public class IncludeIngredientsService : IIncludeIngredientsService
    {
        private const int defaultAcceptableMatchIngredientsPercentage = 80;
        private readonly IStoredIngredientRepository _storedIngredientRepository;

        public IncludeIngredientsService(IStoredIngredientRepository storedIngredientRepository)
        {
            _storedIngredientRepository = storedIngredientRepository;
        }

        public async Task<RecipesMatchingResult> SetIncludeIngredients(SetStoredIngredients setStoredIngredients)
        {
            var storedIngredients = await _storedIngredientRepository.GetUserStoredIngredientsWithIngredientsInfo(setStoredIngredients.UserId);
            List<Domain.Entities.Recipe> sortedMatchingRecipes = new();
            Dictionary<int, double> recipesMatchingPercentage = new();
            Dictionary<int, Domain.Entities.Recipe> matchingRecipes = new();
            double acceptableMatchIngredientsPercentage = setStoredIngredients.AcceptableMatchIngredientsPercentage ?? defaultAcceptableMatchIngredientsPercentage;
            bool considerIngredientsAmount = setStoredIngredients.ConsiderIngredientsAmount ?? true;

            if (storedIngredients != null && storedIngredients.Any())
            {
                foreach (var recipe in setStoredIngredients.FilteredRecipes)
                {
                    if (IncludeRecipeInResult(
                        recipe,
                        storedIngredients,
                        acceptableMatchIngredientsPercentage,
                        considerIngredientsAmount,
                        out double percentage))
                    {
                        recipesMatchingPercentage[recipe.Id] = percentage;
                        matchingRecipes[recipe.Id] = recipe;
                    }
                }

                foreach (var recipeEntry in recipesMatchingPercentage.OrderByDescending(r => r.Value))
                {
                    sortedMatchingRecipes.Add(matchingRecipes[recipeEntry.Key]);
                }

                return new RecipesMatchingResult
                {
                    FilteredRecipes = sortedMatchingRecipes,
                    RecipesMatchingPercentage = recipesMatchingPercentage
                };
            }

            return new RecipesMatchingResult
            {
                FilteredRecipes = setStoredIngredients.FilteredRecipes
            };
        }

        private static bool IncludeRecipeInResult(
            Domain.Entities.Recipe recipe,
            IEnumerable<StoredIngredient> storedIngredients,
            double acceptableMatchIngredientsPercentage,
            bool considerIngredientsAmount,
            out double matchingPercentage)
        {
            var storedIngredientIds = storedIngredients.Select(si => si.IngredientId);
            var matchingIngredientsPercentage = recipe.RecipeIngredients
                .Select(ri => ri.IngredientId).Intersect(storedIngredientIds).Count() * 100.0 / recipe.RecipeIngredients.Count;
            matchingPercentage = matchingIngredientsPercentage;

            if (matchingIngredientsPercentage < acceptableMatchIngredientsPercentage)
            {
                return false;
            }

            if (considerIngredientsAmount)
            {
                Dictionary<int, double> storedIngredientsAmountDictionary = storedIngredients
                    .DistinctBy(si => si.IngredientId)
                    .ToDictionary(k => k.IngredientId, v => v.Amount);
                foreach (var recipeIngredient in recipe.RecipeIngredients)
                {
                    if (storedIngredientsAmountDictionary.TryGetValue(recipeIngredient.IngredientId, out double amount)
                        && amount < recipeIngredient.Amount)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
