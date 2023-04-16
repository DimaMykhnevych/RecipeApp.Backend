using RecipeApp.Domain.Entities;

namespace RecipeApp.Application.DTOs
{
    public class StoredIngredientDto
    {
        public int Id { get; set; }
        public DateTime ExpirationDate { get; set; }
        public double Amount { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string Name { get; set; }
        public Unit Unit { get; set; }
        public int IngredientId { get; set; }
    }
}
