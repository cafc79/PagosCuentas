using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PAT.Application.Interfaces;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using System.Net;
using System.Collections.Generic;
using PAT.Application.Models.EgressManagement;
using PAT.Common.Functions;
using PAT.Application.Models;

namespace PAT.EgressManagement.ProcessAccountPayment
{
    public  class ProcessAccountPaymentFunction
    {
        private readonly IEgressApplication _egressApplication;
        private readonly ILogger<ProcessAccountPaymentFunction> _logger;
        public ProcessAccountPaymentFunction(ILogger<ProcessAccountPaymentFunction> log,
          IEgressApplication egressApplication)
        {
            _logger = log;
            _egressApplication = egressApplication;
        }
        [FunctionName("ProcessAccountPaymentFunction")]
        [OpenApiOperation(operationId: "ProcesaCuentaPorPagar",
              Summary = "Procesa las cuentas por pagar",
              Description = "Procesa las cuentas por pagar",
              Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(
              statusCode: HttpStatusCode.OK,
              contentType: "text/json",
              bodyType: typeof(SpInsUpdtResponse),
              Description = "Procesa las cuentas por pagar")]
        public async Task<IActionResult> Run([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "ProcesaCuentaPorPagar")] HttpRequest req)
              => await req.ProcessRequest<ProcessAccountPaymentsRequest, SpInsUpdtResponse>(
                  _logger,
                  _egressApplication.ProcessAccountPayments);
    }
}
