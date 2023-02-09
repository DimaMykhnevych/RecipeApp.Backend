using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeApp.Application.Commands.DbManagement.CreateBackup;
using RecipeApp.Application.Commands.DbManagement.RestoreDb;
using RecipeApp.Application.DTOs;
using RecipeApp.Application.Queries.AppLogs.GetLogs;
using RecipeApp.Domain.Constants;
using RecipeApp.Domain.Enums;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace RecipeApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = Role.Admin)]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("logs-plain-text")]
        [SwaggerOperation(Summary = "Gets logs for given date in text representation")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(LogsDto))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User was not authorized")]
        [SwaggerResponse((int)HttpStatusCode.Forbidden, Description = "User is not administrator")]
        public async Task<IActionResult> GetLogs([FromQuery] DateTime date)
        {
            LogsDto logs = await _mediator.Send(new GetLogsQuery { Date = date, GetLogsMode = GetLogsMode.PlainText });
            return Ok(logs);
        }

        [HttpGet("logs-file")]
        [SwaggerOperation(Summary = "Gets logs for given date in file representation")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Stream))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User was not authorized")]
        [SwaggerResponse((int)HttpStatusCode.Forbidden, Description = "User is not administrator")]
        public async Task<IActionResult> GetFileLogs([FromQuery] DateTime date)
        {
            LogsDto logs = await _mediator.Send(new GetLogsQuery { Date = date, GetLogsMode = GetLogsMode.File });
            return File(logs.LogsStream, "application/octet-stream", logs.FileName);
        }

        [HttpPost("backup-database")]
        [SwaggerOperation(Summary = "Creates backup of the database and returns backup file as a result")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Stream))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User was not authorized")]
        [SwaggerResponse((int)HttpStatusCode.Forbidden, Description = "User is not administrator")]
        public async Task<IActionResult> BackupDatabase()
        {
            DbBackupDto result = await _mediator.Send(new CreateBackupCommand());
            return File(result.Backup, "application/octet-stream", result.BackupFileName);
        }

        [HttpPost("restore-database")]
        [SwaggerOperation(Summary = "Restore database from a file", Description = "True = restore was completed successfully, false = database restore was failed")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(bool))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Restore file was not provided")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "User was not authorized")]
        [SwaggerResponse((int)HttpStatusCode.Forbidden, Description = "User is not administrator")]
        public async Task<IActionResult> RestoreDatabase(IFormFile file)
        {
            if (file == null && !HttpContext.Request.Form.Files.Any())
            {
                return BadRequest();
            }

            file ??= HttpContext.Request.Form.Files[0];

            using MemoryStream ms = new();
            file.CopyTo(ms);

            bool restoreResult = await _mediator.Send(new RestoreDbCommand { RestoreFileStream = ms });
            return Ok(restoreResult);
        }
    }
}
