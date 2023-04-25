using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PAT.Application.Interfaces;
using PAT.Application.Models.Authentication;
using PAT.Application.Models.UserManagement;
using PAT.Common.Functions;
using System.Net;
using System.Threading.Tasks;

namespace PAT.UserManagement.Authentication;

public class AuthenticationFunction
{
    private readonly IAuthApplication _authApplication;
    private readonly ILogger<AuthenticationFunction> _logger;

    public AuthenticationFunction(
        IAuthApplication authApplication,
        ILogger<AuthenticationFunction> log)
    {
        _authApplication = authApplication;
        _logger = log;
    }

    [FunctionName("AuthenticationFunction")]
    [OpenApiOperation(operationId: "Autenticar",
        Summary = "Autentica un usuario y devuelve un JWT (revocable)",
        Description = "Autentica un usuario y devuelve un JWT (revocable)",
        Visibility = OpenApiVisibilityType.Important)]
    [OpenApiResponseWithBody(
        statusCode: HttpStatusCode.OK,
        contentType: "text/json",
        bodyType: typeof(AuthenticationResponse),
        Description = "Resultado de la autenticación")]
    public async Task<IActionResult> Autenticar([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "Autenticar")] HttpRequest req)
        => await req.ProcessRequest<AuthenticationRequest, AuthenticationResponse>(
            _logger,
            _authApplication.Authenticate);

    [FunctionName("ValidateAuthenticationFunction")]
    [OpenApiOperation(operationId: "ValidarAutenticacion",
       Summary = "Valida la Autenticacion un usuario (revocable)",
       Description = "Valida la Autenticacion un usuario (revocable)",
       Visibility = OpenApiVisibilityType.Important)]
    [OpenApiResponseWithBody(
       statusCode: HttpStatusCode.OK,
       contentType: "text/json",
       bodyType: typeof(ValidateTokenUserResponse),
       Description = "Resultado de la Validacion la Autenticacion un usuario (revocable)")]
    public async Task<IActionResult> ValidarAutenticacion([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "ValidarAutenticacion")] HttpRequest req)
       => await req.ProcessRequest<ValidateTokenUserRequest, ValidateTokenUserResponse>(
           _logger,
           _authApplication.ValidateJwtTokenLogIn);

    [FunctionName("RevokeJwtTokenLogIn")]
    [OpenApiOperation(operationId: "RevocarJwtTokenLogIn",
           Summary = "Revoca token jwt de inicio de sesión",
           Description = "Revoca token jwt de inicio de sesión",
           Visibility = OpenApiVisibilityType.Important)]
    [OpenApiResponseWithBody(
           statusCode: HttpStatusCode.OK,
           contentType: "text/json",
           bodyType: typeof(LockUnlockUserResponse),
           Description = "Resultado de la revocación de token jwt")]
    public async Task<IActionResult> RevokeTokenLogIn([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "RevocarJwtTokenLogIn")] HttpRequest req)
           => await req.ProcessRequest<RevokeTokenLogInRequest, RevokeTokenLogInResponse>(
               _logger,
               _authApplication.RevokeJwtTokenLogIn);
}