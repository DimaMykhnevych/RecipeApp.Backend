using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Repositories.MealPlanRepository;
using RecipeApp.Infrastructure.Persistance.Context;

namespace RecipeApp.Infrastructure.Persistance.Repositories.MealPlanRepository
{
    public class MealPlanRepository : Repository<MealPlan>, IMealPlanRepository
    {
        public MealPlanRepository(RecipeAppDbContext context) : base(context)
        {
        }
    }
}
