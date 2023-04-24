namespace RecipeApp.Application.DTOs
{
    public class GetMealPlansDto
    {
        public IEnumerable<GetMealPlanDto> MealPlans { get; set; }
        public int ResultsAmount { get; set; }
    }
}
