namespace RecipeApp.Application.DTOs
{
    public class FamilyMemberDto
    {
        public int Id { get; set; }
        public int ExternalUserId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public DateTime? DOB { get; set; }
        public string Info { get; set; }
    }
}
