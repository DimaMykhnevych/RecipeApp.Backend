namespace RecipeApp.Application.DTOs
{
    public class UpdateStoredIngredientDto
    {
        public int Id { get; set; }
        public DateTime ExpirationDate { get; set; }
        public double Amount { get; set; }
    }
}
