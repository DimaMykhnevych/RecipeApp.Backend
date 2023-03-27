using MediatR;
using RecipeApp.Application.DTOs;

namespace RecipeApp.Application.Queries.User.GetExternalUser
{
    public class GetExternalUserQuery : IRequest<IEnumerable<ExternalUserDto>>
    {
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string UserFullName { get; set; }
        public DateTime? DOB { get; set; }
    }
}
