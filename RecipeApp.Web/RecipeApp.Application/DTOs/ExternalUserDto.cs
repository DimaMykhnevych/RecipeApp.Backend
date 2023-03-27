namespace RecipeApp.Application.DTOs
{
    public class ExternalUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public DateTime? DOB { get; set; }

        public int? AppUserId { get; set; }
    }
}
