using MediatR;

namespace RecipeApp.Application.Commands.RecipeN.DeleteRecipe
{
    public class DeleteRecipeCommand : IRequest<bool>
    {
        public int RecipeId { get; set; }
        public int UserId { get; set; }
    }
}
