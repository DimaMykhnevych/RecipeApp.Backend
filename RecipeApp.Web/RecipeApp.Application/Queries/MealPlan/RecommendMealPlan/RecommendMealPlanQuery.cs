using MediatR;
using RecipeApp.Application.DTOs;

namespace RecipeApp.Application.Queries.MealPlanN.RecommendMealPlan
{
    public class RecommendMealPlanQuery : IRequest<GetRecommendedMealPlanDto>
    {
        public int ExternalUserId { get; set; }
        public int AppUserId { get; set; }
        public MealPlanRecommendationParametersDto MealPlanRecommendationParameters { get; set; }
    }
}
