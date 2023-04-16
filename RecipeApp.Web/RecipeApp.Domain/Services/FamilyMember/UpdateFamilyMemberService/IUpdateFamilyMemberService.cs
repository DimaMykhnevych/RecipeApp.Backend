using RecipeApp.Domain.Entities;

namespace RecipeApp.Domain.Services.FamilyMemberN.UpdateFamilyMemberService
{
    public interface IUpdateFamilyMemberService
    {
        Task<bool> UpdateFamilyMemberAsync(int userId, FamilyMember familyMember);
    }
}
