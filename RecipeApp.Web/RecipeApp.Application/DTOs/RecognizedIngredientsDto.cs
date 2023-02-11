namespace RecipeApp.Application.DTOs
{
    public class RecognizedIngredientsDto
    {
        public IEnumerable<IngredientsPredictionDto> Ingredients { get; set; }
    }
}
