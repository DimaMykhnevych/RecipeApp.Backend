namespace RecipeApp.Domain.Entities
{
    public class ForbiddenIngredient
    {
        public int Id { get; set; }
        public int IngredientId { get; set; }
        public int AppUserId { get; set; }

        public Ingredient Ingredient { get; set; }
        public AppUser AppUser { get; set; }
    }
}
