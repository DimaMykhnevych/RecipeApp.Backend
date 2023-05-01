using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Repositories.ExternalUserRepository;
using RecipeApp.Domain.Repositories.FamilyRepository;
using RecipeApp.Domain.Repositories.ForbiddenIngredientRepository;
using RecipeApp.Domain.Services.ForbiddenIngredientN.DeleteForbiddenIngredientService;

namespace RecipeApp.Infrastructure.Persistance.Services.ForbiddenIngredientN
{
    public class DeleteForbiddenIngredientService : IDeleteForbiddenIngredientService
    {
        private readonly IForbiddenIngredientRepository _forbiddenIngredientRepository;
        private readonly IFamilyRepository _familyRepository;
        private readonly IExternalUserRepository _externalUserRepository;
        private readonly ILogger _logger;

        public DeleteForbiddenIngredientService(
            IForbiddenIngredientRepository forbiddenIngredientRepository,
            IExternalUserRepository externalUserRepository,
            IFamilyRepository familyRepository,
            ILoggerFactory loggerFactory)
        {
            _forbiddenIngredientRepository = forbiddenIngredientRepository;
            _externalUserRepository = externalUserRepository;
            _familyRepository = familyRepository;
            _logger = loggerFactory?.CreateLogger(nameof(DeleteForbiddenIngredientService));
        }

        public async Task<bool> DeleteForbiddenIngredientAsync(int appUserId, int forbiddenIngredientId)
        {
            try
            {
                ExternalUser externalUser = await _externalUserRepository.GetByAppUserId(appUserId);
                ForbiddenIngredient forbiddenIngredientToDelete = await _forbiddenIngredientRepository.Get(forbiddenIngredientId);
                if (externalUser.Id == forbiddenIngredientToDelete.ExternalUserId)
                {
                    _forbiddenIngredientRepository.Delete(forbiddenIngredientToDelete);
                    await _forbiddenIngredientRepository.Save();
                    return true;
                }

                IEnumerable<int> userFamilies = await _familyRepository.GetAppUserFamilyIds(appUserId);
                IEnumerable<int> externalUserFamilies = await _familyRepository.GetExternalUserFamilyIds(forbiddenIngredientToDelete.ExternalUserId);
                if (userFamilies.Intersect(externalUserFamilies).Any())
                {
                    _forbiddenIngredientRepository.Delete(forbiddenIngredientToDelete);
                    await _forbiddenIngredientRepository.Save();
                    return true;
                }

                _logger.LogWarning("User {UserId} was trying to delete forbidden ingredient to user from another family", appUserId);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured during saving users's forbidden ingredient" +
                    " (ForbiddenIngredientId: {ForbiddenIngredientId}, UserId: {UserId})", forbiddenIngredientId, appUserId);
                return false;
            }
        }
    }
}
