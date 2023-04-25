using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Models.Database.Tablas
{
    [Table("VW_ABC_Rol_Permiso")]
    public class VWABCRolPermiso
    {
        public string RolId { get; set; } = "";
        public string NombreRol { get; set; } = "";
        public int PermisoId { get; set; }
        public string NombrePermiso { get; set; } = "";
        public bool Estatus { get; set; }
    }
}
