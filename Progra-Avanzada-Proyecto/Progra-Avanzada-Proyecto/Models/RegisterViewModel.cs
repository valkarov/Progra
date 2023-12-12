using System.ComponentModel.DataAnnotations;

namespace Progra_Avanzada_Proyecto.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Nombre de usuario")]
        public string NombreUsuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contrasenna { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Contrasenna", ErrorMessage = "La contraseña y la confirmación no coinciden.")]
        [Display(Name = "Confirmar contraseña")]
        public string ConfirmarContrasenna { get; set; }
    }
}
