using AutoMapper;
using RecipeApp.Application.Commands.User.CreateUser;
using RecipeApp.Application.DTOs;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Models;

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

            CreateMap<DbBackup, DbBackupDto>();
        }
    }
}
