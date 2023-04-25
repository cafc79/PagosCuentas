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

namespace PAT.EgressManagement.ProcessPayment
{
    public class ProcessPaymentFunction
    {
        private readonly IEgressApplication _egressApplication;
        private readonly ILogger<ProcessPaymentFunction> _logger;
        public ProcessPaymentFunction(ILogger<ProcessPaymentFunction> log,
          IEgressApplication egressApplication)
        {
            _logger = log;
            _egressApplication = egressApplication;
        }
        [FunctionName("ProcessPaymentFunction")]
        [OpenApiOperation(operationId: "ProcesaPago",
              Summary = "Procesa los pagos",
              Description = "Procesa los pagos",
              Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(
              statusCode: HttpStatusCode.OK,
              contentType: "text/json",
              bodyType: typeof(SpInsUpdtResponse),
              Description = "Procesa los pagos")]
        public async Task<IActionResult> Run([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "ProcesaPago")] HttpRequest req)
              => await req.ProcessRequest<ProcessPaymentRequest, SpInsUpdtResponse>(
                  _logger,
                  _egressApplication.ProcessPayment);
    }
}
