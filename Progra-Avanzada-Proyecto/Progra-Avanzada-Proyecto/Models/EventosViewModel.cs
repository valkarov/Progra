using System;
using System.ComponentModel.DataAnnotations;


namespace Progra_Avanzada_Proyecto.Models
{
    public class EventosViewModel
    {
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string Ubicacion { get; set; }
        public string Tipo { get; set; }
        public ClienteViewModel Cliente { get; set; }
        public EmpleadoViewModel Empleado { get; set; }

    }

    public class ClienteViewModel
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

    }

    public class EmpleadoViewModel
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

    }

}
