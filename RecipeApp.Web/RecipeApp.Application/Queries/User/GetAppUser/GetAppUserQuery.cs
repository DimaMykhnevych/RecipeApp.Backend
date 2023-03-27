using MediatR;
using RecipeApp.Application.DTOs;

namespace RecipeApp.Application.Queries.User.GetAppUser
{
    public class GetAppUserQuery : IRequest<IEnumerable<UserAuthInfoDto>>
    {
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
