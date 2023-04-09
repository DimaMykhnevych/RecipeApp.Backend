using Newtonsoft.Json;
using RecipeApp.Seeding.ApiClients;
using RecipeApp.Seeding.ApiModels;

namespace RecipeApp.Seeding.Mocks
{
    internal class RecipeApiClientMock : IRecipeApiClient
    {
        public Task<ConvertAmountDto> Convert(string ingredientName, double sourceAmount, string sourceUnit, string targetUnit)
        {
            var convertion = JsonConvert.DeserializeObject<ConvertAmountDto>(RecipeApiClientTestData.ConvertUnitResponse);
            return Task.FromResult(convertion);
        }

        public Task<IngredientDto> GetIngredientInfo(int id, double amount, string unit)
        {
            var ingredient = JsonConvert.DeserializeObject<IngredientDto>(RecipeApiClientTestData.IngredientResponse);
            return Task.FromResult(ingredient);
        }

        public Task<RecipeDto> GetRecipeInfo(int id)
        {
            var recipe = JsonConvert.DeserializeObject<RecipeDto>(RecipeApiClientTestData.RecipeResponse);
            return Task.FromResult(recipe);
        }
    }
}
