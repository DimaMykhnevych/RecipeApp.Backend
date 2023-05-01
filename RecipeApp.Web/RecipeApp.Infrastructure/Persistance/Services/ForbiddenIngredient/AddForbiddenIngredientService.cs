using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Repositories.ExternalUserRepository;
using RecipeApp.Domain.Repositories.FamilyRepository;
using RecipeApp.Domain.Repositories.ForbiddenIngredientRepository;
using RecipeApp.Domain.Services.ForbiddenIngredientN.AddForbiddenIngredientService;

namespace RecipeApp.Infrastructure.Persistance.Services.ForbiddenIngredientN
{
    public class AddForbiddenIngredientService : IAddForbiddenIngredientService
    {
        private readonly IForbiddenIngredientRepository _forbiddenIngredientRepository;
        private readonly IFamilyRepository _familyRepository;
        private readonly IExternalUserRepository _externalUserRepository;
        private readonly ILogger _logger;

        public AddForbiddenIngredientService(
            IForbiddenIngredientRepository forbiddenIngredientRepository,
            IExternalUserRepository externalUserRepository,
            IFamilyRepository familyRepository,
            ILoggerFactory loggerFactory)
        {
            _forbiddenIngredientRepository = forbiddenIngredientRepository;
            _externalUserRepository = externalUserRepository;
            _familyRepository = familyRepository;
            _logger = loggerFactory?.CreateLogger(nameof(AddForbiddenIngredientService));
        }

        public async Task<bool> AddForbiddenIngredientAsync(int appUserId, ForbiddenIngredient forbiddenIngredient)
        {
            try
            {
                ExternalUser externalUser = await _externalUserRepository.GetByAppUserId(appUserId);
                if (externalUser.Id == forbiddenIngredient.ExternalUserId)
                {
                    await _forbiddenIngredientRepository.Insert(forbiddenIngredient);
                    await _forbiddenIngredientRepository.Save();
                    return true;
                }

                IEnumerable<int> userFamilies = await _familyRepository.GetAppUserFamilyIds(appUserId);
                IEnumerable<int> externalUserFamilies = await _familyRepository.GetExternalUserFamilyIds(forbiddenIngredient.ExternalUserId);
                if (userFamilies.Intersect(externalUserFamilies).Any())
                {
                    await _forbiddenIngredientRepository.Insert(forbiddenIngredient);
                    await _forbiddenIngredientRepository.Save();
                    return true;
                }

                _logger.LogWarning("User {UserId} was trying to add forbidden ingredient to user from another family", appUserId);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured during saving users's forbidden ingredient" +
                    " (IngredientId: {IngredientId}, ExternalUserId: {ExternalUserId})", forbiddenIngredient.IngredientId, forbiddenIngredient.ExternalUserId);
                return false;
            }
        }
    }
}
