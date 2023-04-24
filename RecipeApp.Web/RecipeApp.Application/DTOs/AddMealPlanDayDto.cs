namespace RecipeApp.Application.DTOs
{
    public class AddMealPlanDayDto
    {
        public int RecipeId { get; set; }
        public int Servings { get; set; }
        public AddIngestionDto Ingestion { get; set; }
    }
}
