namespace RecipeApp.Application.DTOs
{
    public class MealPlanRecommendationParametersDto
    {
        public int? MealPlanGenerationSecondsLimit { get; set; }
        public bool? ConsiderIngredientsAmount { get; set; }
        public double? AcceptableMatchIngredientsPercentage { get; set; }
        public double? Calories { get; set; }
        public double? Carbs { get; set; }
        public double? Fat { get; set; }
        public double? Protein { get; set; }
    }
}
