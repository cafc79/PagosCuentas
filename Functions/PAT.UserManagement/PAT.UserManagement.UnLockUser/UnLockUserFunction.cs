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

namespace PAT.UserManagement.UnlockUser;

public class UnlockUserFunction
{
    private readonly IUserApplication _userApplication;
    private readonly ILogger<UnlockUserFunction> _logger;
    public UnlockUserFunction(ILogger<UnlockUserFunction> log,
        IUserApplication userApplication)
    {
        _logger = log;
        _userApplication = userApplication;
    }
    [FunctionName("UnlockUserFunction")]
    [OpenApiOperation(operationId: "DesbloquearUsuario",
        Summary = "Desbloquea al usuario para uso de la aplicación",
        Description = "Desbloquea al usuario para uso de la aplicación",
        Visibility = OpenApiVisibilityType.Important)]
    [OpenApiResponseWithBody(
        statusCode: HttpStatusCode.OK,
        contentType: "text/json",
        bodyType: typeof(LockUnlockUserResponse),
        Description = "Resultado del Desbloqueo")]
    public async Task<IActionResult> Run([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "DesbloquearUsuario")] HttpRequest req)
        => await req.ProcessRequest<EmailDataRequest, LockUnlockUserResponse>(
            _logger,
            _userApplication.UnlockUser);
}