using MediatR;
using Microsoft.AspNetCore.Identity;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Extensions;

namespace RecipeApp.Application.Commands.User.ConfirmEmail
{
    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, bool>
    {
        private readonly UserManager<AppUser> _userManager;

        public ConfirmEmailCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            AppUser user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return false;
            var confirmResult = await _userManager.ConfirmEmailAsync(user, request.Token);
            confirmResult.ValidateIdentityResult();
            return true;
        }
    }
}
