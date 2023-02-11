using RecipeApp.Domain.Models;

namespace RecipeApp.Domain.Services.FoodRecognition.RecognizeIngredients
{
    public interface IRecognizeIngredientsService
    {
        public Task<IEnumerable<IngredientsPrediction>> GetIngredientsPredictions(MemoryStream photo);
    }
}
