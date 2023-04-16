using MediatR;
using RecipeApp.Application.DTOs;

namespace RecipeApp.Application.Commands.FamilyMemberN.AddFamilyMember
{
    public class AddFamilyMemberCommand : IRequest<bool>
    {
        public AddFamilyMemberDto FamilyMember { get; set; }
        public int UserId { get; set; }
    }
}
