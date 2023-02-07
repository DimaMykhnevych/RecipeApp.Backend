using AutoMapper;
using RecipeApp.Application.Commands.User;
using RecipeApp.Application.DTOs;
using RecipeApp.Domain.Entities;

namespace RecipeApp.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserCommand, AppUser>()
                    .ForMember(u => u.Role, m => m.MapFrom(u => u.Role))
                    .ForMember(u => u.UserName, m => m.MapFrom(u => u.UserName));

            CreateMap<AppUser, UserAuthInfoDto>()
                .ForMember(u => u.UserId, m => m.MapFrom(u => u.Id));
        }
    }
}
