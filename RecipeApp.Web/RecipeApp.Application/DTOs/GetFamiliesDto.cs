namespace RecipeApp.Application.DTOs
{
    public class GetFamiliesDto
    {
        public IEnumerable<FamilyDto> Families { get; set; }
        public int ResultsAmount { get; set; }
    }
}
