using MediatR;
using RecipeApp.Application.DTOs;

namespace RecipeApp.Application.Queries.Family.GetAppUserFamilies
{
    public class GetAppUserFamiliesQuery : IRequest<GetFamiliesDto>
    {
        public int UserId { get; set; }
    }
}
