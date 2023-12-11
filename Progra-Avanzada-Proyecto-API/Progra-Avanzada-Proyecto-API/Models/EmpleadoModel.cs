using System;

namespace PrograAvanzadaProyectoAPI.Models
{
    public class EmpleadoModel
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaContratacion { get; set; }
        public DateTime? FechaSalida { get; set; }
    }
}