using System.ComponentModel.DataAnnotations;

namespace Progra_Avanzada_Proyecto.Models
{
    public class UsuariosViewModel
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Nombre de Usuario")]
        public string NombreUsuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contrasenna { get; set; }

        [Display(Name = "Rol")]
        public string Rol { get; set; }

        [Display(Name = "Permiso")]
        public string Permiso { get; set; }
    }
}
