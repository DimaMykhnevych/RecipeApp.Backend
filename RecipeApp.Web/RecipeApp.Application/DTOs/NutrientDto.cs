using RecipeApp.Domain.Entities;

namespace RecipeApp.Application.DTOs
{
    public class NutrientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Unit Unit { get; set; }
    }
}
