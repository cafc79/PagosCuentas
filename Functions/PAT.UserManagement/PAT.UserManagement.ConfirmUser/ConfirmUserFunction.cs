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

namespace PAT.UserManagement.ConfirmUser;

public class ConfirmUserFunction
{
    private readonly IUserApplication _userApplication;
    private readonly ILogger<ConfirmUserFunction> _logger;
    public ConfirmUserFunction(ILogger<ConfirmUserFunction> log,
        IUserApplication userApplication)
    {
        _logger = log;
        _userApplication = userApplication;
    }
    [FunctionName("ConfirmUserFunction")]
    [OpenApiOperation(operationId: "ConfirmarUsuario",
        Summary = "Confirma el email del usuario para uso de la aplicación",
        Description = "Confirma el email del usuario para uso de la aplicación",
        Visibility = OpenApiVisibilityType.Important)]
    [OpenApiResponseWithBody(
        statusCode: HttpStatusCode.OK,
        contentType: "text/json",
        bodyType: typeof(ConfirmUserResponse),
        Description = "Resultado de la confirmación")]
    public async Task<IActionResult> Run([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "ConfirmarUsuario")] HttpRequest req)
        => await req.ProcessRequest<ConfirmUserRequest, ConfirmUserResponse>(
            _logger,
            _userApplication.ConfirmUser);
}
