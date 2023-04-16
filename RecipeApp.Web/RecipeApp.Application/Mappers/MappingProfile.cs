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
            CreateMap<ExternalUser, ExternalUserDto>();
            CreateMap<RecipeStep, RecipeStepDto>();
            CreateMap<Recipe, RecipeDto>()
                .ForMember(r => r.Ingredients, 
                           m => m.MapFrom(i => i.RecipeIngredients
                                               .Select(ri => new IngredientDto()
                                               {
                                                   Id = ri.IngredientId,
                                                   Amount = ri.Amount,
                                                   Name = ri.Ingredient.Name,
                                                   Unit = ri.Ingredient.Unit
                                               })));

            CreateMap<Ingredient, IngredientDto>();
            CreateMap<AddStoredIngredientDto, StoredIngredient>();
            CreateMap<StoredIngredient, StoredIngredientDto>()
                .ForMember(si => si.Name, m => m.MapFrom(i => i.Ingredient.Name))
                .ForMember(si => si.Unit, m => m.MapFrom(i => i.Ingredient.Unit));
        }
    }
}
