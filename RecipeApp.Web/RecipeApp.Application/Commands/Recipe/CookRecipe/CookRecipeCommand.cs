using MediatR;

namespace RecipeApp.Application.Commands.RecipeN.CookRecipe
{
    public class CookRecipeCommand : IRequest<bool>
    {
        public int AppUserId { get; set; }
        public int RecipeId { get; set; }
    }
}
