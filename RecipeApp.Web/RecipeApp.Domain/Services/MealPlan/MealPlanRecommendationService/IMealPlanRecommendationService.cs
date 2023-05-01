using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Services.MealPlanN.MealPlanRecommendationService
{
    public interface IMealPlanRecommendationService
    {
        Task<MealPlan> GetRecommendedMealPlan(int appUserId, int externalUserId);
    }
}
