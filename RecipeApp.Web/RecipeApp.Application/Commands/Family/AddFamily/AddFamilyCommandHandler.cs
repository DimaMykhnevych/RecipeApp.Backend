using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Repositories.FamilyRepository;

namespace RecipeApp.Application.Commands.Family.AddFamily
{
    public class AddFamilyCommandHandler : IRequestHandler<AddFamilyCommand, bool>
    {
        private readonly IFamilyRepository _familyRepository;
        private readonly ILogger _logger;

        public AddFamilyCommandHandler(
            IFamilyRepository familyRepository,
            ILoggerFactory loggerFactory)
        {
            _familyRepository = familyRepository;
            _logger = loggerFactory?.CreateLogger(nameof(AddFamilyCommandHandler));
        }

        public async Task<bool> Handle(AddFamilyCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling add family request");
            ArgumentNullException.ThrowIfNull(request);

            try
            {
                Domain.Entities.Family family = new()
                {
                    Name = request.Family.Name,
                    Info = request.Family.Info,
                };

                await _familyRepository.InsertAppUserFamily(request.UserId,family);
                await _familyRepository.Save();
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occured during adding family");
                return false;
            }
        }
    }
}
