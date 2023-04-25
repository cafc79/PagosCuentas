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
using System.Collections.Generic;
using PAT.Application.Models.EgressManagement;
using System.Net;
using PAT.Common.Functions;

namespace PAT.EgressManagement.PaymentHistory
{
    public  class PaymentHistoryFunction
    {
        private readonly IEgressApplication _egressApplication;
        private readonly ILogger<PaymentHistoryFunction> _logger;
        public PaymentHistoryFunction(ILogger<PaymentHistoryFunction> log,
          IEgressApplication egressApplication)
        {
            _logger = log;
            _egressApplication = egressApplication;
        }
        [FunctionName("PaymentHistoryFunction")]
        [OpenApiOperation(operationId: "HistorialPagos",
            Summary = "Lista todos el historial de pagos",
            Description = "Lista todos el historial de pagos",
            Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(
            statusCode: HttpStatusCode.OK,
            contentType: "text/json",
            bodyType: typeof(IEnumerable<PaymentHistoryResponse>),
            Description = "Lista todos el historial de pagos")]
        public async Task<IActionResult> Run([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "HistorialPagos")] HttpRequest req)
            => await req.ProcessRequest<PaymentHistoryRequest, IEnumerable<PaymentHistoryResponse>>(
                _logger,
                _egressApplication.GetPaymentHistory);
    }
}
