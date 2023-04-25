using PAT.Application.Interfaces;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using System.Net;
using System.Collections.Generic;
using PAT.Application.Models.EgressManagement;
using PAT.Common.Functions;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using PAT.Application.Models;

namespace PAT.EgressManagement.ChangeIndicatorStatus
{
    public  class ChangeIndicatorStatusFunction
    {
        private readonly IEgressApplication _egressApplication;
        private readonly ILogger<ChangeIndicatorStatusFunction> _logger;
        public ChangeIndicatorStatusFunction(ILogger<ChangeIndicatorStatusFunction> log,
          IEgressApplication egressApplication)
        {
            _logger = log;
            _egressApplication = egressApplication;
        }
        [FunctionName("ChangeIndicatorStatusFunction")]
        [OpenApiOperation(operationId: "CambiaEstatusSemaforo",
              Summary = "Cambia el estatus del semaforo",
              Description = "Cambia el estatus del semaforo",
              Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(
              statusCode: HttpStatusCode.OK,
              contentType: "text/json",
              bodyType: typeof(SpInsUpdtResponse),
              Description = "Cambia el estatus del semaforo")]
        public async Task<IActionResult> Run([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "CambiaEstatusSemaforo")] HttpRequest req)
              => await req.ProcessRequest<ChangeStatusIndicatorRequest, SpInsUpdtResponse>(
                  _logger,
                  _egressApplication.ChangeStatusIndicator);
    }
}
