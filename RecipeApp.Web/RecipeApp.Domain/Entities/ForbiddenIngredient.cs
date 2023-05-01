namespace RecipeApp.Domain.Entities
{
    public class ForbiddenIngredient
    {
        public int Id { get; set; }
        public int IngredientId { get; set; }
        public int ExternalUserId { get; set; }

        public Ingredient Ingredient { get; set; }
        public ExternalUser ExternalUser { get; set; }
    }
}
