using System.ComponentModel.DataAnnotations;

namespace PAT.Common.Models;

public abstract class PATEntity
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    [Required]
    public DateTime FechaActualizacion { get; set; } = DateTime.UtcNow;
    [Required]
    public bool Eliminado { get; set; } = false;
}