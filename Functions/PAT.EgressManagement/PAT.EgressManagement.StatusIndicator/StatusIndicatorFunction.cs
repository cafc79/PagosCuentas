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

namespace PAT.EgressManagement.StatusIndicator
{
    public  class StatusIndicatorFunction
    {
        private readonly IEgressApplication _egressApplication;
        private readonly ILogger<StatusIndicatorFunction> _logger;
        public StatusIndicatorFunction(ILogger<StatusIndicatorFunction> log,
          IEgressApplication egressApplication)
        {
            _logger = log;
            _egressApplication = egressApplication;
        }
        [FunctionName("StatusIndicatorFunction")]
        [OpenApiOperation(operationId: "EstatusSemaforo",
              Summary = "Obtiene el estatusd del semaforo",
              Description = "Obtiene el estatusd del semaforo",
              Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(
              statusCode: HttpStatusCode.OK,
              contentType: "text/json",
              bodyType: typeof(IEnumerable<IndicatorStatusResponse>),
              Description = "Obtiene el estatusd del semaforo")]
        public async Task<IActionResult> Run([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "EstatusSemaforo")] HttpRequest req)
              => await req.ProcessRequest<IndicatorStatusRequest,IEnumerable< IndicatorStatusResponse>>(
                  _logger,
                  _egressApplication.GetStatusIndicator);
    }
}
