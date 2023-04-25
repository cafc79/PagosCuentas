namespace PAT.Application.Models.EgressManagement;

public readonly record struct CompanyAmmount
    (
     string CompanyName,
     decimal AvailableMoney,
     decimal MoneyToPayToday
   
    );

