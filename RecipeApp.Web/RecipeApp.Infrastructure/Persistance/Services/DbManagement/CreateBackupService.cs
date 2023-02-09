using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using RecipeApp.Domain.Models;
using RecipeApp.Domain.Services.DbManagement.CreateBackup;
using RecipeApp.Web.Options;

namespace RecipeApp.Infrastructure.Persistance.Services.DbManagement
{
    public class CreateBackupService : ICreateBackupService
    {
        private readonly string _fullBackupPath = Path.Combine(
            @$"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}",
               @"RecipeApp\Backup");
        private readonly MySqlConfigOptions _mySqlConfig;
        private readonly ILogger _logger;

        public CreateBackupService(IOptions<MySqlConfigOptions> options, ILoggerFactory loggerFactory)
        {
            _mySqlConfig = options.Value;
            _logger = loggerFactory?.CreateLogger(nameof(CreateBackupService));
        }

        public async Task<DbBackup> BackupDatabaseAsync()
        {
            _logger.LogInformation("Started backuping of the database");
            if (!Directory.Exists(_fullBackupPath))
            {
                Directory.CreateDirectory(_fullBackupPath);
            }

            MySqlConnector.MySqlConnectionStringBuilder sqlConnectionStringBuilder = new(_mySqlConfig.DefaultConnectionString);
            string backupFileName = $"{sqlConnectionStringBuilder.Database}-{DateTime.Now:yyyy-MM-dd_HH-mm}.sql";
            string pathToBackupFile = Path.Combine(_fullBackupPath, backupFileName);
            if (File.Exists(pathToBackupFile))
            {
                _logger.LogWarning("Deleting backup file as it already exists: {pathToBackupFile}", pathToBackupFile);
                File.Delete(pathToBackupFile);
            }

            _logger.LogInformation("Backup file path: {pathToBackupFile}", pathToBackupFile);

            using MySqlConnection conn = new (_mySqlConfig.DefaultConnectionString);
            using MySqlCommand cmd = new ();
            using MySqlBackup mb = new (cmd);
            cmd.Connection = conn;
            await conn.OpenAsync();
            mb.ExportToFile(pathToBackupFile);
            await conn.CloseAsync();
            _logger.LogInformation($"Backup was created successfully");

            Stream fs = File.OpenRead(pathToBackupFile);
            return new () { Backup = fs, BackupFileName = backupFileName };
        }
    }
}
