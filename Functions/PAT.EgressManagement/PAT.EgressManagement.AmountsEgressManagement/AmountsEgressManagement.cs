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

namespace PAT.EgressManagement.AmountsEgressManagement
{
    public class AmountsEgressManagement
    {
        private readonly IEgressApplication _egressApplication;
        private readonly ILogger<AmountsEgressManagement> _logger;
        public AmountsEgressManagement(ILogger<AmountsEgressManagement> log,
          IEgressApplication egressApplication)
        {
            _logger = log;
            _egressApplication = egressApplication;
        }
        [FunctionName("AmountsEgressManagement")]
        [OpenApiOperation(operationId: "AmountsEgressManagement",
            Summary = "Lista de los montos totales de cuentas por Pagar",
            Description = "Lista de los montos totales de cuentas por Pagar",
            Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(
            statusCode: HttpStatusCode.OK,
            contentType: "text/json",
            bodyType: typeof(IEnumerable<AmountsEgressManagementResponse>),
            Description = "Lista de los montos totales de cuentas por Pagar")]
        public async Task<IActionResult> Run([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "AmountsEgressManagement")] HttpRequest req)
            => await req.ProcessRequest<AmountsEgressManagementRequest, AmountsEgressManagementResponse>(
                _logger,
                _egressApplication.GetAmountsEgressManagement);
    }
}
