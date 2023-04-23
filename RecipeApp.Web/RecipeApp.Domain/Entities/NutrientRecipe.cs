namespace RecipeApp.Domain.Entities
{
    public class NutrientRecipe
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public double PercentOfDailyNeeds { get; set; }
        public int RecipeId { get; set; }
        public int NutrientId { get; set; }

        public Recipe Recipe { get; set; }
        public Nutrient Nutrient { get; set; }
    }
}
