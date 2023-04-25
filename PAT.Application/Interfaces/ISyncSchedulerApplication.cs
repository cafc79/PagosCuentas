using PAT.Application.Models.SchedulerManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Application.Interfaces
{
    public interface ISyncSchedulerApplication
    {
        Task<SyncCompaniesResponse> SyncDataCompanies(SyncCompaniesRequest request);
    }
}
