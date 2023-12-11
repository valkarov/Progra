using System;
using System.ComponentModel.DataAnnotations;

namespace PrograAvanzadaProyectoAPI.Models
{
    public class EventoModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public DateTime FechaEvento { get; set; }

        [StringLength(200)]
        public string Ubicacion { get; set; }

        public int ClienteID { get; set; }
        // Si tienes una entidad Cliente, puedes usar una propiedad de navegación:
        // public virtual ClienteModel Cliente { get; set; }

        public int EmpleadoID { get; set; }
        // Similar para Empleado si es relevante:
        // public virtual EmpleadoModel Empleado { get; set; }

        // Otros campos relevantes para tu Evento...
    }
}