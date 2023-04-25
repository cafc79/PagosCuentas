namespace PAT.Application.Models.EgressManagement
{
    public readonly record struct CompanyAmmountResponse
    (
        List<CompanyAmmount> CompanyAmmounts,
        decimal AvailableMoneyTotal,
        decimal MoneyToPayTodayTotal,
        IEnumerable<string> Errors
        );
}
