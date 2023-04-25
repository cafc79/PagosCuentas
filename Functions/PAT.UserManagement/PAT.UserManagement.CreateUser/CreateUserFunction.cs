using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PAT.Application.Interfaces;
using PAT.Application.Models.UserManagement;
using PAT.Common.Functions;
using System.Net;
using System.Threading.Tasks;

namespace PAT.UserManagement.CreateUser;

public class CreateUserFunction
{
    private readonly IUserApplication _userApplication;
    private readonly ILogger<CreateUserFunction> _logger;

    public CreateUserFunction(
        ILogger<CreateUserFunction> log,
        IUserApplication userApplication)
    {
        _logger = log;
        _userApplication = userApplication;
    }

    [FunctionName("CreateUserFunction")]
    [OpenApiOperation(operationId: "CrearUsuario",
        Summary = "Crea un usuario y env�a un email de confirmaci�n",
        Description = "Crea un usuario y env�a un email de confirmaci�n",
        Visibility = OpenApiVisibilityType.Important)]
    [OpenApiResponseWithBody(
        statusCode: HttpStatusCode.OK,
        contentType: "text/json",
        bodyType: typeof(CreateUserResponse),
        Description = "Resultado de la creaci�n del usuario")]
    public async Task<IActionResult> Create([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "CrearUsuario")] HttpRequest req)
        => await req.ProcessRequest<CreateUserRequest, CreateUserResponse>(
            _logger,
            _userApplication.CreateUser);

    [FunctionName("ConfirmUserFunction")]
    [OpenApiOperation(operationId: "ConfirmarUsuario",
      Summary = "Confirma el email del usuario para uso de la aplicaci�n",
      Description = "Confirma el email del usuario para uso de la aplicaci�n",
      Visibility = OpenApiVisibilityType.Important)]
    [OpenApiResponseWithBody(
      statusCode: HttpStatusCode.OK,
      contentType: "text/json",
      bodyType: typeof(ConfirmUserResponse),
      Description = "Resultado de la confirmaci�n")]
    public async Task<IActionResult> Confirm([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "ConfirmarUsuario")] HttpRequest req)
      => await req.ProcessRequest<ConfirmUserRequest, ConfirmUserResponse>(
          _logger,
          _userApplication.ConfirmUser);

    [FunctionName("ChangeStartPassword")]
    [OpenApiOperation(operationId: "CambiarContrasenaInicio",
       Summary = "Reestablece la contrase�a del usuario para uso de la aplicaci�n por primera vez",
       Description = "Reestablece la contrase�a del usuario para uso de la aplicaci�n por primera vez",
       Visibility = OpenApiVisibilityType.Important)]
    [OpenApiResponseWithBody(
       statusCode: HttpStatusCode.OK,
       contentType: "text/json",
       bodyType: typeof(ResetPasswordResponse),
       Description = "Resultado del reestablecimiento de contrase�a")]
    public async Task<IActionResult> StartPassword([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "CambiarContrasenaInicio")] HttpRequest req)
       => await req.ProcessRequest<ResetPasswordRequest, ResetPasswordResponse>(
           _logger,
           _userApplication.ResetPassword);

}