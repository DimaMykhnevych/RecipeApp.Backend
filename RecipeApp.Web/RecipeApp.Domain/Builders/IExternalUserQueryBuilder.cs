using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Builders
{
    public interface IExternalUserQueryBuilder : IQueryBuilder<ExternalUser>
    {
        IExternalUserQueryBuilder SetBaseUserInfo();
        IExternalUserQueryBuilder SetUserName(string userName);
        IExternalUserQueryBuilder SetUserFullName(string fullName);
        IExternalUserQueryBuilder SetUserDOB(DateTime? dob);
        IExternalUserQueryBuilder SetUserId(int? userId);
    }
}
