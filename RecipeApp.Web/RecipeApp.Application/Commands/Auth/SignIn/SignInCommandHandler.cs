using MediatR;
using RecipeApp.Application.DTOs;
using RecipeApp.Application.Services.AuthorizationService;

namespace RecipeApp.Application.Commands.Auth.SignIn
{
    public class SignInCommandHandler : IRequestHandler<SignInCommand, JWTTokenStatusResultDto>
    {
        private readonly BaseAuthorizationService _authorizationService;

        public SignInCommandHandler(BaseAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public async Task<JWTTokenStatusResultDto> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            return await _authorizationService.GenerateTokenAsync(request);
        }
    }
}
