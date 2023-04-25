using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PAT.Models.Identity;

public class PATUser : IdentityUser<string>
{
    [Required(AllowEmptyStrings = false)]
    public string NombrePila { get; set; } = string.Empty;

    [Required]
    public bool Activo { get; set; } = true;
}
