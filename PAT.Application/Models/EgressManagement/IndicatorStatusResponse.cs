namespace PAT.Application.Models.EgressManagement
{
    public readonly record struct IndicatorStatusResponse
    (
     string UserId,
     decimal Amount,
     bool Status,
     DateTime Date
     );
}
