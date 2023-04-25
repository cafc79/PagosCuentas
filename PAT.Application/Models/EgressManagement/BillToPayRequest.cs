namespace PAT.Application.Models.EgressManagement;

public readonly record struct BillToPayRequest(
        string JwtToken,
        string Filter
        );


