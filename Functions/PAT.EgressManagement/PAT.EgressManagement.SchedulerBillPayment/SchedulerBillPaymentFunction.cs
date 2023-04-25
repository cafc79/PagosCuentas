using System;
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
namespace PAT.EgressManagement.SchedulerBillPayment
{
    public class SchedulerBillPaymentFunction
    {
        private readonly IEgressApplication _egressApplication;
        private readonly ILogger<SchedulerBillPaymentFunction> _logger;
        public SchedulerBillPaymentFunction(ILogger<SchedulerBillPaymentFunction> log,
          IEgressApplication egressApplication)
        {
            _logger = log;
            _egressApplication = egressApplication;
        }
        [FunctionName("SchedulerBillPaymentFunction")]
        [OpenApiOperation(operationId: "ReprogramarCuentaPorPagar",
              Summary = "Reprograma una cuenta por pagar",
              Description = "Reprograma una cuenta por pagar",
              Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(
              statusCode: HttpStatusCode.OK,
              contentType: "text/json",
              bodyType: typeof(SpInsUpdtResponse),
              Description = "Reprograma una cuenta por pagar")]
        public async Task<IActionResult> Run([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "ReprogramarCuentaPorPagar")] HttpRequest req)
              => await req.ProcessRequest<SchedulerBillPaymentRequest, SpInsUpdtResponse>(
                  _logger,
                  _egressApplication.ScheduleBillPayment);
    }
}
