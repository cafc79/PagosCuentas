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
        Summary = "Envio de liga para el reestablecer de contrase�a",
        Description = "Envio de liga para reestablecer de contrase�a al usuario para uso de la aplicaci�n",
        Visibility = OpenApiVisibilityType.Important)]
    [OpenApiResponseWithBody(
        statusCode: HttpStatusCode.OK,
        contentType: "text/json",
        bodyType: typeof(ResetPasswordResponse),
        Description = "Resultado del env�o de liga para reestablecer de contrase�a")]
    public async Task<IActionResult> SendPasswordResetLink([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "EnviarEmailReestablecerContrasena")] HttpRequest req)
        => await req.ProcessRequest<EmailDataRequest, ResetPasswordResponse>(
            _logger,
            _userApplication.SendPasswordResetLink);

    [FunctionName("ResetPasswordFunction")]
    [OpenApiOperation(operationId: "ReestablecerContrasena",
      Summary = "Reestablece la contrase�a del usuario para uso de la aplicaci�n",
      Description = "Reestablece la contrase�a del usuario para uso de la aplicaci�n",
      Visibility = OpenApiVisibilityType.Important)]
    [OpenApiResponseWithBody(
      statusCode: HttpStatusCode.OK,
      contentType: "text/json",
      bodyType: typeof(ResetPasswordResponse),
      Description = "Resultado del reestablecimiento de contrase�a")]
    public async Task<IActionResult> ResetPassword([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "ReestablecerContrasena")] HttpRequest req)
      => await req.ProcessRequest<ResetPasswordRequest, ResetPasswordResponse>(
          _logger,
          _userApplication.ResetPassword);
}
