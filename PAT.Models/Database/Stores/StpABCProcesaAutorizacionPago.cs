using System.ComponentModel.DataAnnotations;

namespace PAT.Models.Database.Stores
{
    public class StpABCProcesaAutorizacionPago
    {
      
        public int? IdSolicitudPago { get; set; }
        public DateTime? Fecha { get; set; }
        public string Medio { get; set; } = string.Empty;
        public decimal? Monto { get; set; } = 0;
        public string Cheque { get; set; } = string.Empty;
        public int? Operacion { get; set; }
        public int? Stage { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string SolicitudPago { get; set; } = string.Empty;
    }
}

