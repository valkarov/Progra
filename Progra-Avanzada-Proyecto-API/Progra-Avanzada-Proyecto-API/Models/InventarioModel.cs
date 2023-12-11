using System.ComponentModel.DataAnnotations;

namespace PrograAvanzadaProyectoAPI.Models
{
    public class InventarioModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string NombreProducto { get; set; }

        public int CantidadDisponible { get; set; }

    }
}