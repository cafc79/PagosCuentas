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
namespace PAT.UserManagement.RevokeTokenLogIn
{
    public  class RevokeTokenLogIn
    {
        private readonly IUserApplication _userApplication;
        private readonly ILogger<RevokeTokenLogIn> _logger;
        public RevokeTokenLogIn(ILogger<RevokeTokenLogIn> log,
            IUserApplication userApplication)
        {
            _logger = log;
            _userApplication = userApplication;
        }
        [FunctionName("RevokeTokenLogIn")]
        [OpenApiOperation(operationId: "RevocarTokenLogIn",
            Summary = "Revoca token de inicio de sesión",
            Description = "Revoca token de inicio de sesión",
            Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(
            statusCode: HttpStatusCode.OK,
            contentType: "text/json",
            bodyType: typeof(LockUnlockUserResponse),
            Description = "Resultado de la revocación de token")]
        public async Task<IActionResult> Run([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "RevocarTokenLogIn")] HttpRequest req)
            => await req.ProcessRequest<RevokeTokenLogInRequest, RevokeTokenLogInResponse>(
                _logger,
                _userApplication.RevokeTokenLogIn);
    }
}
