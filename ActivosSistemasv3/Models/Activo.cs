using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ActivosSistemasv3.Models;

namespace YourNamespace.Models
{
    public enum TipoActivo
    {
        Escritorio,
        Portatil
    }
    
    public class Activo
    {
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string Marca { get; set; }

        [Required]
        [StringLength(100)]
        public string Modelo { get; set; }

        [StringLength(100)]
        public string Tarjeta_Video { get; set; }

        [Required]
        [StringLength(10)]
        public TipoActivo Tipo { get; set; }
        
        public int? ID_Usuario { get; set; }

        public int? ID_Procesador { get; set; }

        public int? ID_Memoria { get; set; }

        public int? ID_DiscoDuro { get; set; }

    }
}