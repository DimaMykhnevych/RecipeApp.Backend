using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Repositories.FamilyMemberRepository;
using RecipeApp.Infrastructure.Persistance.Context;

namespace RecipeApp.Infrastructure.Persistance.Repositories.FamilyMemberRepository
{
    public class FamilyMemberRepository : Repository<FamilyMember>, IFamilyMemberRepository
    {
        public FamilyMemberRepository(RecipeAppDbContext context) : base(context)
        {
        }
    }
}
