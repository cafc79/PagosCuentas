namespace PAT.Application.Models.EgressManagement
{
    public readonly record struct ProcessPaymentRequest
    (
        int IdPaymentRequest,
        DateTime Date,
        int Stage,
        string Medium,
        decimal Mount,
        string Check,
        int Operation,
        string JwtToken
        );
}
