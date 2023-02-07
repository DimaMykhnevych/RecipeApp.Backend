using AutoMapper;
using MediatR;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Services.UserService;

namespace RecipeApp.Application.Commands.User
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly ICreateUserService _userService;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(ICreateUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            AppUser userModel = _mapper.Map<AppUser>(request);
            AppUser addedUser = await _userService
                .CreateUserAsync(userModel,
                request.Password,
                request.ConfirmPassword,
                request.ClientURIForEmailConfirmation);

            return addedUser != null;
        }
    }
}
