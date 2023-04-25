using PAT.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAT.Models.Database.Tablas
{
    [Table("ABC_Pagos")]
    public class ABCPagos : PATEntity
    {


        [Required(AllowEmptyStrings = false)]
        public DateTime Fecha { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(20)]
        public decimal MontoPago { get; set; } = 0;
        [Required(AllowEmptyStrings = false)]
        [MaxLength(18)]
        public string MedioPago { get; set; } = "";
        [Required(AllowEmptyStrings = false)]
        [MaxLength(38)]
        public string NumOperacion { get; set; } = "";
        [Required(AllowEmptyStrings = false)]
        [MaxLength(38)]
        public string NumCheque { get; set; } = "";
        [Required(AllowEmptyStrings = false)]
        [MaxLength(38)]
        public string Estatus { get; set; } = "";
        [Required(AllowEmptyStrings = false)]
        [MaxLength(450)]
        public string Notas { get; set; } = "";

    }
}
