using MediatR;
using RecipeApp.Application.DTOs;

namespace RecipeApp.Application.Commands.Family.AddFamily
{
    public class AddFamilyCommand : IRequest<bool>
    {
        public AddFamilyDto Family { get; set; }
        public int UserId { get; set; }
    }
}
