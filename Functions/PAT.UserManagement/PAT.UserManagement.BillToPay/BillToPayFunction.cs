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
using PAT.Common.Functions;
using PAT.Application.Models.EgressManagement;

namespace PAT.UserManagement.BillToPay
{
    public  class BillToPayFunction
    {
        private readonly IEgressApplication _egressApplication;
        private readonly ILogger<BillToPayFunction> _logger;
        public BillToPayFunction(ILogger<BillToPayFunction> log,
          IEgressApplication egressApplication)
        {
            _logger = log;
            _egressApplication = egressApplication;
        }
        [FunctionName("BillToPayFunction")]
        [OpenApiOperation(operationId: "ObtenerCuentasPorPagar",
            Summary = "Lista Todas las uentas por pagar",
            Description = "Lista Todas las uentas por pagar",
            Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(
            statusCode: HttpStatusCode.OK,
            contentType: "text/json",
            bodyType: typeof(IEnumerable<BillToPayResponse>),
            Description = "Listado d etodas las cuentas por pagar")]
        public async Task<IActionResult> Run([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "ObtenerCuentasPorPagar")] HttpRequest req)
            => await req.ProcessRequest<BillToPayRequest, IEnumerable<BillToPayResponse>>(
                _logger,
                _egressApplication.GetBillToPay);
    }
}
