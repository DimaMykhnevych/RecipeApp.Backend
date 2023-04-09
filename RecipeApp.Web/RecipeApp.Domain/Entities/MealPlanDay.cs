namespace RecipeApp.Domain.Entities
{
    public class MealPlanDay
    {
        public int Id { get; set; }
        public int MealPlanId { get; set; }
        public int IngestionId { get; set; }
        public int RecipeId { get; set; }
        public int Servings { get; set; } = 1;

        public Ingestion Ingestion { get; set; }
        public MealPlan MealPlan { get; set; }
        public Recipe Recipe { get; set; }
    }
}
