namespace RecipeApp.Domain.Services.FamilyMemberN.DeleteFamilyMemberService
{
    public interface IDeleteFamilyMemberService
    {
        Task<bool> DeleteAsync(int userId, int familyMemberId);
    }
}
