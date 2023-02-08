using MediatR;
using Microsoft.Extensions.Logging;
using RecipeApp.Application.DTOs;
using RecipeApp.Domain.Enums;
using RecipeApp.Domain.Services.AppLogs.GetLogs;

namespace RecipeApp.Application.Queries.AppLogs.GetLogs
{
    public class GetLogsQueryHandler : IRequestHandler<GetLogsQuery, LogsDto>
    {
        private readonly IGetLogsService _getLogsService;
        private readonly ILogger _logger;

        public GetLogsQueryHandler(IGetLogsService getLogsService, ILoggerFactory loggerFactory)
        {
            _getLogsService = getLogsService;
            _logger = loggerFactory?.CreateLogger(nameof(GetLogsQueryHandler));
        }

        public async Task<LogsDto> Handle(GetLogsQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            _logger.LogInformation("Handling get logs request. Mode = {mode}", request.GetLogsMode.ToString());

            LogsDto logsResult = new () { Date = request.Date };

            switch (request.GetLogsMode)
            {
                case GetLogsMode.PlainText:
                    var plainTextResult = await _getLogsService.GetPlainTextLogs(request.Date);
                    logsResult.PlainTextContent = plainTextResult.Item2;
                    logsResult.FileName = plainTextResult.Item1;
                    break;
                case GetLogsMode.File:
                    var fileResult = await _getLogsService.GetFileLogs(request.Date);
                    logsResult.LogsStream = fileResult.Item2;
                    logsResult.FileName = fileResult.Item1;
                    break;
                default:
                    throw new ArgumentException("Unsupported get logs method", nameof(request.GetLogsMode));
            }

            return logsResult;
        }
    }
}
