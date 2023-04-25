namespace PAT.Application.Models.EgressManagement
{
    public readonly record struct PaymentAuthorizationResponse
    (
        List<PaymentAuthorizationPending> Payments,
        IEnumerable<string> Errors
        );
}
