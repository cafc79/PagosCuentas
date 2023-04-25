using PAT.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Models.Database.Tablas
{
    [Table("ABC_Estatus_CuentasX_Pagar")]
    public class ABCEstatusCuentasXPagar : PATEntity
    {
        public string Estatus { get; set; } = string.Empty;
        public bool RegistroActivo { get; set; }
    }
}
