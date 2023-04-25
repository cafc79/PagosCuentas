namespace PAT.Application.Models.SchedulerManagement
{
    public readonly record struct SyncCompaniesResponse
    (
        bool IsSync,
        IEnumerable<string> Errors
    );
}
