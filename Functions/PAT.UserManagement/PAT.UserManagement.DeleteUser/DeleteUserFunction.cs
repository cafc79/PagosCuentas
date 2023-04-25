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

namespace PAT.UserManagement.DeleteUser;

public class DeleteUserFunction
{
    private readonly IUserApplication _userApplication;
    private readonly ILogger<DeleteUserFunction> _logger;

    public DeleteUserFunction(
        IUserApplication authApplication,
        ILogger<DeleteUserFunction> log)
    {
        _userApplication = authApplication;
        _logger = log;
    }

    [FunctionName("DeleteUserFunction")]
    [OpenApiOperation(operationId: "BorrarUsuario",
        Summary = "Borra lógicamente el usuario",
        Description = "Borra lógicamente el usuario",
        Visibility = OpenApiVisibilityType.Important)]
    [OpenApiResponseWithBody(
        statusCode: HttpStatusCode.OK,
        contentType: "text/json",
        bodyType: typeof(AuthenticationResponse),
        Description = "Resultado del borrado del usuario")]
    public async Task<IActionResult> Run([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "BorrarUsuario")] HttpRequest req)
        => await req.ProcessRequest<DeleteUserRequest, DeleteUserResponse>(
            _logger,
            _userApplication.DeleteUser);
}