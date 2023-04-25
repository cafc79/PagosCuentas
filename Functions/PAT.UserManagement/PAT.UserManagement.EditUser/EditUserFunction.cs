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

namespace PAT.UserManagement.EditUser;

public class EditUserFunction
{
    private readonly IUserApplication _userApplication;
    private readonly ILogger<EditUserFunction> _logger;

    public EditUserFunction(
        IUserApplication userApplication,
        ILogger<EditUserFunction> log)
    {
        _logger = log;
        _userApplication = userApplication;
        _logger = log;
    }

    [FunctionName("EditUserFunction")]
    [OpenApiOperation(operationId: "EditarUsuario",
        Summary = "Edita un usuario",
        Description = "Edita un usuario",
        Visibility = OpenApiVisibilityType.Important)]
    [OpenApiResponseWithBody(
        statusCode: HttpStatusCode.OK,
        contentType: "text/json",
        bodyType: typeof(EditUserResponse),
        Description = "Resultado de la edición")]
    public async Task<IActionResult> Run([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "EditarUsuario")] HttpRequest req)
        => await req.ProcessRequest<EditUserRequest, EditUserResponse>(
            _logger,
            _userApplication.EditUser);
 

}