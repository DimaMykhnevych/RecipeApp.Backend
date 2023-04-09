using RecipeApp.Seeding.Configuration;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace RecipeApp.Seeding.ApiClients
{
    internal class BaseApiClient
    {
        private readonly RecipeApi _recipeApiOptions;
        protected readonly HttpClient _httpClient;

        public BaseApiClient(HttpClient httpClient)
        {
            _recipeApiOptions = new SecretAppsettingReader().ReadSection<RecipeApi>(nameof(RecipeApi));
            _httpClient = httpClient;
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

                var response = await _httpClient.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.PaymentRequired)
                {
                    index++;
                }
                else if (response.StatusCode == HttpStatusCode.TooManyRequests)
                {
                    Thread.Sleep(60000);
                }
                else if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }
                else
                {
                    return response;
                }
            }
        }

        protected static string GetFullApiRoute(Dictionary<string, string> parameters, string templateRoute)
        {
            return Regex.Replace(templateRoute, @"\{(.+?)\}", m => parameters[m.Groups[1].Value]);
        }
    }
}
