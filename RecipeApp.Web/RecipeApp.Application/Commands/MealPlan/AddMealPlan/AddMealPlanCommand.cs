using MediatR;
using RecipeApp.Application.DTOs;

namespace RecipeApp.Application.Commands.MealPlanN.AddMealPlan
{
    public class AddMealPlanCommand : IRequest<bool>
    {
        public AddMealPlanDto MealPlan { get; set; }
        public int UserId { get; set; }
    }
}
