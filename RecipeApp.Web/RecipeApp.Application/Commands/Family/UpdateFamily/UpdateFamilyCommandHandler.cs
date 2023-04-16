using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Services.Family.UpdateFamilyService;

namespace RecipeApp.Application.Commands.Family.UpdateFamily
{
    public class UpdateFamilyCommandHandler : IRequestHandler<UpdateFamilyCommand, bool>
    {
        private readonly IUpdateFamilyService _updateFamilyService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UpdateFamilyCommandHandler(
            IUpdateFamilyService updateFamilyService,
            IMapper mapper,
            ILoggerFactory loggerFactory)
        {
            _updateFamilyService = updateFamilyService;
            _mapper = mapper;
            _logger = loggerFactory?.CreateLogger(nameof(UpdateFamilyCommandHandler));
        }

        public async Task<bool> Handle(UpdateFamilyCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling update family request");
            ArgumentNullException.ThrowIfNull(request);

            Domain.Entities.Family family = _mapper.Map<Domain.Entities.Family>(request.Family);
            return await _updateFamilyService.UpdateAsync(request.UserId, family);
        }
    }
}
