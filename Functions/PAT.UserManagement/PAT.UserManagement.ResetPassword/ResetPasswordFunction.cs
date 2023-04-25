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

namespace PAT.UserManagement.ResetPassword;

public class ResetPasswordFunction
{
    private readonly IUserApplication _userApplication;
    private readonly ILogger<ResetPasswordFunction> _logger;
    public ResetPasswordFunction(ILogger<ResetPasswordFunction> log,
        IUserApplication userApplication)
    {
        _logger = log;
        _userApplication = userApplication;
    }
    [FunctionName("ResetPasswordFunction")]
    [OpenApiOperation(operationId: "ReestablecerContrasena",
        Summary = "Reestablece la contraseña del usuario para uso de la aplicación",
        Description = "Reestablece la contraseña del usuario para uso de la aplicación",
        Visibility = OpenApiVisibilityType.Important)]
    [OpenApiResponseWithBody(
        statusCode: HttpStatusCode.OK,
        contentType: "text/json",
        bodyType: typeof(ResetPasswordResponse),
        Description = "Resultado del reestablecimiento de contraseña")]
    public async Task<IActionResult> Run([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "ReestablecerContrasena")] HttpRequest req)
        => await req.ProcessRequest<ResetPasswordRequest, ResetPasswordResponse>(
            _logger,
            _userApplication.ResetPassword);
}