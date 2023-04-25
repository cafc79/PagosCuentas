using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Models.Database.Tablas
{
    [Table("VW_ABC_CuentasX_Pagar")]
    public class VWABCCuentasXPagar
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Empresa { get; set; } = string.Empty;
        public string Proveedor { get; set; } = string.Empty;
        public string Concepto { get; set; } = string.Empty;
        public DateTime FechaOriginal { get; set; } = DateTime.Now;
        public DateTime? FechaReprogramada { get; set; } = DateTime.Now;
        public string SolicitudPago { get; set; } = string.Empty;
        public string Estatus { get; set; } = string.Empty;
        public decimal Monto { get; set; }
    }
}
