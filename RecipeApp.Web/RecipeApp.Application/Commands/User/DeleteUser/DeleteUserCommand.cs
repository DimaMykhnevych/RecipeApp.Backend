using MediatR;

namespace RecipeApp.Application.Commands.User.DeleteUser
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
