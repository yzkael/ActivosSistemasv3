using System.ComponentModel.DataAnnotations;

namespace ActivosSistemasv3.Models;

public class Memoria
{
    public int id { get; set; }
    [Required]
    [StringLength((50))]
    public string Marca { get; set; }
    [Required]
    public int Capacidad { get; set; }
    [Required]
    [StringLength((50))]
    public string Tipo { get; set; }
}