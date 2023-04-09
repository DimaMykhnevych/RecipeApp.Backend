namespace RecipeApp.Domain.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Unit Unit { get; set; }
        public string Image { get; set; }

        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
        public ICollection<StoredIngredient> StoredIngredients { get; set; }
        public ICollection<NutrientIngredient> NutrientIngredients { get; set; }
    }
}
