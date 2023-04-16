namespace RecipeApp.Application.DTOs
{
    public class GetStoredIngredientsDto
    {
        public IEnumerable<StoredIngredientDto> StoredIngredients { get; set; }
        public int ResultsAmount { get; set; }
    }
}
