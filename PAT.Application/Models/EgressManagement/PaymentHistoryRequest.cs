namespace PAT.Application.Models.EgressManagement
{
    public readonly record struct PaymentHistoryRequest
    (
    string JwtToken,
    string Filter
    );
}
