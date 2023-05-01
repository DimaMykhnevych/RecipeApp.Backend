using MediatR;
using RecipeApp.Application.DTOs;

namespace RecipeApp.Application.Queries.ForbiddenIngredientN.GetForbiddenIngredients
{
    public class GetForbiddenIngredientsQuery : IRequest<GetForbiddenIngredientsDto>
    {
        public int AppUserId { get; set; }
    }
}
