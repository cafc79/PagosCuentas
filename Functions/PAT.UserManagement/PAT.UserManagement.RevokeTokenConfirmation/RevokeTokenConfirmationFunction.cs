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
namespace PAT.UserManagement.RevokeTokenConfirmation
{
    public  class RevokeTokenConfirmationFunction
    {
        private readonly IUserApplication _userApplication;
        private readonly ILogger<RevokeTokenConfirmationFunction> _logger;
        public RevokeTokenConfirmationFunction(ILogger<RevokeTokenConfirmationFunction> log,
            IUserApplication userApplication)
        {
            _logger = log;
            _userApplication = userApplication;
        }
        [FunctionName("RevokeTokenConfirmationFunction")]
        [OpenApiOperation(operationId: "RevocarTokenConfirmacion",
            Summary = "Revoca token de confirmación de usuario",
            Description = "Revoca token de confirmación de usuario",
            Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(
            statusCode: HttpStatusCode.OK,
            contentType: "text/json",
            bodyType: typeof(LockUnlockUserResponse),
            Description = "Resultado de la revocación de token")]
        public async Task<IActionResult> Run([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "RevocarTokenConfirmacion")] HttpRequest req)
            => await req.ProcessRequest<RevokeTokenRequest, RevokeTokenResponse>(
                _logger,
                _userApplication.RevokeTokenConfirmation);
    }
}
