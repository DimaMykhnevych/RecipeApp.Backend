namespace RecipeApp.Application.DTOs
{
    public class GetMealPlanDayDto
    {
        public int Id { get; set; }
        public int MealPlanId { get; set; }
        public int IngestionId { get; set; }
        public int RecipeId { get; set; }
        public int Servings { get; set; }

        public RecipeDto Recipe { get; set; }
        public GetIngestionDto Ingestion { get; set; }
    }
}
