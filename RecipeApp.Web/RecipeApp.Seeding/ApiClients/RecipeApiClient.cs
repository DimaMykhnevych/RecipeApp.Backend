using Newtonsoft.Json;
using RecipeApp.Seeding.ApiModels;

namespace RecipeApp.Seeding.ApiClients
{
    internal class RecipeApiClient : BaseApiClient, IRecipeApiClient
    {
        public RecipeApiClient(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<ConvertAmountDto> Convert(string ingredientName, double sourceAmount, string sourceUnit, string targetUnit)
        {
            var parameters = new Dictionary<string, string>
            {
                { "ingredientName", ingredientName },
                { "sourceAmount", sourceAmount.ToString() },
                { "sourceUnit", sourceUnit },
                { "targetUnit", targetUnit }
            };

            var apiRoute = GetFullApiRoute(parameters, RecipeApiRoutes.ConvertUnit);
            var response = await TryExecuteGetRequestAsync(apiRoute);
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ConvertAmountDto>(responseString);
        }

        public async Task<IngredientDto> GetIngredientInfo(int id, double amount, string unit)
        {
            var parameters = new Dictionary<string, string>
            {
                { "id", id.ToString() },
                { "amount", amount.ToString() },
                { "unit", unit }
            };

            var apiRoute = GetFullApiRoute(parameters, RecipeApiRoutes.GetIngredientById);
            var response = await TryExecuteGetRequestAsync(apiRoute);
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IngredientDto>(responseString);
        }

        public async Task<RecipeDto> GetRecipeInfo(int id)
        {
            var parameters = new Dictionary<string, string> 
            {
                { "id", id.ToString() }
            };

            var apiRoute = GetFullApiRoute(parameters, RecipeApiRoutes.GetRecipeById);
            var response = await TryExecuteGetRequestAsync(apiRoute);
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<RecipeDto>(responseString);
        }
    }
}
