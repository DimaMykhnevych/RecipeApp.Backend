using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeApp.Application.DTOs;
using RecipeApp.Domain.Context;
using RecipeApp.Domain.Repositories.FamilyRepository;

namespace RecipeApp.Application.Queries.Family.GetAppUserFamilies
{
    public class GetAppUserFamiliesQueryHandler : IRequestHandler<GetAppUserFamiliesQuery, GetFamiliesDto>
    {
        private readonly IRecipeAppDbContext _context;
        private readonly IFamilyRepository _familyRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetAppUserFamiliesQueryHandler(
            IRecipeAppDbContext context,
            IFamilyRepository familyRepository,
            IMapper mapper,
            ILoggerFactory loggerFactory)
        {
            _context = context;
            _familyRepository = familyRepository;
            _mapper = mapper;
            _logger = loggerFactory?.CreateLogger(nameof(GetAppUserFamiliesQueryHandler));
        }

        public async Task<GetFamiliesDto> Handle(GetAppUserFamiliesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling get families request");
            ArgumentNullException.ThrowIfNull(request);

            IEnumerable<int> appUserFamilies = await _familyRepository.GetAppUserFamilyIds(request.UserId);
            List<Domain.Entities.Family> families = await _context.Families
                .Include(fm => fm.FamilyMembers)
                .ThenInclude(fm => fm.ExternalUser)
                .AsNoTracking()
                .Where(fm => appUserFamilies.Contains(fm.Id))
                .ToListAsync(cancellationToken);

            return new GetFamiliesDto
            {
                Families = _mapper.Map<IEnumerable<FamilyDto>>(families),
                ResultsAmount = families.Count()
            };
        }
    }
}
