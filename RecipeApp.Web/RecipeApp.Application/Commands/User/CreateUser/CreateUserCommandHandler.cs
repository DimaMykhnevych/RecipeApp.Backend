using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Services.User.CreateUser;

namespace RecipeApp.Application.Commands.User.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly ICreateUserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CreateUserCommandHandler(ICreateUserService userService, IMapper mapper, ILoggerFactory loggerFactory)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = loggerFactory?.CreateLogger(nameof(CreateUserCommandHandler));
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling creating user request");
            ArgumentNullException.ThrowIfNull(request);

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
