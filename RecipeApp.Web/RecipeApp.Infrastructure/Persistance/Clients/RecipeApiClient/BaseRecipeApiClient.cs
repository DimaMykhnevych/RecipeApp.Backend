using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RecipeApp.Domain.Options;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace RecipeApp.Infrastructure.Persistance.Clients.RecipeApiClient
{
    public class BaseRecipeApiClient
    {
        private readonly RecipeApiOptions _recipeApiOptions;
        protected readonly HttpClient _httpClient;
        private readonly ILogger _logger;

        public BaseRecipeApiClient(
            HttpClient httpClient,
            IOptions<RecipeApiOptions> options,
            ILoggerFactory loggerFactory)
        {
            _recipeApiOptions = options.Value;
            _httpClient = httpClient;
            _logger = loggerFactory?.CreateLogger(nameof(BaseRecipeApiClient));
        }

        protected async Task<HttpResponseMessage> TryExecuteGetRequestAsync(string url)
        {
            int index = 0;
            var keys = _recipeApiOptions.RecipeApiKeys.ToList();

            while (true)
            {
                HttpRequestMessage request = new(HttpMethod.Get, url);
                var builder = new UriBuilder(request.RequestUri);
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["apiKey"] = keys[index];
                builder.Query = query.ToString();
                request.RequestUri = builder.Uri;

                try
                {
                    var response = await _httpClient.SendAsync(request);
                    if (response.StatusCode == HttpStatusCode.PaymentRequired)
                    {
                        index++;
                        _logger.LogDebug("Getting next API key: {index}", index);
                    }
                    else if (response.StatusCode == HttpStatusCode.TooManyRequests)
                    {
                        _logger.LogWarning("Too many requests to Recipe API...");
                        Thread.Sleep(30000);
                        return null;
                    }
                    else if (!response.IsSuccessStatusCode)
                    {
                        _logger.LogWarning("An unsuccessfull response was returned from the Recipe API: {ReasonPhrase}", response.ReasonPhrase);
                        return null;
                    }
                    else
                    {
                        return response;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while communicating with the Recipe API");
                    return null;
                }

            }
        }

        protected static string GetFullApiRoute(Dictionary<string, string> parameters, string templateRoute)
        {
            return Regex.Replace(templateRoute, @"\{(.+?)\}", m => parameters[m.Groups[1].Value]);
        }

    }
}
