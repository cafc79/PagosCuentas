namespace PAT.Application.Models.EgressManagement;

public readonly record struct PaymentAuthorizationPending
    (
    int  Id,
     string CompanyName,
       string PaymentRequest,
     string Provider,
     string Concept,
     DateTime OriginalDate,
     DateTime PaymentDate,
     decimal AmountPaid,
     string PaymentMethod,
     string Solicitor
    );

