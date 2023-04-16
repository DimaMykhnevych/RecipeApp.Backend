namespace RecipeApp.Domain.Services.Family.DeleteFamilyService
{
    public interface IDeleteFamilyService
    {
        Task<bool> DeleteAsync(int userId, int familyId);
    }
}
