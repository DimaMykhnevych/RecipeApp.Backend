using MediatR;
using Microsoft.AspNetCore.Identity;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Extensions;

namespace RecipeApp.Application.Commands.User
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly UserManager<AppUser> _userManager;

        public DeleteUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            AppUser userToDelete = await _userManager.FindByIdAsync(request.Id.ToString());
            if(userToDelete == null)
            {
                return false;
            }

            IdentityResult deleteUserResult = await _userManager.DeleteAsync(userToDelete);

            deleteUserResult.ValidateIdentityResult();

            return true;
        }
    }
}
