using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using PAT.Application.Interfaces;
using PAT.Application.Models.UserManagement;
using PAT.Common.Functions;
using System.Net;
using System.Threading.Tasks;

namespace PAT.UserManagement.LockUser;

public class LockUserFunction
{
    private readonly IUserApplication _userApplication;
    private readonly ILogger<LockUserFunction> _logger;
    public LockUserFunction(ILogger<LockUserFunction> log,
        IUserApplication userApplication)
    {
        _logger = log;
        _userApplication = userApplication;
    }
    [FunctionName("LockUserFunction")]
    [OpenApiOperation(operationId: "BloquearUsuario",
        Summary = "Bloquea al usuario para uso de la aplicación",
        Description = "Bloquea al usuario para uso de la aplicación",
        Visibility = OpenApiVisibilityType.Important)]
    [OpenApiResponseWithBody(
        statusCode: HttpStatusCode.OK,
        contentType: "text/json",
        bodyType: typeof(LockUnlockUserResponse),
        Description = "Resultado del bloqueo del usuario")]
    public async Task<IActionResult> Run([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "BloquearUsuario")] HttpRequest req)
        => await req.ProcessRequest<EmailDataRequest, LockUnlockUserResponse>(
            _logger,
            _userApplication.LockUser);
}