namespace RecipeApp.Application.DTOs
{
    public class GetIngredientsDto
    {
        public IEnumerable<IngredientDto> Ingredients { get; set; }
        public int ResultsAmount { get; set; }
    }
}
