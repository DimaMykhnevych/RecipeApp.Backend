using MediatR;
using RecipeApp.Application.DTOs;

namespace RecipeApp.Application.Queries.StoredIngredient.GetStoredIngredients
{
    public class GetStoredIngredientsQuery : IRequest<GetStoredIngredientsDto>
    {
        public int UserId { get; set; }
    }
}
