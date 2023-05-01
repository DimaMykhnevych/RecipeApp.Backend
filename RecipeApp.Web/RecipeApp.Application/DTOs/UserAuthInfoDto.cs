namespace RecipeApp.Application.DTOs
{
    public class UserAuthInfoDto
    {
        public int UserId { get; set; }
        public int ExternalUserId { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public DateTime RegistryDate { get; set; }
        public string Email { get; set; }
    }
}
