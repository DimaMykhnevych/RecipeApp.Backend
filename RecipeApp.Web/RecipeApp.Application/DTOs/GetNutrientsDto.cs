namespace RecipeApp.Application.DTOs
{
    public class GetNutrientsDto
    {
        public IEnumerable<NutrientDto> Nutrients { get; set; }
        public int ResultsAmount { get; set; }
    }
}
