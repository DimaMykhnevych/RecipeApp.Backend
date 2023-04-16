using Microsoft.EntityFrameworkCore;
using RecipeApp.Domain.Builders;
using RecipeApp.Domain.Entities;
using RecipeApp.Infrastructure.Persistance.Context;

namespace RecipeApp.Infrastructure.Persistance.Builders
{
    public class ExternalUserQueryBuilder : IExternalUserQueryBuilder
    {
        private readonly RecipeAppDbContext _dbContext;
        private IQueryable<ExternalUser> _query;

        public ExternalUserQueryBuilder(RecipeAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<ExternalUser> Build()
        {
            IQueryable<ExternalUser> result = _query;
            _query = null;
            return result;
        }


        public IExternalUserQueryBuilder SetBaseUserInfo()
        {
            _query = _dbContext.ExternalUsers
                .Include(u => u.AppUser)
                .AsNoTracking()
                .Where(u => u.AppUser == null);
            return this;
        }

        public IExternalUserQueryBuilder SetUserFullName(string userFullName)
        {
            if (!string.IsNullOrEmpty(userFullName))
            {
                _query = _query.Where(u => u.Name.Contains(userFullName));
            }
            return this;
        }

        public IExternalUserQueryBuilder SetUserDOB(DateTime? dob)
        {
            if (dob is not null)
            {
                _query = _query.Where(u => u.DOB == dob);
            }
            return this;
        }

        public IExternalUserQueryBuilder SetUserId(int? userId)
        {
            if (userId is not null)
            {
                _query = _query.Where(u => u.Id == userId);
            }
            return this;
        }

        public IExternalUserQueryBuilder SetUserName(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                _query = _query.Where(u => u.UserName.Contains(userName));
            }
            return this;
        }
    }
}
