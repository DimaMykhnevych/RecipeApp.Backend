using MediatR;
using RecipeApp.Application.DTOs;

namespace RecipeApp.Application.Queries.User.GetUser
{
    public class GetUserQuery : IRequest<IEnumerable<UserAuthInfoDto>>
    {
        public Guid? UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
