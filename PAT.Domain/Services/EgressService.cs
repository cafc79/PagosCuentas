using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PAT.Common.Interfaces;
using PAT.Domain.Interfaces;
using PAT.Domain.Models;
using PAT.Domain.Models.EgressManagement;
using PAT.Models.Database.Stores;
using PAT.Models.Database.Tablas;
using PAT.Provider.Interafaces;

namespace PAT.Domain.Services
{
    public class EgressService : IEgressService
    {
        private readonly ILogger<EgressService> _logger;
        private readonly ISqlRepository<DbContext> _sqlRepository;
        private readonly ISyncERPService _syncERPService;
        public EgressService(ILogger<EgressService> logger, ISqlRepository<DbContext> sqlRepository, ISyncERPService syncERPService)
        {
            _logger = logger;
            _sqlRepository = sqlRepository;
            _syncERPService = syncERPService;
        }
        public async Task<IEnumerable<BillToPayResult>> GetBillToPay(string filter)
        {
            filter = (filter ?? String.Empty).ToLower();
            List<BillToPayResult> listPaymentAuthorizationPendingtResult = new List<BillToPayResult>();
            var data = await _sqlRepository.QueryViewAsync<VWABCCuentasXPagar>(d => !string.IsNullOrEmpty(d.Empresa));

            return data.Select(f => new BillToPayResult
            {
                Id = f.Id,
                Mount = f.Monto,
                CompanyName = f.Empresa,
                Concept = f.Concepto,
                OriginalDate = f.FechaOriginal,
                Provider = f.Proveedor,
                ScheduleDate = f.FechaReprogramada,
                PaymentRequest = f.SolicitudPago,
                EstatusCuentaXPagar=f.Estatus
            }).Where(f=>f.PaymentRequest.ToLower().Contains(filter)).OrderByDescending(d=>d.OriginalDate);

        }
        public async Task<IEnumerable<PaymentHistoryResult>> GetPaymentHistory(string filter)
        {
            filter = (filter ?? String.Empty).ToLower();
            List<PaymentHistoryResult> listPaymentHistoryResult = new List<PaymentHistoryResult>();

            var data = await _sqlRepository.QueryViewAsync<VWABCHistorialPago>(d => !string.IsNullOrEmpty(d.Empresa));

            return data.Select(c => new PaymentHistoryResult { 
                Company = c.Empresa, 
                PaymentRequest = c.SolicitudPago, 
                Concept = c.Concepto,
                Provider = c.Proveedor, 
                PaymentMount = c.MontoPago,
                OriginalDate = c.FechaSolicitud, 
                PaymentDate = c.FechaPago,
                WayToPay = c.MedioPago }).Where(d=>d.PaymentRequest.ToLower().Contains(filter)).OrderByDescending(d=>d.PaymentDate);
        }
        public async Task<IEnumerable<CompanyAmmountResult>> GetCompanyAmmounts()
        {
            List<CompanyAmmountResult> listCompanyAmmountResult = new List<CompanyAmmountResult>();
            var companies = await _sqlRepository.QueryAsync<ABCEmpresa>(d => !d.Eliminado);
            var cuentas = await _sqlRepository.QueryAsync<ABCCuentasPorPagar>(d => !d.Eliminado
            && d.FechaProgramada >= System.DateTime.Now.Date && d.FechaProgramada < System.DateTime.Now.Date.AddDays(1));

            foreach (var x in companies)
            {
                listCompanyAmmountResult.Add(new CompanyAmmountResult
                {
                    CompanyName = x.Empresa,
                    AvailableMoney = 0,
                    MoneyToPayToday = cuentas.Where(d => d.IdEmpresa == x.Id).Sum(d => d.Monto)
                });
            }

            return listCompanyAmmountResult;
        }
        public async Task<IEnumerable<PaymentAuthorizationPendingResult>> GetAutorizationPending(string filter)
        {
            filter = (filter ?? String.Empty).ToLower();
            List<PaymentAuthorizationPendingResult> listPaymentAuthorizationPendingtResult = new List<PaymentAuthorizationPendingResult>();
            var data = await _sqlRepository.QueryViewAsync<VWABCAutorizacionPago>(d => !string.IsNullOrEmpty(d.Empresa));

            return data.Select(f => new PaymentAuthorizationPendingResult
            {
                Id = f.Id,
                AmountPaid = f.MontoPago,
                CompanyName = f.Empresa,
                Concept = f.Concepto,
                OriginalDate = f.FechaSolicitud,
                Provider = f.Proveedor,
                Solicitor = f.Solicitante,
                PaymentRequest = f.SolicitudPago

            }).Where(d=>d.PaymentRequest.ToLower().Contains(filter)).OrderByDescending(f=>f.OriginalDate);

        }
        public async Task<IEnumerable<AmountsEgressManagementResult>> GetAmountsEgressManagement(DateTime date)
        {
            var data = await _sqlRepository.QueryViewAsync<VWABCIndicadoresEgresos>(d => !string.IsNullOrEmpty(d.Descripcion));
            return data.Select(f => new AmountsEgressManagementResult
            {
                Amount = f.Monto,
                Description = f.Descripcion,
                Type = f.Tipo,
                NumberAccounts = f.NumeroCuentas,
                Order=f.Orden
            }).OrderBy(d=>d.Order);

        }
        public async Task<SPInsUpdtResult> ProcessAccountPayment(int IdPaymentRequest, decimal PaymentAmount, int? CheckNumber, int AccountId, string UserId)
        {
            var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@IdSolicitudPago",
                            Value = IdPaymentRequest
                        },
                        new SqlParameter() {
                            ParameterName = "@MontoPago",
                            Value = PaymentAmount
                        },
                           new SqlParameter() {
                            ParameterName = "@NumCheque",
                            Value =CheckNumber.Value
                        },
                              new SqlParameter() {
                            ParameterName = "@IdCuenta",
                            Value =AccountId
                        },
                              new SqlParameter() {
                            ParameterName = "@UsuarioId",
                            Value = UserId
                        }
            };

            var data = await _sqlRepository.InsertUpdateByStore("stp_ABC_Procesa_Cuenta_Por_Pagar2",
              param);
            return new SPInsUpdtResult { Succeeded = data > 0 };
        }
        public async Task<StpABCProcesaAutorizacionPago> ProcessAutorizationPayment(int IdPaymentRequest, string UserId)
        {
            var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@IdSolicitudPago",
                            Value = IdPaymentRequest
                        },

                              new SqlParameter() {
                            ParameterName = "@UsuarioId",
                            Value = UserId
                        }
            };

            var data = await _sqlRepository.InsertUpdateByStore<StpABCProcesaAutorizacionPago>("stp_ABC_Procesa_Autorizacion_Pago2", param);

            if (data.Any())
            {
                var solicitud = data.First();
                if (solicitud.IdSolicitudPago != null)
                {
                    var pago = await ProcessPayment(IdPaymentRequest, System.DateTime.Now, solicitud.Stage.Value, solicitud.Medio, solicitud.Monto.Value, solicitud.Cheque, solicitud.Operacion.Value);
                    if (pago.Succeeded)
                        return solicitud;
                    else
                       return new StpABCProcesaAutorizacionPago { Mensaje = "Se autorizo pero no se proceso el pago" };
                }
            }

            return data.First();
        }

        public async Task<IEnumerable<StpABCRechazaAutorizacionPago>> ProcessRejectAutorizationPayment(int IdPaymentRequest, string UserId, string Message)
        {
            var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@IdSolicitudPago",
                            Value = IdPaymentRequest
                        },

                              new SqlParameter() {
                            ParameterName = "@UsuarioId",
                            Value = UserId
                        },
                                new SqlParameter() {
                            ParameterName = "@Mensaje",
                            Value = Message
                        },
            };

           var data= await _sqlRepository.InsertUpdateByStore<StpABCRechazaAutorizacionPago>("stp_ABC_Procesa_RechazaAutorizacion_Pago2", param);
         
            return data;
        }
        public async Task<SPInsUpdtResult> ProcessPayment(
            int IdPaymentRequest,
            DateTime Date,
            int Stage,
            string Medium,
            decimal Mount,
            string Check,
            int Operation)
        {
            var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@IdSolicitudPago",
                            Value = IdPaymentRequest
                        },

                              new SqlParameter() {
                            ParameterName = "@Fecha",
                            Value = Date
                        },
                                new SqlParameter() {
                            ParameterName = "@Stage",
                            Value = Stage
                        },
                                new SqlParameter() {
                            ParameterName = "@Medio",
                            Value = Medium
                        },
                                new SqlParameter() {
                            ParameterName = "@Monto",
                            Value = Mount
                        } ,
                                new SqlParameter() {
                            ParameterName = "@Cheque",
                            Value = Check
                        },
                                new SqlParameter() {
                            ParameterName = "@Operacion",
                            Value = Operation
                        }
            };

            var data = await _sqlRepository.InsertUpdateByStore("stp_ABC_Procesa_Pago",
              param);
            return new SPInsUpdtResult { Succeeded = data > 0 };
        }

        public async Task<IEnumerable<IndicatorStatusResult>> GetStatusIndicator()
        {
            var data = await _sqlRepository.QueryViewAsync<VWABCGetStatusSemaforo>(d =>!string.IsNullOrEmpty( d.UsuarioID ));
            return data.Select(f => new IndicatorStatusResult
            {
                Amount = f.MontoSemaforo,
                Date = f.FechaEstatus,
                Status = f.EstatusActual,
                UserId = f.UsuarioID
            });

        }

        public async Task<SPInsUpdtResult> ChangeStatusIndicator(string UserId, decimal Ammount, int Activate)
        {
            var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@UsuarioID",
                            Value = UserId
                        },
                        new SqlParameter() {
                            ParameterName = "@Monto",
                            Value = Ammount
                        },
                           new SqlParameter() {
                            ParameterName = "@Activar",
                            Value =Activate
                        }
            };

            var data = await _sqlRepository.InsertUpdateByStore("stp_ABC_CambiaStatus_Semaforo",
              param);
            return new SPInsUpdtResult { Succeeded = data > 0 };
        }
        public async Task<SPInsUpdtResult> ScheduleBillPayment(int IdSolcicitudPago, DateTime Fecha)
        {
            var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@IdSolicitudPago",
                            Value = IdSolcicitudPago
                        },
                        new SqlParameter() {
                            ParameterName = "@FechaProgramada",
                            Value = Fecha
                        }
            };

            var data = await _sqlRepository.InsertUpdateByStore("stp_ABC_Reprogramar",
              param);
            return new SPInsUpdtResult { Succeeded = data > 0 };
        }
    }
}
