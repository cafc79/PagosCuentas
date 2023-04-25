using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using PAT.Application.Interfaces;
using PAT.Application.Models.RoleManagement;
using PAT.Common.Functions;
using System.Net;
using System.Threading.Tasks;

namespace PAT.UserManagement.CreateRole;

public class CreateRoleFunction
{
    private readonly IRoleApplication _roleApplication;
    private readonly ILogger<CreateRoleFunction> _logger;
    public CreateRoleFunction(ILogger<CreateRoleFunction> log,
        IRoleApplication roleApplication)
    {
        _logger = log;
        _roleApplication = roleApplication;
    }
    [FunctionName("CreateRoleFunction")]
    [OpenApiOperation(operationId: "CrearRol",
        Summary = "Crea un rol para la aplicación",
        Description = "Crea un rol para la aplicación",
        Visibility = OpenApiVisibilityType.Important)]
    [OpenApiResponseWithBody(
        statusCode: HttpStatusCode.OK,
        contentType: "text/json",
        bodyType: typeof(CreateRoleResponse),
        Description = "Resultado de la creación del rol")]
    public async Task<IActionResult> Run([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "CrearRol")] HttpRequest req)
        => await req.ProcessRequest<CreateRoleRequest, CreateRoleResponse>(
            _logger,
            _roleApplication.CreateRole);
}