using RecipeApp.Domain.Models;

namespace RecipeApp.Domain.Clients.RecipeApiClient
{
    public interface IRecipeApiClient
    {
        Task<IngredientAmountConversion> Convert(IngredientConversionParameters ingredientConversionParameters);
    }
}
