using System.ComponentModel.DataAnnotations;

namespace Progra_Avanzada_Proyecto.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El campo Usuario es obligatorio.")]
        [Display(Name = "Usuario")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "El campo Contraseña es obligatorio.")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contrasenna { get; set; }
    }
}