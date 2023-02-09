using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Domain.Services.DbManagement.RestoreDb;

namespace RecipeApp.Application.Commands.DbManagement.RestoreDb
{
    public class RestoreDbCommandHandler : IRequestHandler<RestoreDbCommand, bool>
    {
        private readonly IRestoreDbService _restoreDbService;
        private readonly ILogger _logger;

        public RestoreDbCommandHandler(IRestoreDbService restoreDbService, ILoggerFactory loggerFactory)
        {
            _restoreDbService = restoreDbService;
            _logger = loggerFactory?.CreateLogger(nameof(RestoreDbCommandHandler));
        }

        public async Task<bool> Handle(RestoreDbCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling restore database request");
            ArgumentNullException.ThrowIfNull(request);

            return await _restoreDbService.RestoreDbFromFileAsync(request.RestoreFileStream);
        }
    }
}
