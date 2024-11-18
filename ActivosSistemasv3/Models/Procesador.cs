using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ActivosSistemasv3.Models;

public class Procesador
{
    public int id { get; set; }
    [Required]
    [StringLength(50)]
    public string Marca { get; set; }
    [Required]
    [StringLength(50)]
    public string Modelo { get; set; }
    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Frecuencia { get; set; }
    
}