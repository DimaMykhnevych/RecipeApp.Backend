using Microsoft.EntityFrameworkCore;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Repositories.FamilyRepository;
using RecipeApp.Infrastructure.Persistance.Context;

namespace RecipeApp.Infrastructure.Persistance.Repositories.FamilyRepository
{
    public class FamilyRepository : Repository<Family>, IFamilyRepository
    {
        public FamilyRepository(RecipeAppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<int>> GetAppUserFamilyIds(int appUserId)
        {
            var appUserExternal = await context.ExternalUsers.FirstAsync(u => u.AppUserId == appUserId);
            var familyMembers = await context.FamilyMembers
                .Where(fm => fm.ExternalUserId == appUserExternal.Id)
                .ToListAsync();

            return familyMembers.Select(fm => fm.FamilyId);
        }

        public async Task<IEnumerable<int>> GetExternalUserFamilyIds(int externalUserId)
        {
            var familyMembers = await context.FamilyMembers
                .Where(fm => fm.ExternalUserId == externalUserId)
                .ToListAsync();

            return familyMembers.Select(fm => fm.FamilyId);
        }

        public async Task<IEnumerable<FamilyMember>> GetFamilyMembers(int familyId)
        {
            return await context.FamilyMembers.Where(fm => fm.FamilyId == familyId).ToListAsync();
        }

        public async Task InsertAppUserFamily(int appUserId, Family family)
        {
            var appUserExternal = await context.ExternalUsers.FirstAsync(u => u.AppUserId == appUserId);
            family.FamilyMembers ??= new List<FamilyMember>();
            family.FamilyMembers.Add(new()
            {
                ExternalUserId = appUserExternal.Id,
                Info = $"Creator of {family.Name} family"
            });

            await context.AddAsync(family);
        }
    }
}
