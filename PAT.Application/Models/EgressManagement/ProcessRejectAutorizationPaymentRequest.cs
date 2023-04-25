namespace PAT.Application.Models.EgressManagement
{
    public readonly record struct ProcessRejectAutorizationPaymentRequest
   (
    int IdPaymentRequest,
    string UserId,
    string PaymentRequest,
    string Message
     );
}
