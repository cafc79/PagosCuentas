using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Models.Database.Tablas
{
    [Table("VW_ABC_Historial_Pago")]
    public class VWABCHistorialPago
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Empresa { get; set; } = String.Empty;
        public string Proveedor { get; set; } = String.Empty;
        public string Concepto { get; set; } = String.Empty;
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal MontoPago { get; set; }
        public string MedioPago { get; set; } = string.Empty;
        public string SolicitudPago { get; set; } = string.Empty;
    }
}
