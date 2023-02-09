namespace RecipeApp.Domain.Services.DbManagement.RestoreDb
{
    public interface IRestoreDbService
    {
        Task<bool> RestoreDbFromFileAsync(Stream fileStream);
    }
}
