namespace RecipeApp.Domain.Services.Family.UpdateFamilyService
{
    public interface IUpdateFamilyService
    {
        Task<bool> UpdateAsync(int userId, Entities.Family family);
    }
}
