using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Services.FamilyMemberN.UpdateFamilyMemberService;

namespace RecipeApp.Application.Commands.FamilyMemberN.UpdateFamilyMember
{
    public class UpdateFamilyMemberCommandHandler : IRequestHandler<UpdateFamilyMemberCommand, bool>
    {
        private readonly IUpdateFamilyMemberService _updateFamilyMemberService;
        private readonly ILogger _logger;

        public UpdateFamilyMemberCommandHandler(
            IUpdateFamilyMemberService updateFamilyMemberService,
            ILoggerFactory loggerFactory)
        {
            _updateFamilyMemberService = updateFamilyMemberService;
            _logger = loggerFactory?.CreateLogger(nameof(UpdateFamilyMemberCommandHandler));
        }

        public async Task<bool> Handle(UpdateFamilyMemberCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling update family member request");
            ArgumentNullException.ThrowIfNull(request);

            return await _updateFamilyMemberService.UpdateFamilyMemberAsync(request.UserId, new Domain.Entities.FamilyMember
            {
                Id = request.FamilyMember.Id,
                Info = request.FamilyMember.Info,
            });
        }
    }
}
