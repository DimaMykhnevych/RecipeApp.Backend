using Microsoft.EntityFrameworkCore;
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

        public async Task<ExternalUser> GetByUsername(string username)
        {
            return await context.ExternalUsers.FirstOrDefaultAsync(e => e.UserName == username);
        }

        public async Task<ExternalUser> GetByAppUserId(int id)
        {
            return await context.ExternalUsers.FirstOrDefaultAsync(e => e.AppUserId == id);
        }
    }
}
