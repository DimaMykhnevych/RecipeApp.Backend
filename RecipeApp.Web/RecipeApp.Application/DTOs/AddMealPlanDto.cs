namespace RecipeApp.Application.DTOs
{
    public class AddMealPlanDto
    {
        public int? FamilyId { get; set; }
        public ICollection<AddMealPlanDayDto> MealPlanDays { get; set; }
    }
}
