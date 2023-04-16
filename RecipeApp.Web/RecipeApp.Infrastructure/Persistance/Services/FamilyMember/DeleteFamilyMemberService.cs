using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Repositories.ExternalUserRepository;
using RecipeApp.Domain.Repositories.FamilyMemberRepository;
using RecipeApp.Domain.Services.FamilyMemberN.DeleteFamilyMemberService;

namespace RecipeApp.Infrastructure.Persistance.Services.FamilyMemberN
{
    public class DeleteFamilyMemberService : IDeleteFamilyMemberService
    {
        private readonly IFamilyMemberRepository _familyMemberRepository;
        private readonly IExternalUserRepository _externalUserRepository;
        private readonly ILogger _logger;

        public DeleteFamilyMemberService(
            IFamilyMemberRepository familyMemberRepository,
            IExternalUserRepository externalUserRepository,
            ILoggerFactory loggerFactory)
        {
            _familyMemberRepository = familyMemberRepository;
            _externalUserRepository = externalUserRepository;
            _logger = loggerFactory?.CreateLogger(nameof(DeleteFamilyMemberService));
        }

        public async Task<bool> DeleteAsync(int userId, int familyMemberId)
        {
            try
            {
                var appUserExternal = await _externalUserRepository.GetByAppUserId(userId);
                var familyMemberToDelete = await _familyMemberRepository.Get(familyMemberId);
                if (familyMemberToDelete.ExternalUserId == appUserExternal.Id)
                {
                    // AppUser cannot delete himself from family, should delete whole family instead.
                    return false;
                }
                await _familyMemberRepository.DeleteById(familyMemberId);
                await _familyMemberRepository.Save();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred when deleting the family member {FamilyMemberId}", familyMemberId);
                return false;
            }
        }
    }
}
