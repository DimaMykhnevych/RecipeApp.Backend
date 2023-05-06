namespace RecipeApp.Application.DTOs
{
    public class MealPlanRecommendationParametersDto
    {
        public bool? ConsiderIngredientsAmount { get; set; }
        public double? AcceptableMatchIngredientsPercentage { get; set; }
    }
}
