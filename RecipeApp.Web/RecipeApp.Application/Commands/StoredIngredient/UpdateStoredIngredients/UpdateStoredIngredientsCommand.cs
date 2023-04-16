using MediatR;
using RecipeApp.Application.DTOs;

namespace RecipeApp.Application.Commands.StoredIngredient.UpdateStoredIngredients
{
    public class UpdateStoredIngredientsCommand : IRequest<bool>
    {
        public IEnumerable<UpdateStoredIngredientDto> StoredIngredients { get; set; }
    }
}
