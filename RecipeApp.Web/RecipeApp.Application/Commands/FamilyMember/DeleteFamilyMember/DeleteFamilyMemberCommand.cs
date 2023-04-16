using MediatR;

namespace RecipeApp.Application.Commands.FamilyMember.DeleteFamilyMember
{
    public class DeleteFamilyMemberCommand : IRequest<bool>
    {
        public int FamilyMemberId { get; set; }
        public int UserId { get; set; }
    }
}
