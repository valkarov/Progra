using System;
using System.ComponentModel.DataAnnotations;


namespace Progra_Avanzada_Proyecto.Models
{
    public class EmpleadosViewModel
    {
        public int ID { get; set; }

        [Required (ErrorMessage = "El campo Nombre es obligatorio.")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(200)]
        public string Direccion { get; set; }

        [StringLength(50)]
        public string Telefono { get; set; }

        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(50)]
        public string Cedula { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FechaContratacion { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FechaSalida { get; set; }
    }
}
