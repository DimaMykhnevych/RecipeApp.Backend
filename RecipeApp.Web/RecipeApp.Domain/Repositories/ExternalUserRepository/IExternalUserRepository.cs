using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Repositories.ExternalUserRepository
{
    public interface IExternalUserRepository
    {
        Task<ExternalUser> Insert(ExternalUser entity);

        Task Save();
    }
}
