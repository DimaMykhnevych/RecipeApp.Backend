using MediatR;

namespace RecipeApp.Application.Commands.RecipeN.AddRecipeNutrition
{
    public class AddRecipeNutritionCommand : IRequest<bool>
    {
        public int? RecipeId { get; set; }
    }
}
