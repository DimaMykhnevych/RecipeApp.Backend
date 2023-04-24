using MediatR;
using RecipeApp.Application.DTOs;

namespace RecipeApp.Application.Commands.RecipeN.AddRecipe
{
    public class AddRecipeCommand : IRequest<bool>
    {
        public AddRecipeDto Recipe { get; set; }
        public int UserId { get; set; }
    }
}
