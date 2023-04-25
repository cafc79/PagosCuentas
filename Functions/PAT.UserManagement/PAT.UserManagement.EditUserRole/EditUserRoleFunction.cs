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

namespace PAT.UserManagement.EditUserRole;

public class EditUserRoleFunction
{
    private readonly IUserApplication _userApplication;
    private readonly ILogger<EditUserRoleFunction> _logger;

    public EditUserRoleFunction(
        ILogger<EditUserRoleFunction> log,
        IUserApplication userApplication)
    {
        _logger = log;
        _userApplication = userApplication;
    }

    [FunctionName("EditUserRoleFunction")]
    [OpenApiOperation(operationId: "EditarRolUsuario",
        Summary = "Edita el rol del usuario",
        Description = "Edita el rol del usuario",
        Visibility = OpenApiVisibilityType.Important)]
    [OpenApiResponseWithBody(
        statusCode: HttpStatusCode.OK,
        contentType: "text/json",
        bodyType: typeof(EditUserRolRequest),
        Description = "Resultado de la edición del usuario")]
    public async Task<IActionResult> Run([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "EditarRolUsuario")] HttpRequest req)
        => await req.ProcessRequest<EditUserRolRequest, EditUserRolResponse>(
            _logger,
            _userApplication.EditUserRoles);
}