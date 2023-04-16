using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Exceptions;
using RecipeApp.Domain.Repositories.ExternalUserRepository;
using RecipeApp.Domain.Repositories.FamilyMemberRepository;
using RecipeApp.Domain.Repositories.FamilyRepository;
using RecipeApp.Domain.Services.FamilyMemberN.AddFamilyMemberService;

namespace RecipeApp.Infrastructure.Persistance.Services.FamilyMemberN
{
    public class AddFamilyMemberService : IAddFamilyMemberService
    {
        private readonly IExternalUserRepository _externalUserRepository;
        private readonly IFamilyMemberRepository _familyMemberRepository;
        private readonly IFamilyRepository _familyRepository;
        private readonly ILogger _logger;

        public AddFamilyMemberService(
            IExternalUserRepository externalUserRepository,
            IFamilyMemberRepository familyMemberRepository,
            IFamilyRepository familyRepository,
            ILoggerFactory loggerFactory)
        {
            _externalUserRepository = externalUserRepository;
            _familyMemberRepository = familyMemberRepository;
            _familyRepository = familyRepository;
            _logger = loggerFactory?.CreateLogger(nameof(AddFamilyMemberService));
        }

        public async Task<bool> AddFamilyMemberAsync(int userId, FamilyMember familyMember)
        {
            IEnumerable<int> userFamilies = await _familyRepository.GetAppUserFamilyIds(userId);
            if (userFamilies != null && userFamilies.Contains(familyMember.FamilyId))
            {
                if (familyMember.ExternalUser == null && familyMember.ExternalUserId != 0)
                {
                    var currentFamilyMembers = await _familyRepository.GetFamilyMembers(familyMember.FamilyId);
                    if (currentFamilyMembers != null && currentFamilyMembers.Any())
                    {
                        var duplicatedMember = currentFamilyMembers.FirstOrDefault(fm => fm.ExternalUserId == familyMember.ExternalUserId);
                        if (duplicatedMember != null)
                        {
                            _logger.LogWarning("User {UserId} was trying to add duplicated family member with Id: {FamilyMemberId}", userId, familyMember.ExternalUserId);
                            return false;
                        }
                    }

                    await _familyMemberRepository.Insert(familyMember);
                    await _familyMemberRepository.Save();
                    return true;
                }

                ExternalUser existingMember = await _externalUserRepository.GetByUsername(familyMember.ExternalUser.UserName);
                if (existingMember != null)
                {
                    throw new UsernameAlreadyTakenException();
                }

                await _familyMemberRepository.Insert(familyMember);
                await _familyMemberRepository.Save();
                return true;
            }
            else if (userFamilies != null)
            {
                _logger.LogWarning("User {UserId} was trying to add the family member to the family he didn't create", userId);
                return false;
            }

            return false;
        }
    }
}
