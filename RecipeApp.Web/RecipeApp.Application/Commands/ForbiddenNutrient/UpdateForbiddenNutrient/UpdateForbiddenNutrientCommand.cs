using MediatR;
using RecipeApp.Application.DTOs;

namespace RecipeApp.Application.Commands.ForbiddenNutrientN.UpdateForbiddenNutrient
{
    public class UpdateForbiddenNutrientCommand : IRequest<bool>
    {
        public UpdateForbiddenNutrientDto ForbiddenNutrient { get; set; }
        public int AppUserId { get; set; }
    }
}
