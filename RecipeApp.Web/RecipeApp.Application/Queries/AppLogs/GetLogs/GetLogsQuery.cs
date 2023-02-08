using MediatR;
using RecipeApp.Application.DTOs;
using RecipeApp.Domain.Enums;

namespace RecipeApp.Application.Queries.AppLogs.GetLogs
{
    public class GetLogsQuery : IRequest<LogsDto>
    {
        public GetLogsMode GetLogsMode { get; set; }
        public DateTime Date { get; set; }
    }
}
