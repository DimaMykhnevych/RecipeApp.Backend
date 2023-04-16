using MediatR;
using RecipeApp.Application.DTOs;

namespace RecipeApp.Application.Commands.StoredIngredient.SaveStoredIngredients
{
    public class SaveStoredIngredientsCommand : IRequest<bool>
    {
        public IEnumerable<AddStoredIngredientDto> StoredIngredients { get; set; }
        public int UserId { get; set; }
    }
}
