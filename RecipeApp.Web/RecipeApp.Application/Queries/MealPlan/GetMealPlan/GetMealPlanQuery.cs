using MediatR;
using RecipeApp.Application.DTOs;

namespace RecipeApp.Application.Queries.MealPlanN.GetMealPlan
{
    public class GetMealPlanQuery : IRequest<GetMealPlansDto>
    {
        public int UserId { get; set; }
        public MealPlansFilteringDto MealPlansFiltering { get; set; }
    }
}
