namespace PAT.Domain.Models.EgressManagement
{
    public readonly record struct AmountsEgressManagementResult
    (
        decimal Amount,
        string Description,
        string Type,
        int? NumberAccounts,
        int Order,
        IEnumerable<string> Errors
     );

}
