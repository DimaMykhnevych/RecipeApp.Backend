using RecipeApp.Domain.Builders;
using RecipeApp.Domain.Entities;
using RecipeApp.Infrastructure.Persistance.Context;

namespace RecipeApp.Infrastructure.Persistance.Builders
{
    public class AppUserQueryBuilder : IAppUserQueryBuilder
    {
        private readonly RecipeAppDbContext _dbContext;
        private IQueryable<AppUser> _query;

        public AppUserQueryBuilder(RecipeAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<AppUser> Build()
        {
            IQueryable<AppUser> result = _query;
            _query = null;
            return result;
        }


        public IAppUserQueryBuilder SetBaseUserInfo()
        {
            _query = _dbContext.AppUsers;
            return this;
        }

        public IAppUserQueryBuilder SetUserEmail(string userEmail)
        {
            if (!string.IsNullOrEmpty(userEmail))
            {
                _query = _query.Where(u => u.Email == userEmail);
            }
            return this;
        }

        public IAppUserQueryBuilder SetUserId(int? userId)
        {
            if (userId is not null)
            {
                _query = _query.Where(u => u.Id == userId);
            }
            return this;
        }

        public IAppUserQueryBuilder SetUserName(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                _query = _query.Where(u => u.UserName == userName);
            }
            return this;
        }
    }
}
