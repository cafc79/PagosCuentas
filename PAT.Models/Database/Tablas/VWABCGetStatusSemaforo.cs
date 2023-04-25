using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Models.Database.Tablas
{
 
    [Table("VW_ABC_GetStatus_Semaforo")]
    public  class VWABCGetStatusSemaforo
    {
        public string UsuarioID { get; set; }
        public decimal MontoSemaforo { get; set; }
        public bool EstatusActual { get; set; }
        public DateTime FechaEstatus { get; set; }
    }
}
