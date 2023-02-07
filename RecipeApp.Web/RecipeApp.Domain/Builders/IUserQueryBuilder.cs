using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Builders
{
    public interface IUserQueryBuilder : IQueryBuilder<AppUser>
    {
        IUserQueryBuilder SetBaseUserInfo();
        IUserQueryBuilder SetUserName(string userName);
        IUserQueryBuilder SetUserId(Guid? userId);
        IUserQueryBuilder SetUserEmail(string userEmail);
    }
}
