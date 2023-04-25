using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Models.Database.Tablas
{
    [Table("VW_ABC_Indicadores_Egresos")]
    public class VWABCIndicadoresEgresos
    {
        public decimal Monto { get; set; }
        public int NumeroCuentas { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public int Orden { get; set; }
    }
}
