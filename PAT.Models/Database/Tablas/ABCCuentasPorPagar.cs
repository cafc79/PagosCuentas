using PAT.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAT.Models.Database.Tablas
{
    [Table("ABC_Cuentas_Por_Pagar")]
    public class ABCCuentasPorPagar : PATEntity
    {
        [Required(AllowEmptyStrings = false)]
        public int IdEmpresa { get; set; }
        public int IdProveedor { get; set; }
        public string SolicitudPago { get; set; } = "";
        public string Concepto { get; set; } = "";
        public DateTime FechaOriginal { get; set; } = DateTime.Now;
        public DateTime FechaProgramada { get; set; } = DateTime.Now;
        //public string EstatusFechaProgramada { get; set; } = "";
        public decimal Monto { get; set; }
        public int IdEstatusCuentaXPagar { get; set; }

    }
}
