namespace RecipeApp.Domain.Models
{
    public class MealPlanRecommendationParameters
    {
        public int AppUserId { get; set; }
        public int ExternalUserId { get; set; }
        public bool? ConsiderIngredientsAmount { get; set; }
        public double? AcceptableMatchIngredientsPercentage { get; set; }
    }
}
