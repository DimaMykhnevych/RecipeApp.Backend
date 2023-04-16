using MediatR;
using RecipeApp.Application.DTOs;

namespace RecipeApp.Application.Commands.Family.UpdateFamily
{
    public class UpdateFamilyCommand : IRequest<bool>
    {
        public UpdateFamilyDto Family { get; set; }
        public int UserId { get; set; }
    }
}
