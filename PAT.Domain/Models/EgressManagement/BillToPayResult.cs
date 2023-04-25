namespace PAT.Domain.Models.EgressManagement;

public readonly record struct BillToPayResult(
    int Id,
    string Concept,
    string PaymentRequest,
    DateTime OriginalDate,
    DateTime? ScheduleDate,
    decimal Mount,
    string CompanyName,
    string Provider,
     string EstatusCuentaXPagar,
    IEnumerable<string> Errors);


