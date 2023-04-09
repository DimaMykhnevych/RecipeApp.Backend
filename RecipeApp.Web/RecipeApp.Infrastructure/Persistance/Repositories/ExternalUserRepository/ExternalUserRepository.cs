using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Repositories.ExternalUserRepository;
using RecipeApp.Infrastructure.Persistance.Context;

namespace RecipeApp.Infrastructure.Persistance.Repositories.ExternalUserRepository
{
    public class ExternalUserRepository : Repository<ExternalUser>, IExternalUserRepository
    {
        public ExternalUserRepository(RecipeAppDbContext context) : base(context)
        {
        }
    }
}
