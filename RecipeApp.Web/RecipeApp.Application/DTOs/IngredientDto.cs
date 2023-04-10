using RecipeApp.Domain.Entities;

namespace RecipeApp.Application.DTOs
{
    public class IngredientDto
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Name { get; set; }
        public Unit Unit { get; set; }
    }
}
