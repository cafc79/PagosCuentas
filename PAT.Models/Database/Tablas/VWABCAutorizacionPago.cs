using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Models.Database.Tablas
{
 [Table("VW_ABC_Autorizacion_Pago")]
    public class VWABCAutorizacionPago
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Empresa { get; set; }=string.Empty;
        public string Proveedor { get; set; } = string.Empty;
        public string Concepto { get; set; } = string.Empty;
        public DateTime FechaSolicitud { get; set; } 
        public string Solicitante { get; set; } = string.Empty;
        public decimal MontoPago { get; set; }
        public string SolicitudPago { get; set; } = string.Empty;
    }
}
