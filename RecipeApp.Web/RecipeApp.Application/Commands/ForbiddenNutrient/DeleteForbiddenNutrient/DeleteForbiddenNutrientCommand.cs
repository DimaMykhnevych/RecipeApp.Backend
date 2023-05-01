using MediatR;

namespace RecipeApp.Application.Commands.ForbiddenNutrientN.DeleteForbiddenNutrient
{
    public class DeleteForbiddenNutrientCommand : IRequest<bool>
    {
        public int AppUserId { get; set; }
        public int ForbiddenNutrientId { get; set; }
    }
}
