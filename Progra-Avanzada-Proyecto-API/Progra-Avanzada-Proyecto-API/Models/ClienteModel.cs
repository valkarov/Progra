using System;
using System.ComponentModel.DataAnnotations;

namespace PrograAvanzadaProyectoAPI.Models
{
    public class ClienteModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(200)]
        public string Direccion { get; set; }

        [StringLength(50)]
        public string Telefono { get; set; }

        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(500)]
        public string Preferencias { get; set; }

        [StringLength(4000)]
        public string HistorialEventos { get; set; }



        // Considera si necesitas campos adicionales como preferencias, historial de pedidos, etc.
        // Por ejemplo:

        // public virtual ICollection<PedidoModel> Pedidos { get; set; }
    }
}