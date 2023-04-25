using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using PAT.Application.Interfaces;
using PAT.Application.Models;
using PAT.Application.Models.RoleManagement;
using PAT.Common.Functions;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PAT.PrivilegesManagement.Rol
{
    public class RolFunction
    {
        private readonly IRoleApplication _roleApplication;
        private readonly ILogger<RolFunction> _logger;
        public RolFunction(ILogger<RolFunction> log,
            IRoleApplication roleApplication)
        {
            _logger = log;
            _roleApplication = roleApplication;
        }
        [FunctionName("GetRolesPermissionsFunction")]
        [OpenApiOperation(operationId: "ObtenerRolesPermisos",
            Summary = "Lista los roles de la aplicación y los permisos",
            Description = "Lista los roles de la aplicación y los permisos",
            Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(
            statusCode: HttpStatusCode.OK,
            contentType: "text/json",
            bodyType: typeof(IEnumerable<RolPermissionResponse>),
            Description = "Lista los roles de la aplicación y los permisos")]
        public async Task<IActionResult> RolesPermissionsFunction([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "ObtenerRolesPermisos")] HttpRequest req)
            => await req.ProcessRequest<RolPermissionRequest, IEnumerable<RolPermissionResponse>>(
                _logger,
                _roleApplication.GetRolPermissions);

        [FunctionName("GetRolesIndicatorFunction")]
        [OpenApiOperation(operationId: "ObtenerRolesSemaforo",
          Summary = "Lista los roles de la aplicación y los permisos del semaforo",
          Description = "Lista los roles de la aplicación y los permisos del semaforo",
          Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(
          statusCode: HttpStatusCode.OK,
          contentType: "text/json",
          bodyType: typeof(IEnumerable<RolIndicatorResponse>),
          Description = "Lista los roles de la aplicación y los permisos del semaforo")]
        public async Task<IActionResult> RolesIndicatorFunction([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "ObtenerRolesSemaforo")] HttpRequest req)
          => await req.ProcessRequest<RolIndicatorRequest, IEnumerable<RolIndicatorResponse>>(
              _logger,
              _roleApplication.GetRolIndicator);

        [FunctionName("EnableRolIndicatorFunction")]
        [OpenApiOperation(operationId: "HabilitaRolSemaforo",
        Summary = "Habilita la edicion de semaforo por rol",
        Description = "Habilita la edicion de semaforo por rol",
        Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(
        statusCode: HttpStatusCode.OK,
        contentType: "text/json",
        bodyType: typeof(SpInsUpdtResponse),
        Description = "Habilita la edicion de semaforo por rol")]
        public async Task<IActionResult> EnableRolIndicatorFunction([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "HabilitaRolSemaforo")] HttpRequest req)
        => await req.ProcessRequest<EnableRolIndicatorRequest, SpInsUpdtResponse>(
            _logger,
            _roleApplication.EnableRolIndicator);
    }
}

