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
using PAT.Application.Models.SchedulerManagement;

namespace PAT.Scheduler.SyncERP
{

         public class SyncERPFunction
        {
            private readonly ISyncSchedulerApplication _syncSchedulerApplication;
            private readonly ILogger<SyncERPFunction> _logger;
            public SyncERPFunction(ILogger<SyncERPFunction> log,
              ISyncSchedulerApplication syncSchedulerApplication)
            {
                _logger = log;
                _syncSchedulerApplication = syncSchedulerApplication;
            }
            [FunctionName("SyncDataCompanies")]
            public void SyncDataCompanies([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer, ILogger log)
            {
            log.LogInformation($"Inicia ejecución SyncDataCompanies  a las: {DateTime.Now}");
            var result = _syncSchedulerApplication.SyncDataCompanies(new SyncCompaniesRequest { }).Result;
            if (result.IsSync)
                log.LogInformation($"Ejecución Exitosa  a las : {DateTime.Now}");
            else
                log.LogInformation($"Ejecución fallida  a las : {DateTime.Now}",result.Errors);

        }
           
        }

    }

