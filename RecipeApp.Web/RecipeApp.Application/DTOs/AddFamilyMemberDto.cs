namespace RecipeApp.Application.DTOs
{
    public class AddFamilyMemberDto
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public DateTime? DOB { get; set; }
        public string Info { get; set; }
        public int? ExternalUserId { get; set; }
        public int FamilyId { get; set; }
    }
}
