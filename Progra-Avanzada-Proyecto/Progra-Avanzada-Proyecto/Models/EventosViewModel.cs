using System;
using System.ComponentModel.DataAnnotations;


namespace Progra_Avanzada_Proyecto.Models
{
    public class EventosViewModel
    {
        [Key]
        public int ID { get; set; }

        public DateTime Fecha { get; set; }

        public TimeSpan Hora { get; set; }

        [StringLength(200)]
        public string Ubicacion { get; set; }

        [StringLength(100)]
        public string Tipo { get; set; }

        public int ClienteID { get; set; }

        public int EmpleadoID { get; set; }

        //// Propiedades de navegación (opcional si estás usando Entity Framework)
        //[ForeignKey("ClienteID")]
        //public virtual ClientesViewModel Cliente { get; set; }

        //[ForeignKey("EmpleadoID")]
        //public virtual EmpleadosViewModel Empleado { get; set; }
    }
}
