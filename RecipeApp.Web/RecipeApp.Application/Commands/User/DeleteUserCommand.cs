using MediatR;

namespace RecipeApp.Application.Commands.User
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
