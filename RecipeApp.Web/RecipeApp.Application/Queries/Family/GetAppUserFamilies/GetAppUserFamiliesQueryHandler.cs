using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeApp.Application.DTOs;
using RecipeApp.Domain.Context;
using RecipeApp.Domain.Entities;

namespace RecipeApp.Application.Queries.Family.GetAppUserFamilies
{
    public class GetAppUserFamiliesQueryHandler : IRequestHandler<GetAppUserFamiliesQuery, GetFamiliesDto>
    {
        private readonly IRecipeAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetAppUserFamiliesQueryHandler(IRecipeAppDbContext context, IMapper mapper, ILoggerFactory loggerFactory)
        {
            _context = context;
            _mapper = mapper;
            _logger = loggerFactory?.CreateLogger(nameof(GetAppUserFamiliesQueryHandler));
        }

        public async Task<GetFamiliesDto> Handle(GetAppUserFamiliesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling get families request");
            ArgumentNullException.ThrowIfNull(request);

            ExternalUser appUserExternal = await _context.ExternalUsers.FirstAsync(u => u.AppUserId == request.UserId);
            List<FamilyMember> families = await _context.FamilyMembers
                .Include(fm => fm.ExternalUser)
                .AsNoTracking()
                .Include(fm => fm.Family)
                .AsNoTracking()
                .Where(fm => fm.ExternalUserId == appUserExternal.Id)
                .ToListAsync();

            return new GetFamiliesDto
            {
                Families = _mapper.Map<IEnumerable<FamilyDto>>(families.Select(fm => fm.Family)),
                ResultsAmount = families.Count()
            };
        }
    }
}
