namespace RecipeApp.Application.DTOs
{
    public class GetRecommendedMealPlanDto
    {
        public DateTime MealPlanDate { get; set; }
        public ICollection<RecommendedMealPlanDayDto> MealPlanDays { get; set; }
    }
}
