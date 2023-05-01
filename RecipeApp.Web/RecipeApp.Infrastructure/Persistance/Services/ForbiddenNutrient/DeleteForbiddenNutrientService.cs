using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Repositories.ExternalUserRepository;
using RecipeApp.Domain.Repositories.FamilyRepository;
using RecipeApp.Domain.Repositories.ForbiddenNutrientRepository;
using RecipeApp.Domain.Services.ForbiddenNutrientN.DeleteForbiddenNutrientService;

namespace RecipeApp.Infrastructure.Persistance.Services.ForbiddenNutrientN
{
    public class DeleteForbiddenNutrientService : IDeleteForbiddenNutrientService
    {
        private readonly IForbiddenNutrientRepository _forbiddenNutrientRepository;
        private readonly IFamilyRepository _familyRepository;
        private readonly IExternalUserRepository _externalUserRepository;
        private readonly ILogger _logger;

        public DeleteForbiddenNutrientService(
            IForbiddenNutrientRepository forbiddenNutrientRepository,
            IExternalUserRepository externalUserRepository,
            IFamilyRepository familyRepository,
            ILoggerFactory loggerFactory)
        {
            _forbiddenNutrientRepository = forbiddenNutrientRepository;
            _externalUserRepository = externalUserRepository;
            _familyRepository = familyRepository;
            _logger = loggerFactory?.CreateLogger(nameof(DeleteForbiddenNutrientService));
        }

        public async Task<bool> DeleteForbiddenNutrientAsync(int appUserId, int forbiddenNutrientId)
        {
            try
            {
                ExternalUser externalUser = await _externalUserRepository.GetByAppUserId(appUserId);
                ForbiddenNutrient forbiddenNutrientToDelete = await _forbiddenNutrientRepository.Get(forbiddenNutrientId);
                if (externalUser.Id == forbiddenNutrientToDelete.ExternalUserId)
                {
                    _forbiddenNutrientRepository.Delete(forbiddenNutrientToDelete);
                    await _forbiddenNutrientRepository.Save();
                    return true;
                }

                IEnumerable<int> userFamilies = await _familyRepository.GetAppUserFamilyIds(appUserId);
                IEnumerable<int> externalUserFamilies = await _familyRepository.GetExternalUserFamilyIds(forbiddenNutrientToDelete.ExternalUserId);
                if (userFamilies.Intersect(externalUserFamilies).Any())
                {
                    _forbiddenNutrientRepository.Delete(forbiddenNutrientToDelete);
                    await _forbiddenNutrientRepository.Save();
                    return true;
                }

                _logger.LogWarning("User {UserId} was trying to delete forbidden nutrient to user from another family", appUserId);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured during deleting users's forbidden nutrient" +
                    " (ForbiddenNutrientId: {ForbiddenNutrientId}, UserId: {UserId})", forbiddenNutrientId, appUserId);
                return false;
            }
        }
    }
}
