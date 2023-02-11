using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RecipeApp.Domain.Exceptions;
using RecipeApp.Domain.Models;
using RecipeApp.Domain.Options;
using RecipeApp.Domain.Services.FoodRecognition.RecognizeIngredients;
using System.Text;

namespace RecipeApp.Infrastructure.Persistance.Services.FoodRecognition
{
    public class RecognizeIngredientsService : IRecognizeIngredientsService
    {
        private readonly RoboflowApiOptions _roboflowApiOptions;
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;
        private const string detectIngredientsUri = "https://detect.roboflow.com/aicook-lcv4d/3?api_key={API_KEY}&name=photo.jpg";

        public RecognizeIngredientsService(IOptions<RoboflowApiOptions> options, HttpClient httpClient, ILoggerFactory loggerFactory)
        {
            _roboflowApiOptions= options.Value;
            _logger = loggerFactory?.CreateLogger(nameof(RecognizeIngredientsService));
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<IngredientsPrediction>> GetIngredientsPredictions(MemoryStream photo)
        {
            byte[] imageArray = photo.ToArray();
            string encoded = Convert.ToBase64String(imageArray);
            byte[] data = Encoding.ASCII.GetBytes(encoded);

            string url = detectIngredientsUri.Replace("{API_KEY}", _roboflowApiOptions.ApiKey);

            _logger.LogInformation("Sending request to roboflow API to detect ingredients");
            HttpRequestMessage request = new (HttpMethod.Post, url);

            ByteArrayContent byteContent = new (data);
            byteContent.Headers.Remove("Content-Type");
            byteContent.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            request.Content = byteContent;

            HttpResponseMessage result = await _httpClient.SendAsync(request);
            string responseBody = await result.Content.ReadAsStringAsync();

            _logger.LogTrace("roboflow API response: {apiResponse}", responseBody);
            if (!result.IsSuccessStatusCode)
            {
                _logger.LogWarning("Error occurred during sending request to roboflow API");
                throw new RoboflowApiException();
            }

            JObject responseObject = JObject.Parse(responseBody);

            var predictions = JsonConvert.DeserializeObject<IEnumerable<IngredientsPrediction>>(responseObject["predictions"].ToString());
            return predictions.GroupBy(p => p.Class).Select(g => g.First());
        }
    }
}
