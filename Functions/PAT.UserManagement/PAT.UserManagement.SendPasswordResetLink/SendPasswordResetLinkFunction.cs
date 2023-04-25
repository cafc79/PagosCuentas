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

namespace PAT.UserManagement.SendPasswordResetLink;

public class SendPasswordResetLinkFunction
{
    private readonly IUserApplication _userApplication;
    private readonly ILogger<SendPasswordResetLinkFunction> _logger;
    public SendPasswordResetLinkFunction(ILogger<SendPasswordResetLinkFunction> log,
        IUserApplication userApplication)
    {
        _logger = log;
        _userApplication = userApplication;
    }
    [FunctionName("SendPasswordResetLinkFunction")]
    [OpenApiOperation(operationId: "EnviarEmailReestablecerContrasena",
        Summary = "Envio de liga para el reestablecer de contraseña",
        Description = "Envio de liga para reestablecer de contraseña al usuario para uso de la aplicación",
        Visibility = OpenApiVisibilityType.Important)]
    [OpenApiResponseWithBody(
        statusCode: HttpStatusCode.OK,
        contentType: "text/json",
        bodyType: typeof(ResetPasswordResponse),
        Description = "Resultado del envío de liga para reestablecer de contraseña")]
    public async Task<IActionResult> SendPasswordResetLink([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "EnviarEmailReestablecerContrasena")] HttpRequest req)
        => await req.ProcessRequest<EmailDataRequest, ResetPasswordResponse>(
            _logger,
            _userApplication.SendPasswordResetLink);

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
    public async Task<IActionResult> ResetPassword([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "ReestablecerContrasena")] HttpRequest req)
      => await req.ProcessRequest<ResetPasswordRequest, ResetPasswordResponse>(
          _logger,
          _userApplication.ResetPassword);
}
