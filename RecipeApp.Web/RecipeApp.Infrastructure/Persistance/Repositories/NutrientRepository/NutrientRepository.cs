using Microsoft.EntityFrameworkCore;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Repositories.NutrientRepository;
using RecipeApp.Infrastructure.Persistance.Context;

namespace RecipeApp.Infrastructure.Persistance.Repositories.NutrientRepository
{
    public class NutrientRepository : Repository<Nutrient>, INutrientRepository
    {
        public NutrientRepository(RecipeAppDbContext context) : base(context)
        {
        }

        public async Task<Nutrient> GetNutrientByName(string name)
        {
            return await context.Nutrients.FirstOrDefaultAsync(r => r.Name.ToLower() == name.ToLower());
        }
    }
}
