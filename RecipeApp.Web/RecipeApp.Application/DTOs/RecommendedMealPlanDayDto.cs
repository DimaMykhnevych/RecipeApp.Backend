namespace RecipeApp.Application.DTOs
{
    public class RecommendedMealPlanDayDto
    {
        public int RecipeId { get; set; }
        public int Servings { get; set; }
        public RecipeDto Recipe { get; set; }
        public RecommendedMealPlanDayIngestionDto Ingestion { get; set;}
    }
}
