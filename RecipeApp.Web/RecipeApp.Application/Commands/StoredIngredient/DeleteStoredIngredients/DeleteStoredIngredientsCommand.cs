using MediatR;

namespace RecipeApp.Application.Commands.StoredIngredient.DeleteStoredIngredients
{
    public class DeleteStoredIngredientsCommand : IRequest<bool>
    {
        public IEnumerable<int> StoredIngredientIds { get; set; }
    }
}
