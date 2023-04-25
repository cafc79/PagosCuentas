using System.ComponentModel.DataAnnotations.Schema;

namespace PAT.Models.Database.Tablas
{
    [Table("VW_ABC_Rol_Semaforo")]
    public class VWABCRolSemaforo
    {
        public string RolId { get; set; } = "";
        public string NombreRol { get; set; } = "";
        public bool Semaforo { get; set; } 
    }
}
