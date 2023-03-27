using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Builders
{
    public interface IAppUserQueryBuilder : IQueryBuilder<AppUser>
    {
        IAppUserQueryBuilder SetBaseUserInfo();
        IAppUserQueryBuilder SetUserName(string userName);
        IAppUserQueryBuilder SetUserId(int? userId);
        IAppUserQueryBuilder SetUserEmail(string userEmail);
    }
}
