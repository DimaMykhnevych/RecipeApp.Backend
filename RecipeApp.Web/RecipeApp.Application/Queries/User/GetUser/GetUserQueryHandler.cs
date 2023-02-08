using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Application.DTOs;
using RecipeApp.Domain.Builders;
using RecipeApp.Domain.Entities;

namespace RecipeApp.Application.Queries.User.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, IEnumerable<UserAuthInfoDto>>
    {
        private readonly IUserQueryBuilder _userQueryBuilder;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetUserQueryHandler(IUserQueryBuilder userQueryBuilder, IMapper mapper, ILoggerFactory loggerFactory)
        {
            _userQueryBuilder = userQueryBuilder;
            _mapper = mapper;
            _logger = loggerFactory?.CreateLogger(nameof(GetUserQueryHandler));
        }

        public async Task<IEnumerable<UserAuthInfoDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling get user request");
            ArgumentNullException.ThrowIfNull(request);

            IEnumerable<AppUser> users = _userQueryBuilder
                .SetBaseUserInfo()
                .SetUserName(request.UserName)
                .SetUserId(request.UserId)
                .SetUserEmail(request.Email)
                .Build();

            return _mapper.Map<IEnumerable<UserAuthInfoDto>>(users);
        }
    }
}
