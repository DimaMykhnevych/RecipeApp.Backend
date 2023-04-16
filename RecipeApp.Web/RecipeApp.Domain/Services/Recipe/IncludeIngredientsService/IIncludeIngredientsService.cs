using RecipeApp.Domain.Models;

namespace RecipeApp.Domain.Services.Recipe.IncludeIngredientsService
{
    public interface IIncludeIngredientsService
    {
        Task<RecipesMatchingResult> SetIncludeIngredients(SetStoredIngredients setStoredIngredients);
    }
}
