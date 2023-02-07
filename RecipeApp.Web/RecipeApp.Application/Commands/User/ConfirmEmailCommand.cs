using MediatR;

namespace RecipeApp.Application.Commands.User
{
    public class ConfirmEmailCommand : IRequest<bool>
    {
        public string Token { get; set; }
        public string Email { get; set; }
    }
}
