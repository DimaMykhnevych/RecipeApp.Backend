using RecipeApp.Domain.Models;

namespace RecipeApp.Domain.Services.DbManagement.CreateBackup
{
    public interface ICreateBackupService
    {
        Task<DbBackup> BackupDatabaseAsync();
    }
}
