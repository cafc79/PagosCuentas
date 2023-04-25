namespace PAT.Application.Models.EgressManagement;

public readonly record struct AmountsEgressManagement
    (
    decimal Amount,
    string Description,
    string Type,
    int? NumberAccounts,
    int Order
    );