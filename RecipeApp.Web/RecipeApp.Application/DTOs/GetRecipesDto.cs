namespace RecipeApp.Application.DTOs
{
    public class GetRecipesDto
    {
        public IEnumerable<RecipeDto> Recipes { get; set; }
        public int ResultsAmount { get; set; }
    }
}
