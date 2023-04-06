namespace RecipeApp.Domain.Entities
{
    public class FamilyMember
    {
        public int Id { get; set; }
        public string Info { get; set; }
        public int FamilyId { get; set; }
        public int ExternalUserId { get; set; }

        public ExternalUser ExternalUser { get; set; }
        public Family Family { get; set; }
    }
}
