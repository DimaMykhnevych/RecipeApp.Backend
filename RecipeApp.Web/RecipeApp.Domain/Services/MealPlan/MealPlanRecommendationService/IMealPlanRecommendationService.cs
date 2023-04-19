namespace RecipeApp.Domain.Services.MealPlan.MealPlanRecommendationService
{
    public interface IMealPlanRecommendationService
    {
        Task<Entities.MealPlan> GetRecommendedMealPlan(int appUserId, int externalUserId);
    }
}
