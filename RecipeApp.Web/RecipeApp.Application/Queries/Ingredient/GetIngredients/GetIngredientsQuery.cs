using MediatR;
using RecipeApp.Application.DTOs;

namespace RecipeApp.Application.Queries.Ingredient.GetIngredients
{
    public class GetIngredientsQuery : IRequest<GetIngredientsDto>
    {
        public string IngredientName { get; set; }
    }
}
