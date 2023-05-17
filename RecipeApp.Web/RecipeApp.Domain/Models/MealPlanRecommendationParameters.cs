namespace RecipeApp.Domain.Models
{
    public class MealPlanRecommendationParameters
    {
        public int AppUserId { get; set; }
        public int ExternalUserId { get; set; }
        public bool? ConsiderIngredientsAmount { get; set; }
        public double? AcceptableMatchIngredientsPercentage { get; set; }
        public double? Calories { get; set; }
        public double? Carbs { get; set; }
        public double? Fat { get; set; }
        public double? Protein { get; set; }
        public int? MealPlanGenerationSecondsLimit { get; set; }
    }
}
