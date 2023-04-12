using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Services.FoodRecognition.RecognizeIngredients
{
    public interface IRecognizeIngredientsService
    {
        public Task<IEnumerable<Ingredient>> GetIngredientsPredictions(MemoryStream photo);
    }
}
