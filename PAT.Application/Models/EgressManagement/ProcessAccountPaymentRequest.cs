namespace PAT.Application.Models.EgressManagement
{
    public readonly record struct ProcessAccountPaymentsRequest
    (
     int IdPaymentRequest,
     decimal PaymentAmount,
     int? CheckNumber,
     int AccountId, 
     string UserId,
     string JwtToken
     );
}
