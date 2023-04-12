using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Exceptions;
using RecipeApp.Domain.Models;
using RecipeApp.Domain.Options;
using RecipeApp.Domain.Repositories.IngredientRepository;
using RecipeApp.Domain.Services.FoodRecognition.RecognizeIngredients;
using System.Text;

namespace RecipeApp.Infrastructure.Persistance.Services.FoodRecognition
{
    public class RecognizeIngredientsService : IRecognizeIngredientsService
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly RoboflowApiOptions _roboflowApiOptions;
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;
        private const string detectIngredientsUri = "https://detect.roboflow.com/aicook-lcv4d/3?api_key={API_KEY}&name=photo.jpg";

        public RecognizeIngredientsService(
            IIngredientRepository ingredientsRepository,
            IOptions<RoboflowApiOptions> options,
            HttpClient httpClient,
            ILoggerFactory loggerFactory)
        {
            _ingredientRepository = ingredientsRepository;
            _roboflowApiOptions = options.Value;
            _logger = loggerFactory?.CreateLogger(nameof(RecognizeIngredientsService));
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Ingredient>> GetIngredientsPredictions(MemoryStream photo)
        {
            byte[] imageArray = photo.ToArray();
            string encoded = Convert.ToBase64String(imageArray);
            byte[] data = Encoding.ASCII.GetBytes(encoded);

            string url = detectIngredientsUri.Replace("{API_KEY}", _roboflowApiOptions.ApiKey);

            _logger.LogInformation("Sending request to roboflow API to detect ingredients");
            HttpRequestMessage request = new(HttpMethod.Post, url);

            ByteArrayContent byteContent = new(data);
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

            var predictionsRaw = JsonConvert.DeserializeObject<IEnumerable<IngredientsPrediction>>(responseObject["predictions"].ToString());
            var predictions = predictionsRaw.GroupBy(p => p.Class).Select(g => g.First());
            return await GetIngredientsFromPredictions(predictions);
        }

        private async Task<IEnumerable<Ingredient>> GetIngredientsFromPredictions(IEnumerable<IngredientsPrediction> predictions)
        {
            List<Ingredient> ingredients = new();
            var storedIngredients = await _ingredientRepository.GetAll();
            foreach (var prediction in predictions)
            {
                if (_predictionsToIngredientsNaming.TryGetValue(prediction.Class, out string value))
                {
                    var knownIngredient = storedIngredients.FirstOrDefault(i => i.Name == value);
                    if (knownIngredient != null) ingredients.Add(knownIngredient);
                    continue;
                }

                var foundIngredient = storedIngredients.Where(i => i.Name.ToLower().Contains(prediction.Class.ToLower()));
                if (foundIngredient != null && foundIngredient.Any())
                {
                    ingredients.Add(foundIngredient.First());
                }
            }

            return ingredients;
        }

        private readonly Dictionary<string, string> _predictionsToIngredientsNaming = new()
        {
            { "apple", "apples" },
            { "banana", "bananas" },
            { "beef", "beef top sirloin steak" },
            { "blueberries", "blueberries" },
            { "butter", "butter" },
            { "carrot", "carrots" },
            { "bread", "sandwich bread" },
            { "cheese", "cheese" },
            { "chicken", "chicken" },
            { "chicken_breast", "chicken breasts" },
            { "chocolate", "chocolate" },
            { "corn", "kernel corn" },
            { "eggs", "eggs" },
            { "flour", "flour" },
            { "goat_cheese", "goat cheese" },
            { "green_beans", "green beans" },
            { "ground_beef", "ground beef" },
            { "ham", "ham" },
            { "heavy_cream", "heavy cream" },
            { "lime", "lime wedges" },
            { "milk", "milk" },
            { "mushrooms", "mushrooms" },
            { "onion", "onions" },
            { "potato", "potatoes" },
            { "shrimp", "prawns" },
            { "spinach", "spinach" },
            { "strawberries", "strawberries" },
            { "sugar", "sugar" },
            { "sweet_potato", "sweet potato" },
            { "tomato", "tomatoes" },
        };
    }
}
