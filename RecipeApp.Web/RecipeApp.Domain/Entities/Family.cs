namespace RecipeApp.Domain.Entities
{
    public class Family
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }

        public ICollection<FamilyMember> FamilyMembers { get; set; }
    }
}
