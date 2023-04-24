namespace RecipeApp.Application.DTOs
{
    public class GetMealPlanDto
    {
        public int Id { get; set; }
        public DateTime MealPlanDate { get; set; }
        public int? FamilyId { get; set; }
        public int AppUserId { get; set; }

        public IEnumerable<GetMealPlanDayDto> MealPlanDays { get; set; }
    }
}
