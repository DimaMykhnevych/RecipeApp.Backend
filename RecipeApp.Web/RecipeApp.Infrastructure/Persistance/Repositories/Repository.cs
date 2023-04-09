using Microsoft.EntityFrameworkCore;
using RecipeApp.Domain.Repositories;
using RecipeApp.Infrastructure.Persistance.Context;

namespace RecipeApp.Infrastructure.Persistance.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly RecipeAppDbContext context;

        public Repository(RecipeAppDbContext context)
        {
            this.context = context;
        }

        public async Task<TEntity> Get(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        public async Task Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            await Save();
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}
