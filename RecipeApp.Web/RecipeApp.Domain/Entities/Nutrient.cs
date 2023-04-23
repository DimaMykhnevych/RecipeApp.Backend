namespace RecipeApp.Domain.Entities
{
    public class Nutrient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Unit Unit { get; set; }

        public ICollection<NutrientIngredient> NutrientIngredients { get; set; }
        public ICollection<NutrientRecipe> NutrientRecipes { get; set; }
        public ICollection<ForbiddenNutrient> ForbiddenNutrients { get; set; }
    }
}
