using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Application.DTOs;
using RecipeApp.Domain.Builders;
using RecipeApp.Domain.Entities;

namespace RecipeApp.Application.Queries.User.GetExternalUser
{
    public class GetExternalUserQueryHandler : IRequestHandler<GetExternalUserQuery, IEnumerable<ExternalUserDto>>
    {
        private readonly IExternalUserQueryBuilder _userQueryBuilder;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetExternalUserQueryHandler(IExternalUserQueryBuilder userQueryBuilder, IMapper mapper, ILoggerFactory loggerFactory)
        {
            _userQueryBuilder = userQueryBuilder;
            _mapper = mapper;
            _logger = loggerFactory?.CreateLogger(nameof(GetExternalUserQueryHandler));
        }

        public async Task<IEnumerable<ExternalUserDto>> Handle(GetExternalUserQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling get user request");
            ArgumentNullException.ThrowIfNull(request);

            IEnumerable<ExternalUser> users = _userQueryBuilder
                .SetBaseUserInfo()
                .SetUserName(request.UserName)
                .SetUserId(request.UserId)
                .SetUserFullName(request.UserFullName)
                .SetUserDOB(request.DOB)
                .Build();

            return _mapper.Map<IEnumerable<ExternalUserDto>>(users);
        }
    }
}
