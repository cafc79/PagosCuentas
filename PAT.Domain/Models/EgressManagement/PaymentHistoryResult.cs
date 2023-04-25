namespace PAT.Domain.Models.EgressManagement
{
    public readonly record struct PaymentHistoryResult
    (
    string Type,
    string Concept,
    DateTime OriginalDate,
    DateTime PaymentDate,
    decimal PaymentMount,
    string WayToPay,
    string Provider,
    string Company,
    string PaymentRequest,
    IEnumerable<string> Errors
    );
}
