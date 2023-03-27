using Microsoft.AspNetCore.Identity;

namespace RecipeApp.Domain.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string Role { get; set; }
        public DateTime RegistryDate { get; set; }

        public virtual ExternalUser User { get; set; }
    }
}
