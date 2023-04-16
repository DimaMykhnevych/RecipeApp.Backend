using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Services.FamilyMemberN.AddFamilyMemberService
{
    public interface IAddFamilyMemberService
    {
        Task<bool> AddFamilyMemberAsync(int userId, FamilyMember familyMember);
    }
}
