using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Repositories.FamilyRepository;
using RecipeApp.Domain.Services.Family.UpdateFamilyService;

namespace RecipeApp.Infrastructure.Persistance.Services.Family
{
    public class UpdateFamilyService : IUpdateFamilyService
    {
        private readonly IFamilyRepository _familyRepository;
        private readonly ILogger _logger;

        public UpdateFamilyService(IFamilyRepository familyRepository, ILoggerFactory loggerFactory)
        {
            _familyRepository = familyRepository;
            _logger = loggerFactory?.CreateLogger(nameof(UpdateFamilyService));
        }

        public async Task<bool> UpdateAsync(int userId, Domain.Entities.Family family)
        {
            IEnumerable<int> userFamilies = await _familyRepository.GetAppUserFamilyIds(userId);
            if (userFamilies != null && userFamilies.Contains(family.Id))
            {
                try
                {
                    await _familyRepository.Update(family);
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred when updating the family {FamilyId}", family.Id);
                    return false;
                }
            }
            else if (userFamilies != null)
            {
                _logger.LogWarning("User {UserId} was trying to update the family he didn't create", userId);
                return false;
            }

            return false;
        }
    }
}
