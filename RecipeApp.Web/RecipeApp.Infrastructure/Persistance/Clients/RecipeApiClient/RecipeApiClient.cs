using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RecipeApp.Domain.Clients.RecipeApiClient;
using RecipeApp.Domain.Models;
using RecipeApp.Domain.Options;
using RecipeApp.Infrastructure.Persistance.Clients.RecipeApiClient;
using System.Text.Json;

namespace RecipeApp.Infrastructure.Persistance.Clients.RecipeApiClientN
{
    public class RecipeApiClient : BaseRecipeApiClient, IRecipeApiClient
    {
        private readonly ILogger _logger;

        public RecipeApiClient(
            HttpClient httpClient,
            IOptions<RecipeApiOptions> options,
            ILoggerFactory loggerFactory
            ) : base(httpClient, options, loggerFactory)
        {
            _logger = loggerFactory?.CreateLogger(nameof(RecipeApiClient));
        }

        public async Task<IngredientAmountConversion> Convert(IngredientConversionParameters ingredientConversionParameters)
        {
            _logger.LogInformation("Sending conversion request to Recipe API");
            var parameters = new Dictionary<string, string>
            {
                { "ingredientName", ingredientConversionParameters.IngredientName },
                { "sourceAmount", ingredientConversionParameters.SourceAmount.ToString() },
                { "sourceUnit", ingredientConversionParameters.SourceUnit },
                { "targetUnit", ingredientConversionParameters.TargetUnit }
            };

            var apiRoute = GetFullApiRoute(parameters, RecipeApiRoutes.ConvertUnit);
            var response = await TryExecuteGetRequestAsync(apiRoute);
            if (response == null)
            {
                _logger.LogWarning("Retrieving empty response from Recipe API");
                return null;
            }

            var responseString = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IngredientAmountConversion>(responseString);
        }
    }
}
