using RecipeApp.Domain.Builders;
using RecipeApp.Domain.Entities;
using RecipeApp.Infrastructure.Persistance.Context;

namespace RecipeApp.Infrastructure.Persistance.Builders
{
    public class UserQueryBuilder : IUserQueryBuilder
    {
        private readonly RecipeAppDbContext _dbContext;
        private IQueryable<AppUser> _query;

        public UserQueryBuilder(RecipeAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<AppUser> Build()
        {
            IQueryable<AppUser> result = _query;
            _query = null;
            return result;
        }


        public IUserQueryBuilder SetBaseUserInfo()
        {
            _query = _dbContext.AppUsers;
            return this;
        }

        public IUserQueryBuilder SetUserEmail(string userEmail)
        {
            if (!string.IsNullOrEmpty(userEmail))
            {
                _query = _query.Where(u => u.Email == userEmail);
            }
            return this;
        }

        public IUserQueryBuilder SetUserId(Guid? userId)
        {
            if (userId is not null)
            {
                _query = _query.Where(u => u.Id == userId);
            }
            return this;
        }

        public IUserQueryBuilder SetUserName(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                _query = _query.Where(u => u.UserName == userName);
            }
            return this;
        }
    }
}
