using PAT.Application.Models;
using PAT.Application.Models.EgressManagement;

namespace PAT.Application.Interfaces
{
    public interface IEgressApplication
    {
        Task<IEnumerable<BillToPayResponse>> GetBillToPay(BillToPayRequest request);
        Task<CompanyAmmountResponse> GetCompanyAmmounts(CompanyAmmountRequest request);
        Task<IEnumerable<PaymentHistoryResponse>> GetPaymentHistory(PaymentHistoryRequest request);
        Task<PaymentAuthorizationResponse> GetPaymentsAuthorizationPending(PaymentAuthorizationRequest request);
        Task<SpInsUpdtResponse> ProcessAccountPayments(ProcessAccountPaymentsRequest request);
        Task<SpInsUpdtResponse> ProcessAutorizationPayment(ProcessAutorizationPaymentRequest request);
        Task<SpInsUpdtResponse> ProcessRejectAutorizationPayment(ProcessRejectAutorizationPaymentRequest request);
        Task<SpInsUpdtResponse> ProcessPayment(ProcessPaymentRequest request);
        Task<AmountsEgressManagementResponse> GetAmountsEgressManagement(AmountsEgressManagementRequest request);
        Task<IEnumerable<IndicatorStatusResponse>> GetStatusIndicator(IndicatorStatusRequest request);
        Task<SpInsUpdtResponse> ChangeStatusIndicator(ChangeStatusIndicatorRequest request);
        Task<SpInsUpdtResponse> ScheduleBillPayment(SchedulerBillPaymentRequest request);
    }
}
