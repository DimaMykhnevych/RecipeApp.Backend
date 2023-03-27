using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Application.DTOs;
using RecipeApp.Domain.Builders;
using RecipeApp.Domain.Entities;

namespace RecipeApp.Application.Queries.User.GetAppUser
{
    public class GetAppUserQueryHandler : IRequestHandler<GetAppUserQuery, IEnumerable<UserAuthInfoDto>>
    {
        private readonly IAppUserQueryBuilder _userQueryBuilder;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetAppUserQueryHandler(IAppUserQueryBuilder userQueryBuilder, IMapper mapper, ILoggerFactory loggerFactory)
        {
            _userQueryBuilder = userQueryBuilder;
            _mapper = mapper;
            _logger = loggerFactory?.CreateLogger(nameof(GetAppUserQueryHandler));
        }

        public async Task<IEnumerable<UserAuthInfoDto>> Handle(GetAppUserQuery request, CancellationToken cancellationToken)
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
