using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Models;

namespace RecipeApp.Domain.Services.MealPlanN.MealPlanRecommendationService
{
    public interface IMealPlanRecommendationService
    {
        Task<MealPlan> GetRecommendedMealPlan(MealPlanRecommendationParameters mealPlanRecommendationParameters);
    }
}
