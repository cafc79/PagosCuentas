using PAT.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAT.Models.Database.Tablas
{
    [Table("ABC_Empresa")]
    public class ABCEmpresa : PATEntity
    {
        [MaxLength(91)]
        public string  Empresa { get; set; }=string.Empty;
        public string CodigoEmpresa { get; set; } = string.Empty;
        [MaxLength(14)]
        public string RFC { get; set; }=string.Empty ;
        public bool Estatus { get; set; }
      //  public ABCCuentasPorPagar CuentasPorPagar { get; set; } = new ABCCuentasPorPagar { };
    }
}
