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
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PAT.UserManagement.GetUsers
{
    public class GetUsersFunction
    {
        private readonly IUserApplication _userApplication;
        private readonly ILogger<GetUsersFunction> _logger;
        public GetUsersFunction(ILogger<GetUsersFunction> log,
            IUserApplication userApplication)
        {
            _logger = log;
            _userApplication = userApplication;
        }
        [FunctionName("GetUsersFunction")]
        [OpenApiOperation(operationId: "ObtenerUsuarios",
            Summary = "Lista los usuarios de la aplicación",
            Description = "Lista los usaurios de la aplicación",
            Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(
            statusCode: HttpStatusCode.OK,
            contentType: "text/json",
            bodyType: typeof(IEnumerable<GetUserResponse>),
            Description = "Listado de usuarios de la aplicación")]
        public async Task<IActionResult> Run([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "ObtenerUsuarios")] HttpRequest req)
            => await req.ProcessRequest<GetUsersRequest, IEnumerable<GetUserResponse>>(
                _logger,
                _userApplication.GetAllUsers);
    }
}
