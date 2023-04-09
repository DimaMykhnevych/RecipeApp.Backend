namespace RecipeApp.Domain.Entities
{
    public class StoredIngredient
    {
        public int Id { get; set; }
        public DateTime ExpirationDate { get; set; }
        public double Amount { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int IngredientId { get; set; }
        public int AppUserId { get; set; }

        public Ingredient Ingredient { get; set; }
        public AppUser AppUser { get; set; }
    }
}
