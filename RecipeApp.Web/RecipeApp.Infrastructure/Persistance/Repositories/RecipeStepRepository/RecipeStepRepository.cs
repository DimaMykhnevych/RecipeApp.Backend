using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Repositories.RecipeStepRepository;
using RecipeApp.Infrastructure.Persistance.Context;

namespace RecipeApp.Infrastructure.Persistance.Repositories.RecipeStepRepository
{
    public class RecipeStepRepository : Repository<RecipeStep>, IRecipeStepRepository
    {
        public RecipeStepRepository(RecipeAppDbContext context) : base(context)
        {
        }
    }
}
