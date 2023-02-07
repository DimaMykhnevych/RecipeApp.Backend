using MediatR;
using RecipeApp.Application.DTOs;

namespace RecipeApp.Application.Commands.Auth
{
    public class SignInCommand : IRequest<JWTTokenStatusResultDto>
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
