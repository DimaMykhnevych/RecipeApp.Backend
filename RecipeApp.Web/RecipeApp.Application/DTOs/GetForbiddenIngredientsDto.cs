namespace RecipeApp.Application.DTOs
{
    public class GetForbiddenIngredientsDto
    {
        public IEnumerable<ForbiddenIngredientDto> ForbiddenIngredients { get; set; }
        public int ResultsAmount { get; set; }
    }
}
