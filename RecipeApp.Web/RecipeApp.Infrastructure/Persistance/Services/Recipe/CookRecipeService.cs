using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Repositories.RecipeRepository;
using RecipeApp.Domain.Repositories.StoredIngredientRepository;
using RecipeApp.Domain.Services.RecipeN.CookRecipeService;

namespace RecipeApp.Infrastructure.Persistance.Services.RecipeN
{
    public class CookRecipeService : ICookRecipeService
    {
        private readonly IStoredIngredientRepository _storedIngredientRepository;
        private readonly IRecipeRepository _recipeRepository;
        private readonly ILogger _logger;

        public CookRecipeService(
            IStoredIngredientRepository storedIngredientRepository,
            IRecipeRepository recipeRepository,
            ILoggerFactory loggerFactory)
        {
            _storedIngredientRepository = storedIngredientRepository;
            _recipeRepository = recipeRepository;
            _logger = loggerFactory?.CreateLogger(nameof(CookRecipeService));
        }

        public async Task<bool> CookRecipeAsync(int appUserId, int recipeId)
        {
            _logger.LogInformation("User {UserId} is cooking recipe {RecipeId}", appUserId, recipeId);
            try
            {
                IEnumerable<StoredIngredient> userStoredIngredients =
                    await _storedIngredientRepository.GetUserStoredIngredientsWithIngredientsInfo(appUserId);
                Recipe recipeToCook = await _recipeRepository.GetRecipeWithIngredientsInfo(recipeId);
                foreach (var storedIngredient in userStoredIngredients)
                {
                    var currentStoredIngredientInRecipe = recipeToCook.RecipeIngredients
                        .FirstOrDefault(ri => ri.IngredientId == storedIngredient.IngredientId);
                    if (currentStoredIngredientInRecipe != null)
                    {
                        storedIngredient.Amount -= currentStoredIngredientInRecipe.Amount;
                        if (storedIngredient.Amount <= 0)
                        {
                            _logger.LogInformation("Ingredient {StoredIngredientId} will be deleted from stored ingredients", storedIngredient.IngredientId);
                            _storedIngredientRepository.Delete(storedIngredient);
                        }
                        else
                        {
                            storedIngredient.LastModifiedDate = DateTime.Now;
                            await _storedIngredientRepository.Update(storedIngredient);
                        }
                    }
                }

                await _storedIngredientRepository.Save();
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred during updating current stored ingredients amount." +
                    " AppUserId: {AppUserId}, RecipeId: {RecipeId}", appUserId, recipeId);
                return false;
            }
        }
    }
}
