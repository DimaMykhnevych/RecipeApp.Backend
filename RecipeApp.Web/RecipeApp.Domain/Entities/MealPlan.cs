namespace RecipeApp.Domain.Entities
{
    public class MealPlan
    {
        public int Id { get; set; }
        public DateTime MealPlanDate { get; set; }
        public int? FamilyId { get; set; }
        public int AppUserId { get; set; }

        public Family Family { get; set; }
        public AppUser AppUser { get; set; }
        public ICollection<MealPlanDay> MealPlanDays { get; set; }
    }
}
