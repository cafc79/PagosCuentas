namespace PAT.Application.Models.EgressManagement;

public readonly record struct PaymentAuthorizationRequest(
        string JwtToken,
        string Filter
        );


