using MediatR;
using RecipeApp.Application.DTOs;

namespace RecipeApp.Application.Queries.ForbiddenNutrientN.GetForbiddenNutrients
{
    public class GetForbiddenNutrientsQuery : IRequest<GetForbiddenNutrientsDto>
    {
        public int ExternalUserId { get; set; }
    }
}
