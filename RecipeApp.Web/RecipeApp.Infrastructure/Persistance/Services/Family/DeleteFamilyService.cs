using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Repositories.FamilyRepository;
using RecipeApp.Domain.Services.Family.DeleteFamilyService;

namespace RecipeApp.Infrastructure.Persistance.Services.Family
{
    public class DeleteFamilyService : IDeleteFamilyService
    {
        private readonly IFamilyRepository _familyRepository;
        private readonly ILogger _logger;

        public DeleteFamilyService(IFamilyRepository familyRepository, ILoggerFactory loggerFactory)
        {
            _familyRepository = familyRepository;
            _logger = loggerFactory?.CreateLogger(nameof(DeleteFamilyService));
        }

        public async Task<bool> DeleteAsync(int userId, int familyId)
        {
            IEnumerable<int> userFamilies = await _familyRepository.GetAppUserFamilyIds(userId);
            if (userFamilies != null && userFamilies.Contains(familyId))
            {
                try
                {
                    await _familyRepository.DeleteById(familyId);
                    await _familyRepository.Save();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred when deleting the family {FamilyId}", familyId);
                    return false;
                }
            }
            else if (userFamilies != null)
            {
                _logger.LogWarning("User {UserId} was trying to delete the family he didn't create", userId);
                return false;
            }

            return false;
        }
    }
}
