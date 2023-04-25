namespace PAT.Domain.Models.EgressManagement
{
    public readonly record struct CompanyAmmountResult
    (
     string CompanyName,
     decimal AvailableMoney,
     decimal MoneyToPayToday,
     IEnumerable<string> Errors
     );

}
