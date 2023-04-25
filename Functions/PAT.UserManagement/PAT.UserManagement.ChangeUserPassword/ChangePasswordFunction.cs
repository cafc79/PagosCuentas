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

namespace PAT.UserManagement.ChangeUserPassword;

public class ChangePasswordFunction
{
    private readonly IUserApplication _userApplication;
    private readonly ILogger<ChangePasswordFunction> _logger;
    public ChangePasswordFunction(ILogger<ChangePasswordFunction> log,
        IUserApplication userApplication)
    {
        _logger = log;
        _userApplication = userApplication;
    }
    [FunctionName("ChangeUserPasswordFunction")]
    [OpenApiOperation(operationId: "CambiarContrasena",
        Summary = "Cambia contraseña al usuario para uso de la aplicación",
        Description = "Cambia la contraseña al usuario para uso de la aplicación",
        Visibility = OpenApiVisibilityType.Important)]
    [OpenApiResponseWithBody(
        statusCode: HttpStatusCode.OK,
        contentType: "text/json",
        bodyType: typeof(ChangePasswordResponse),
        Description = "Resultado del cambio de contraseña")]
    public async Task<IActionResult> Run([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "CambiarContrasena")] HttpRequest req)
        => await req.ProcessRequest<ChangePasswordRequest, ChangePasswordResponse>(
            _logger,
            _userApplication.ChangeUserPassword);
}