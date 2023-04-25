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

namespace PAT.EgressManagement.PaymentAuthorization
{
    public class PaymentAuthorizationFunction
    {
        private readonly IEgressApplication _egressApplication;
        private readonly ILogger<PaymentAuthorizationFunction> _logger;
        public PaymentAuthorizationFunction(ILogger<PaymentAuthorizationFunction> log,
          IEgressApplication egressApplication)
        {
            _logger = log;
            _egressApplication = egressApplication;
        }
        [FunctionName("PaymentAuthorizationFunction")]
        [OpenApiOperation(operationId: "MontosPendientesAutorizacion",
            Summary = "Lista de los montos pendientes de autorizar",
            Description = "Lista de los montos pendientes de autorizar",
            Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(
            statusCode: HttpStatusCode.OK,
            contentType: "text/json",
            bodyType: typeof(IEnumerable<PaymentAuthorizationResponse>),
            Description = "Lista de los montos pendientes de autorizar")]
        public async Task<IActionResult> Run([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "MontosPendientesAutorizacion")] HttpRequest req)
            => await req.ProcessRequest<PaymentAuthorizationRequest, PaymentAuthorizationResponse>(
                _logger,
                _egressApplication.GetPaymentsAuthorizationPending);
    }
}
