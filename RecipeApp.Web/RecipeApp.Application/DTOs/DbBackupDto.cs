namespace RecipeApp.Application.DTOs
{
    public class DbBackupDto
    {
        public Stream Backup { get; set; }
        public string BackupFileName { get; set; }
    }
}
