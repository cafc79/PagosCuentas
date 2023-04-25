using PAT.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAT.Models.Database.Tablas;

[Table("ABC_JwtTokenUsuario")]
public class ABCJwtTokenUsuario : PATEntity
{
    public ABCJwtTokenUsuario(
        string correo,
        string token,
        string direccionRemota,
        DateTime fechaExpiracion)
    {
        Correo = correo;
        Token = token;
        DireccionRemota = direccionRemota;
        FechaExpiracion = fechaExpiracion;
    }

    [Required(AllowEmptyStrings = false)]
    public string Correo { get; set; } = "";

    [Required(AllowEmptyStrings = false)]
    public string Token { get; set; } = "";

    [Required(AllowEmptyStrings = false)]
    public string DireccionRemota { get; set; } = "";

    [Required]
    public DateTime FechaExpiracion { get; set; } = DateTime.Now;
}