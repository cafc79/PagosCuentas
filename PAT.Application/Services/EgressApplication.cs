using Microsoft.Extensions.Options;
using PAT.Application.Interfaces;
using PAT.Application.Models;
using PAT.Application.Models.EgressManagement;
using PAT.Domain.Interfaces;
using PAT.Models.Configuration;
using PAT.Provider;
using System.Text;

namespace PAT.Application.Services
{
    public class EgressApplication : IEgressApplication
    {
        private readonly EmailSettings _emailSettings;
        private readonly IEmailService _emailService;
        private readonly IEgressService _egressService;
        public EgressApplication(IEgressService egressService, IEmailService emailService, IOptions<EmailSettings> emailSettings)
        {
            _egressService = egressService;
            _emailService = emailService;
            _emailSettings = emailSettings.Value;
        }
        public async Task<IEnumerable<BillToPayResponse>> GetBillToPay(BillToPayRequest request)
        {
            var t = await _egressService.GetBillToPay(request.Filter);
            return t.Select(x => new BillToPayResponse
            {
                Id = x.Id,
                Concept = x.Concept,
                PaymentRequest = x.PaymentRequest,
                CompanyName = x.CompanyName,
                Provider = x.Provider,
                OriginalDate = x.OriginalDate,
                ScheduleDate = x.ScheduleDate,
                Mount = x.Mount,
                EstatusCuentaXPagar = x.EstatusCuentaXPagar,
                Errors = x.Errors
            });
        }
        public async Task<CompanyAmmountResponse> GetCompanyAmmounts(CompanyAmmountRequest request)
        {

            var companyAmmounts = await _egressService.GetCompanyAmmounts();
            CompanyAmmountResponse companyAmmountResponse = new CompanyAmmountResponse
            {
                AvailableMoneyTotal = companyAmmounts.Sum(k => k.AvailableMoney),
                MoneyToPayTodayTotal = companyAmmounts.Sum(k => k.MoneyToPayToday),
                CompanyAmmounts = new List<CompanyAmmount>()
            };
            foreach (var comp in companyAmmounts)
            {
                companyAmmountResponse.CompanyAmmounts.Add(
                    new CompanyAmmount
                    {
                        CompanyName = comp.CompanyName,
                        AvailableMoney = comp.AvailableMoney,
                        MoneyToPayToday = comp.MoneyToPayToday
                    });
            }
            return companyAmmountResponse;
        }

        public async Task<AmountsEgressManagementResponse> GetAmountsEgressManagement(AmountsEgressManagementRequest request)
        {
            var pendingAuthorization = await _egressService.GetAmountsEgressManagement(request.fecha);
            var amountsEgressManagementResponse = new AmountsEgressManagementResponse()
            {
                Amounts = new List<AmountsEgressManagement>(),
                Errors = new List<string>()
            };
            foreach (var item in pendingAuthorization)
            {
                amountsEgressManagementResponse.Amounts.Add(
                new AmountsEgressManagement
                {
                    Amount = item.Amount,
                    Description = item.Description,
                    Type = item.Type,
                    NumberAccounts = item.NumberAccounts,
                    Order=item.Order
                });
            }
            return amountsEgressManagementResponse;

        }
        public async Task<PaymentAuthorizationResponse> GetPaymentsAuthorizationPending(PaymentAuthorizationRequest request)
        {
            var pendingAuthorization = await _egressService.GetAutorizationPending(request.Filter);
            var pendingAuthorizationResponse = new PaymentAuthorizationResponse()
            {
                Payments = new List<PaymentAuthorizationPending>(),
                Errors = new List<string>()
            };
            foreach (var item in pendingAuthorization)
            {
                pendingAuthorizationResponse.Payments.Add(
                new PaymentAuthorizationPending
                {
                    Id = item.Id,
                    CompanyName = item.CompanyName,
                    PaymentRequest = item.PaymentRequest,
                    AmountPaid = item.AmountPaid,
                    Concept = item.Concept,
                    OriginalDate = item.OriginalDate,
                    PaymentDate = item.PaymentDate,
                    Provider = item.Provider,
                    PaymentMethod = item.PaymentMethod,
                    Solicitor = item.Solicitor
                });
            }
            return pendingAuthorizationResponse;

        }
        public async Task<IEnumerable<PaymentHistoryResponse>> GetPaymentHistory(PaymentHistoryRequest request)
        {
            var paymentHistory = await _egressService.GetPaymentHistory(request.Filter);
            return paymentHistory.Select(d => new PaymentHistoryResponse
            {
                Company = d.Company,
                PaymentRequest = d.PaymentRequest,
                Concept = d.Concept,
                Provider = d.Provider,
                WayToPay = d.WayToPay,
                OriginalDate = d.OriginalDate,
                PaymentDate = d.PaymentDate,
                PaymentMount = d.PaymentMount
            });
        }
        public async Task<SpInsUpdtResponse> ProcessAccountPayments(ProcessAccountPaymentsRequest request)
        {
            var result = await _egressService.ProcessAccountPayment(
                request.IdPaymentRequest,
                request.PaymentAmount,
                request.CheckNumber,
                request.AccountId,
                request.UserId);
            return new SpInsUpdtResponse { Succeded = result.Succeeded, Errors = result.Errors };
        }
        public async Task<SpInsUpdtResponse> ProcessAutorizationPayment(ProcessAutorizationPaymentRequest request)
        {
            List<string> errors = new List<string>();
            var result = await _egressService.ProcessAutorizationPayment(
                request.IdPaymentRequest,
                request.UserId);
            var email = result.Correo;
            var solicitudPago = result.SolicitudPago;
            if (!string.IsNullOrEmpty(email) && result.IdSolicitudPago > 0)
            {
                var template = new StringBuilder();
                template.AppendLine("<img src=\"data:image/png;base64,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\" />");
                template.AppendLine("<p><strong>Autorizaci&oacute;n de pago.</strong></p>");
                template.AppendLine(string.Format("<p><strong>Se autoriz&oacute; el pago con n&uacute;mero de solicitud {0}.</strong></p>", solicitudPago));
               
                var sent = await _emailService.SendEmail(new()
                {
                    EmailBody = template.ToString(),
                    EmailSubject = "Autorización de pago",
                    EmailToId = email,
                    EmailToName = email
                });
                if (!sent.Sent)
                    errors.Add("No se pudo enviar el correo");
            }
            else if(result.IdSolicitudPago > 0)
                errors.Add("No hay Solicitante encontrado ó la solicitud ya fue autorizada");
            else
                errors.Add(result.Mensaje);
            return new SpInsUpdtResponse { Succeded = result.IdSolicitudPago>0, Errors = errors };
        }
        public async Task<SpInsUpdtResponse> ProcessRejectAutorizationPayment(ProcessRejectAutorizationPaymentRequest request)
        {
            List<string> errors = new List<string>();
            var result = await _egressService.ProcessRejectAutorizationPayment(
                request.IdPaymentRequest,
                request.UserId,request.Message);
            //Envia mail
            if (result.Any())
            {
              
                var email = result.Select(f => f.Correo).First();
                var mensaje = request.Message;
                var paymentRequest= request.PaymentRequest ?? result.Select(f => f.SolicitudPago).First();
               
                if (!string.IsNullOrEmpty(email))
                {
                    var template = new StringBuilder();
                    template.AppendLine("<img src=\"data:image/png;base64,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\" />");
                    template.AppendLine("<p><strong>Rechazo de la Autorizaci&oacute;n de pago.</strong></p>");
                    template.AppendLine(string.Format("<p><strong>Se rechaz&oacute; la autorización de pago con n&uacute;mero de solicitud {0}.</strong></p>", paymentRequest ?? request.IdPaymentRequest.ToString()));
                    template.AppendLine(string.Format("<p><strong>Motivo: {0}</strong></p>", mensaje));


                    var sent = await _emailService.SendEmail(new()
                    {


                        EmailBody = template.ToString(),
                        EmailSubject = "Rechazo de Autorización de pago",
                        EmailToId = email,
                        EmailToName = email
                    });
                    if (!sent.Sent)
                        errors.Add("No se pudo enviar el correo");
                }
                else
                    errors.Add("No hay Solicitante encontrado ó la solicitud ya fue rechazada");
            }
            else
                errors.Add("No se encontro el correo");


            return new SpInsUpdtResponse { Succeded = result.Any(), Errors = errors };
        }
        public async Task<SpInsUpdtResponse> ProcessPayment(ProcessPaymentRequest request)
        {
            var result = await _egressService.ProcessPayment(
                request.IdPaymentRequest,
                request.Date,
                request.Stage,
                request.Medium,
                request.Mount,
                request.Check,
                request.Operation);
            return new SpInsUpdtResponse { Succeded = result.Succeeded, Errors = result.Errors };
        }
        public async Task<IEnumerable<IndicatorStatusResponse>> GetStatusIndicator(IndicatorStatusRequest request)
        {
            var result = await _egressService.GetStatusIndicator();
            return result.Select(f => new IndicatorStatusResponse
            {
                Amount = f.Amount,
                Date = f.Date,
                Status = f.Status,
                UserId = f.UserId
            });

        }
        public async Task<SpInsUpdtResponse> ChangeStatusIndicator(ChangeStatusIndicatorRequest request)
        {
            var result = await _egressService.ChangeStatusIndicator(
                request.UserId,
                request.Amount,
                request.Activate?1:0);
            return new SpInsUpdtResponse { Succeded = result.Succeeded, Errors = result.Errors };
        }
        public async Task<SpInsUpdtResponse> ScheduleBillPayment(SchedulerBillPaymentRequest request)
        {
            var result = await _egressService.ScheduleBillPayment(
                request.IdPaymentRequest,
                request.Date
               );
            return new SpInsUpdtResponse { Succeded = result.Succeeded, Errors = result.Errors };
        }
    }

}
