using PAT.Domain.Models;
using PAT.Domain.Models.EgressManagement;
using PAT.Models.Database.Stores;

namespace PAT.Domain.Interfaces
{
    public interface IEgressService
    {
        Task<IEnumerable<BillToPayResult>> GetBillToPay(string filter);
        Task<IEnumerable<CompanyAmmountResult>> GetCompanyAmmounts();
        Task<IEnumerable<PaymentHistoryResult>> GetPaymentHistory(string filter);
        Task<IEnumerable<PaymentAuthorizationPendingResult>> GetAutorizationPending(string filter);
        Task<IEnumerable<AmountsEgressManagementResult>> GetAmountsEgressManagement(DateTime date);
        Task<SPInsUpdtResult> ProcessAccountPayment(int IdPaymentRequest, decimal PaymentAmount, int? CheckNumber, int AccountId, string UserId);
        Task<StpABCProcesaAutorizacionPago> ProcessAutorizationPayment(int IdPaymentRequest, string UserId);
        Task<IEnumerable<StpABCRechazaAutorizacionPago>> ProcessRejectAutorizationPayment(int IdPaymentRequest, string UserId, string Message);
        Task<SPInsUpdtResult> ProcessPayment(int IdPaymentRequest, DateTime Date, int Stage, string Medium, decimal Mount, string Check, int Operation);
        Task<IEnumerable<IndicatorStatusResult>> GetStatusIndicator();
        Task<SPInsUpdtResult> ChangeStatusIndicator(string UserId, decimal Ammount, int Activate);
        Task<SPInsUpdtResult> ScheduleBillPayment(int IdSolcicitudPago, DateTime Fecha);

    }
}
