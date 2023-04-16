namespace RecipeApp.Application.DTOs
{
    public class AddStoredIngredientDto
    {
        public DateTime ExpirationDate { get; set; }
        public double Amount { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int IngredientId { get; set; }
    }
}
