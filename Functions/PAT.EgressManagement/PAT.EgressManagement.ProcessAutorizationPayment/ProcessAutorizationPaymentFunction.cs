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
namespace PAT.EgressManagement.ProcessAutorizationPayment
{
    public class ProcessAutorizationPaymentFunction
    {
        private readonly IEgressApplication _egressApplication;
        private readonly ILogger<ProcessAutorizationPaymentFunction> _logger;
        public ProcessAutorizationPaymentFunction(ILogger<ProcessAutorizationPaymentFunction> log,
          IEgressApplication egressApplication)
        {
            _logger = log;
            _egressApplication = egressApplication;
        }
        [FunctionName("ProcessAutorizationPaymentFunction")]
        [OpenApiOperation(operationId: "ProcesaAutorizacionPorPagar",
              Summary = "Procesa las autoricaciones por pagar",
              Description = "Procesa las autorizaciones por pagar",
              Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(
              statusCode: HttpStatusCode.OK,
              contentType: "text/json",
              bodyType: typeof(SpInsUpdtResponse),
              Description = "Procesa las autorizaciones por pagar")]
        public async Task<IActionResult> Run([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "ProcesaAutorizacionPorPagar")] HttpRequest req)
              => await req.ProcessRequest<ProcessAutorizationPaymentRequest, SpInsUpdtResponse>(
                  _logger,
                  _egressApplication.ProcessAutorizationPayment);
    }
}
