using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Repositories.ExternalUserRepository
{
    public interface IExternalUserRepository : IRepository<ExternalUser>
    {
        Task<ExternalUser> GetByUsername(string username);
        Task<ExternalUser> GetByAppUserId(int id);
    }
}
