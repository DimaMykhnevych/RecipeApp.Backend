using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Repositories.FamilyMemberRepository;
using RecipeApp.Domain.Repositories.FamilyRepository;
using RecipeApp.Domain.Services.FamilyMemberN.UpdateFamilyMemberService;

namespace RecipeApp.Infrastructure.Persistance.Services.FamilyMemberN
{
    public class UpdateFamilyMemberService : IUpdateFamilyMemberService
    {
        private readonly IFamilyMemberRepository _familyMemberRepository;
        private readonly IFamilyRepository _familyRepository;
        private readonly ILogger _logger;

        public UpdateFamilyMemberService(
            IFamilyMemberRepository familyMemberRepository,
            IFamilyRepository familyRepository,
            ILoggerFactory loggerFactory)
        {
            _familyMemberRepository = familyMemberRepository;
            _familyRepository = familyRepository;
            _logger = loggerFactory?.CreateLogger(nameof(UpdateFamilyMemberService));
        }

        public async Task<bool> UpdateFamilyMemberAsync(int userId, FamilyMember familyMember)
        {
            IEnumerable<int> userFamilies = await _familyRepository.GetAppUserFamilyIds(userId);
            var familyMemberToUpdate = await _familyMemberRepository.Get(familyMember.Id);
            if (familyMemberToUpdate == null)
            {
                return false;
            }

            if (userFamilies != null && userFamilies.Contains(familyMemberToUpdate.FamilyId))
            {
                try
                {
                    familyMemberToUpdate.Info = familyMember.Info;
                    await _familyMemberRepository.Update(familyMemberToUpdate);
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred when updating the family member {FamilyMemberUsername}", familyMember.ExternalUser.UserName);
                    return false;
                }
            }
            else if (userFamilies != null)
            {
                _logger.LogWarning("User {UserId} was trying to update the family member he didn't create", userId);
                return false;
            }

            return false;
        }
    }
}
