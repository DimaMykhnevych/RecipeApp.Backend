namespace RecipeApp.Domain.Entities
{
    public class NutrientIngredient
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public double PercentOfDailyNeeds { get; set; }
        public int IngredientId { get; set; }
        public int NutrientId { get; set; }

        public Ingredient Ingredient { get; set; }
        public Nutrient Nutrient { get; set; }
    }
}
