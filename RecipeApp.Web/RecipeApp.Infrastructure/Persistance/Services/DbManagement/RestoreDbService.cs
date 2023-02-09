using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using RecipeApp.Domain.Services.DbManagement.RestoreDb;
using RecipeApp.Web.Options;

namespace RecipeApp.Infrastructure.Persistance.Services.DbManagement
{
    public class RestoreDbService : IRestoreDbService
    {
        private readonly MySqlConfigOptions _mySqlConfig;
        private readonly ILogger _logger;

        public RestoreDbService(IOptions<MySqlConfigOptions> options, ILoggerFactory loggerFactory)
        {
            _mySqlConfig = options.Value;
            _logger = loggerFactory?.CreateLogger(nameof(CreateBackupService));
        }

        public async Task<bool> RestoreDbFromFileAsync(Stream fileStream)
        {
            _logger.LogInformation("Started restoring the database");
            using MySqlConnection conn = new (_mySqlConfig.DefaultConnectionString);
            using MySqlCommand cmd = new ();
            using MySqlBackup mb = new (cmd);
            cmd.Connection = conn;
            await conn.OpenAsync();
            try
            {
                mb.ImportFromStream(fileStream);
            }
            catch (Exception ex)
            {
                await conn.CloseAsync();
                _logger.LogError(ex, "An error occurred during restoring the database");
                return false;
            }

            await conn.CloseAsync();
            return true;
        }
    }
}
