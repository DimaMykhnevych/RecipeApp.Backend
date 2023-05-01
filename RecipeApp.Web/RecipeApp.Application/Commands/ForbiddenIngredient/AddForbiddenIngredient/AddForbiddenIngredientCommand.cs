using MediatR;
using RecipeApp.Application.DTOs;

namespace RecipeApp.Application.Commands.ForbiddenIngredientN.AddForbiddenIngredient
{
    public class AddForbiddenIngredientCommand : IRequest<bool>
    {
        public AddForbiddenIngredientDto ForbiddenIngredient { get; set; }
        public int AppUserId { get; set; }
    }
}
