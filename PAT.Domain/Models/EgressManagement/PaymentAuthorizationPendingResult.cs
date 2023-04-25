namespace PAT.Domain.Models.EgressManagement
{
    public readonly record struct PaymentAuthorizationPendingResult
    (
     int Id,
     string CompanyName,
     string Provider,
     string Concept,
     DateTime OriginalDate,
     DateTime PaymentDate,
     decimal AmountPaid,
     string PaymentMethod,
     string Solicitor,
         string PaymentRequest,
     IEnumerable<string> Errors
     );

}
