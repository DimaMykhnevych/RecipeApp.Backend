using AutoMapper;
using RecipeApp.Application.Commands.ForbiddenNutrientN.AddForbiddenNutrient;
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
            CreateMap<RecipeStep, RecipeStepDto>().ReverseMap();
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

            CreateMap<AddRecipeDto, Recipe>();
            CreateMap<AddRecipeIngredientDto, RecipeIngredient>();

            CreateMap<Ingredient, IngredientDto>();
            CreateMap<AddStoredIngredientDto, StoredIngredient>();
            CreateMap<StoredIngredient, StoredIngredientDto>()
                .ForMember(si => si.Name, m => m.MapFrom(i => i.Ingredient.Name))
                .ForMember(si => si.Unit, m => m.MapFrom(i => i.Ingredient.Unit));
            CreateMap<UpdateFamilyDto, Family>();

            CreateMap<Family, FamilyDto>();
            CreateMap<FamilyMember, FamilyMemberDto>()
                .ForMember(fm => fm.Name, m => m.MapFrom(m => m.ExternalUser.Name))
                .ForMember(fm => fm.UserName, m => m.MapFrom(m => m.ExternalUser.UserName))
                .ForMember(fm => fm.DOB, m => m.MapFrom(m => m.ExternalUser.DOB));

            CreateMap<Nutrient, NutrientDto>();
            CreateMap<AddForbiddenNutrientCommand, ForbiddenNutrient>();
            CreateMap<ForbiddenNutrient, ForbiddenNutrientDto>()
                .ForMember(fn => fn.Name, m => m.MapFrom(m => m.Nutrient.Name))
                .ForMember(fn => fn.Unit, m => m.MapFrom(m => m.Nutrient.Unit));

            CreateMap<MealPlan, GetRecommendedMealPlanDto>();
            CreateMap<MealPlanDay, RecommendedMealPlanDayDto>();
            CreateMap<Ingestion, RecommendedMealPlanDayIngestionDto>();

            CreateMap<AddMealPlanDto, MealPlan>();
            CreateMap<AddMealPlanDayDto, MealPlanDay>();
            CreateMap<AddIngestionDto, Ingestion>();

            CreateMap<MealPlan, GetMealPlanDto>();
            CreateMap<MealPlanDay, GetMealPlanDayDto>();
            CreateMap<Ingestion, GetIngestionDto>();

            CreateMap<ForbiddenIngredient, ForbiddenIngredientDto>()
                .ForMember(fi => fi.Name, m => m.MapFrom(i => i.Ingredient.Name));
        }
    }
}
