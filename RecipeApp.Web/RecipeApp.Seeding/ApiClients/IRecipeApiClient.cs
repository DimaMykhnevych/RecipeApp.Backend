using RecipeApp.Seeding.ApiModels;

namespace RecipeApp.Seeding.ApiClients
{
    internal interface IRecipeApiClient
    {
        Task<RecipeDto> GetRecipeInfo(int id);
        Task<IngredientDto> GetIngredientInfo(int id, double amount, string unit);
        Task<ConvertAmountDto> Convert(string ingredientName, double sourceAmount, string sourceUnit, string targetUnit);
    }
}
