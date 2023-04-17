namespace RecipeApp.Application.DTOs
{
    public class GetForbiddenNutrientsDto
    {
        public IEnumerable<ForbiddenNutrientDto> ForbiddenNutrients { get; set; }
        public int ResultsAmount { get; set; }
    }
}
