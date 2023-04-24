using RecipeApp.Domain.Models;

namespace RecipeApp.Domain.Services.RecipeN.IncludeIngredientsService
{
    public interface IIncludeIngredientsService
    {
        Task<RecipesMatchingResult> SetIncludeIngredients(SetStoredIngredients setStoredIngredients);
    }
}
