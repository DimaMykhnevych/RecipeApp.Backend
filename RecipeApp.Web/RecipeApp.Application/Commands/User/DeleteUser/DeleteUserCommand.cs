using MediatR;

namespace RecipeApp.Application.Commands.User.DeleteUser
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
