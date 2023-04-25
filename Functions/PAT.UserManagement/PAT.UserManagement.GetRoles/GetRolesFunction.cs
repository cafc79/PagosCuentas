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
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PAT.UserManagement.GetRoles;

public class GetRolesFunction
{
    private readonly IRoleApplication _roleApplication;
    private readonly ILogger<GetRolesFunction> _logger;
    public GetRolesFunction(ILogger<GetRolesFunction> log,
        IRoleApplication roleApplication)
    {
        _logger = log;
        _roleApplication = roleApplication;
    }
    [FunctionName("GetRolesFunction")]
    [OpenApiOperation(operationId: "ObtenerRoles",
        Summary = "Lista los roles de la aplicación",
        Description = "Lista los roles de la aplicación",
        Visibility = OpenApiVisibilityType.Important)]
    [OpenApiResponseWithBody(
        statusCode: HttpStatusCode.OK,
        contentType: "text/json",
        bodyType: typeof(IEnumerable<GetRolesResponse>),
        Description = "Listado de roles de la aplicación")]
    public async Task<IActionResult> Run([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "ObtenerRoles")] HttpRequest req)
        => await req.ProcessRequest<GetRolesRequest, IEnumerable<GetRolesResponse>>(
            _logger,
            _roleApplication.GetRoles);
}