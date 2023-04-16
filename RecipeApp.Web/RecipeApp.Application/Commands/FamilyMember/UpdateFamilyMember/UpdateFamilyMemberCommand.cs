using MediatR;
using RecipeApp.Application.DTOs;

namespace RecipeApp.Application.Commands.FamilyMemberN.UpdateFamilyMember
{
    public class UpdateFamilyMemberCommand : IRequest<bool>
    {
        public UpdateFamilyMemberDto FamilyMember { get; set; }
        public int UserId { get; set; }
    }
}
