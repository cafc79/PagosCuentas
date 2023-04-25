namespace PAT.Domain.Models.EgressManagement
{
    public readonly record struct IndicatorStatusResult
    (
     string UserId,
     decimal Amount,
     bool Status,
     DateTime Date
     );
}
