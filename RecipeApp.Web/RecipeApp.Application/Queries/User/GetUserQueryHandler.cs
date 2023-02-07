using AutoMapper;
using MediatR;
using RecipeApp.Application.DTOs;
using RecipeApp.Domain.Builders;
using RecipeApp.Domain.Entities;

namespace RecipeApp.Application.Queries.User
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, IEnumerable<UserAuthInfoDto>>
    {
        private readonly IUserQueryBuilder _userQueryBuilder;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IUserQueryBuilder userQueryBuilder, IMapper mapper)
        {
            _userQueryBuilder = userQueryBuilder;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserAuthInfoDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
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
