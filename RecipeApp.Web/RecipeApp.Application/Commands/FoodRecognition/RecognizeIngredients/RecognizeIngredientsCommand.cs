using MediatR;
using RecipeApp.Application.DTOs;

namespace RecipeApp.Application.Commands.FoodRecognition.RecognizeIngredients
{
    public class RecognizeIngredientsCommand : IRequest<RecognizedIngredientsDto>
    {
        public MemoryStream Image { get; set; }
    }
}
