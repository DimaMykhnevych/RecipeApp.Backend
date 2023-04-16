using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Repositories.FamilyRepository
{
    public interface IFamilyRepository : IRepository<Family>
    {
        Task InsertAppUserFamily(int appUserId, Family family);
        Task<IEnumerable<int>> GetAppUserFamilyIds(int appUserId);
    }
}
