using PAT.Application.Interfaces;
using PAT.Application.Models.SchedulerManagement;
using PAT.Provider.Interafaces;

namespace PAT.Application.Services
{
    public class SyncSchedulerApplication : ISyncSchedulerApplication
    {
        ISyncERPService _syncERPService;
        ISyncFinerioService _syncFinerioService;
        public SyncSchedulerApplication(ISyncERPService syncERPService,ISyncFinerioService syncFinerioService)
        {
            _syncERPService = syncERPService;
            _syncFinerioService= syncFinerioService;
        }
        public async Task<SyncCompaniesResponse> SyncDataCompanies(SyncCompaniesRequest request)
        {
            var res = _syncFinerioService.GetToken();
            //var result = await _syncERPService.SyncDataCompanies(request.date);

            // return new SyncCompaniesResponse { IsSync = result.IsSync, Errors = result.Errors };
            return new SyncCompaniesResponse
            { };
            }
    }
}
