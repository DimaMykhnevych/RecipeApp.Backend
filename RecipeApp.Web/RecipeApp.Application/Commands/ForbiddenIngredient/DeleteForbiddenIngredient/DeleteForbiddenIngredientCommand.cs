using MediatR;

namespace RecipeApp.Application.Commands.ForbiddenIngredientN.DeleteForbiddenIngredient
{
    public class DeleteForbiddenIngredientCommand : IRequest<bool>
    {
        public int AppUserId { get; set; }
        public int ForbiddenIngredientId { get; set; }
    }
}
