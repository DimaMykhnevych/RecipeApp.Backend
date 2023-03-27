using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Repositories.ExternalUserRepository;
using RecipeApp.Infrastructure.Persistance.Context;

namespace RecipeApp.Infrastructure.Persistance.Repositories.ExternalUserRepository
{
    public class ExternalUserRepository : IExternalUserRepository
    {
        private readonly RecipeAppDbContext _context;
        public ExternalUserRepository(RecipeAppDbContext context)
        {
            _context = context;
        }

        public async Task<ExternalUser> Insert(ExternalUser entity)
        {
            await _context.ExternalUsers.AddAsync(entity);
            return entity;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
