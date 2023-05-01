using MediatR;

namespace RecipeApp.Application.Commands.MealPlanN.DeleteMealPlan
{
    public class DeleteMealPlanCommand : IRequest<bool>
    {
        public int MealPlanId { get; set; }
        public int AppUserId { get; set; }
    }
}
