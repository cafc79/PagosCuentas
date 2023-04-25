namespace PAT.Application.Models.EgressManagement
{
    public readonly record struct AmountsEgressManagementResponse
    (
        List<AmountsEgressManagement> Amounts,
        IEnumerable<string> Errors
        );
}
