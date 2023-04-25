namespace PAT.Application.Models.SchedulerManagement
{
    public readonly record struct SyncCompaniesRequest
    (
         DateTime date,
        string JwtToken 
    );
}
