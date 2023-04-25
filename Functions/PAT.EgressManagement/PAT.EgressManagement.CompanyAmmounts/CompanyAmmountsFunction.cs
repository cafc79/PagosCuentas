using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using PAT.Application.Interfaces;
using PAT.Application.Models.EgressManagement;
using PAT.Common.Functions;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PAT.EgressManagement.CompanyAmmounts
{
    public  class CompanyAmmountsFunction
    {
        private readonly IEgressApplication _egressApplication;
        private readonly ILogger<CompanyAmmountsFunction> _logger;
        public CompanyAmmountsFunction(ILogger<CompanyAmmountsFunction> log,
          IEgressApplication egressApplication)
        {
            _logger = log;
            _egressApplication = egressApplication;
        }
        [FunctionName("CompanyAmmountsFunction")]
        [OpenApiOperation(operationId: "MontosDeLaEmpresa",
            Summary = "Lista todos los montos disponibles y cantidades a pagar",
            Description = "Lista todos los montos disponibles y cantidades a pagar",
            Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(
            statusCode: HttpStatusCode.OK,
            contentType: "text/json",
            bodyType: typeof(IEnumerable<CompanyAmmountResponse>),
            Description = "Lista todos los montos disponibles y cantidades a pagar")]
        public async Task<IActionResult> Run([HttpTrigger(
        AuthorizationLevel.Anonymous,
        "post",
        Route = "MontosDeLaEmpresa")] HttpRequest req)
            => await req.ProcessRequest<CompanyAmmountRequest, CompanyAmmountResponse>(
                _logger,
                _egressApplication.GetCompanyAmmounts);
    }
}
