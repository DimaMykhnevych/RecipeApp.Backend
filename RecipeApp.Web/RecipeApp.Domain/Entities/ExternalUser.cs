namespace RecipeApp.Domain.Entities
{
    public class ExternalUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public DateTime? DOB { get; set; }
        public int? AppUserId { get; set; }

        public virtual AppUser AppUser { get; set; }
        public ICollection<FamilyMember> FamilyMembers { get; set; }
    }
}
