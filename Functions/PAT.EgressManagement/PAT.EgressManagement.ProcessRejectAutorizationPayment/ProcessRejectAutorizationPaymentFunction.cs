using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using PAT.Application.Interfaces;
using PAT.Application.Models;
using PAT.Application.Models.EgressManagement;
using PAT.Common.Functions;
using System.Net;
using System.Threading.Tasks;

namespace PAT.EgressManagement.ProcessRejectAutorizationPayment
{
    public class ProcessRejectAutorizationPaymentFunction
    {
        private readonly IEgressApplication _egressApplication;
        private readonly ILogger<ProcessRejectAutorizationPaymentFunction> _logger;
        public ProcessRejectAutorizationPaymentFunction(ILogger<ProcessRejectAutorizationPaymentFunction> log,
          IEgressApplication egressApplication)
        {
            _logger = log;
            _egressApplication = egressApplication;
        }
        [FunctionName("ProcessRejectAutorizationPaymentFunction")]
        [OpenApiOperation(operationId: "ProcesaRechazoAutorizacionPago",
              Summary = "Procesa el rechazo de las autoricaciones por pagar",
              Description = "Procesa el rechazo de las autoricaciones por pagar",
              Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(
              statusCode: HttpStatusCode.OK,
              contentType: "text/json",
              bodyType: typeof(SpInsUpdtResponse),
              Description = "Procesa el rechazo de las autoricaciones por pagar")]
        public async Task<IActionResult> Run([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "ProcesaRechazoAutorizacionPago")] HttpRequest req)
              => await req.ProcessRequest<ProcessRejectAutorizationPaymentRequest, SpInsUpdtResponse>(
                  _logger,
                  _egressApplication.ProcessRejectAutorizationPayment);
    }
}
