using MediatR;

namespace RecipeApp.Application.Commands.Family.DeleteFamily
{
    public class DeleteFamilyCommand : IRequest<bool>
    {
        public int FamilyId { get; set; }
        public int UserId { get; set; }
    }
}
