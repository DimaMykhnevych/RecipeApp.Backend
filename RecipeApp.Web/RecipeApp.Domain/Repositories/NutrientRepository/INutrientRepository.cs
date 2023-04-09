using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Repositories.NutrientRepository
{
    public interface INutrientRepository : IRepository<Nutrient>
    {
        Task<Nutrient> GetNutrientByName(string name);
    }
}
