namespace RecipeApp.Domain.Entities
{
    public class Ingestion
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public DishType DishType { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

        public ICollection<MealPlanDay> MealPlanDays { get; set; }
    }
}
