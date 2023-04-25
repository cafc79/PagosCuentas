using PAT.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAT.Models.Database.Tablas
{
    [Table("ABC_Proveedor")]
    public class ABCProveedor : PATEntity
    {
        [MaxLength(91)]
        public string Proveedor { get; set; } = string.Empty;
        [MaxLength(14)]
        public string RFC { get; set; } = string.Empty;
        public bool Estatus { get; set; }
    }
}
