using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Repositories.ExternalUserRepository;
using RecipeApp.Domain.Repositories.FamilyRepository;
using RecipeApp.Domain.Repositories.ForbiddenNutrientRepository;
using RecipeApp.Domain.Services.ForbiddenNutrientN.UpdateForbiddenNutrientService;

namespace RecipeApp.Infrastructure.Persistance.Services.ForbiddenNutrientN
{
    public class UpdateForbiddenNutrientService : IUpdateForbiddenNutrientService
    {
        private readonly IForbiddenNutrientRepository _forbiddenNutrientRepository;
        private readonly IFamilyRepository _familyRepository;
        private readonly IExternalUserRepository _externalUserRepository;
        private readonly ILogger _logger;

        public UpdateForbiddenNutrientService(
            IForbiddenNutrientRepository forbiddenNutrientRepository,
            IExternalUserRepository externalUserRepository,
            IFamilyRepository familyRepository,
            ILoggerFactory loggerFactory)
        {
            _forbiddenNutrientRepository = forbiddenNutrientRepository;
            _externalUserRepository = externalUserRepository;
            _familyRepository = familyRepository;
            _logger = loggerFactory?.CreateLogger(nameof(UpdateForbiddenNutrientService));
        }

        public async Task<bool> UpdateForbiddenNutrientAsync(int appUserId, ForbiddenNutrient forbiddenNutrient)
        {
            try
            {
                ExternalUser externalUser = await _externalUserRepository.GetByAppUserId(appUserId);
                ForbiddenNutrient forbiddenNutrientToUpdate = await _forbiddenNutrientRepository.Get(forbiddenNutrient.Id);
                if (forbiddenNutrient.RequiredPercentageOfDailyNeeds == null
                    || forbiddenNutrient.RequiredPercentageOfDailyNeeds < 0)
                {
                    _logger.LogWarning("Cannot update forbidden nutrient {ForbiddenNutrientId}," +
                        " because RequiredPercentageOfDailyNeeds is null or less than 0", forbiddenNutrient.Id);
                    return false;
                }

                forbiddenNutrientToUpdate.RequiredPercentageOfDailyNeeds = forbiddenNutrient.RequiredPercentageOfDailyNeeds;

                if (externalUser.Id == forbiddenNutrientToUpdate.ExternalUserId)
                {
                    await _forbiddenNutrientRepository.Update(forbiddenNutrientToUpdate);
                    await _forbiddenNutrientRepository.Save();
                    return true;
                }

                IEnumerable<int> userFamilies = await _familyRepository.GetAppUserFamilyIds(appUserId);
                IEnumerable<int> externalUserFamilies = await _familyRepository.GetExternalUserFamilyIds(forbiddenNutrientToUpdate.ExternalUserId);
                if (userFamilies.Intersect(externalUserFamilies).Any())
                {
                    await _forbiddenNutrientRepository.Update(forbiddenNutrientToUpdate);
                    await _forbiddenNutrientRepository.Save();
                    return true;
                }

                _logger.LogWarning("User {UserId} was trying to delete forbidden nutrient to user from another family", appUserId);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured during updating users's forbidden nutrient" +
                    " (ForbiddenNutrientId: {ForbiddenNutrientId}, UserId: {UserId})", forbiddenNutrient.Id, appUserId);
                return false;
            }
        }
    }
}
