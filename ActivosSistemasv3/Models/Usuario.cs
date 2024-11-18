using System.ComponentModel.DataAnnotations;

namespace ActivosSistemasv3.Models;

public class Usuario
{
    public int id { get; set; }
    [Required] 
    public string Nombre { get; set; }
    [Required]
    [Display(Name = "Apellido Paterno")]
    public string ApellidoPaterno { get; set; }
    [Required]
    [Display(Name = "Apellido Materno")]
    public string ApellidoMaterno { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    public int? telefono { get; set; }
}