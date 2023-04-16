namespace RecipeApp.Application.DTOs
{
    public class FamilyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public IEnumerable<FamilyMemberDto> FamilyMembers { get; set; }
    }
}
