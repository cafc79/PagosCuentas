using PAT.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAT.Models.Database.Tablas
{
    [Table("ABC_Autorizador")]
    public class ABCAutorizador : PATEntity
    {


        [Required(AllowEmptyStrings = false)]
        public bool Estatus { get; set; }
        
    }
}
