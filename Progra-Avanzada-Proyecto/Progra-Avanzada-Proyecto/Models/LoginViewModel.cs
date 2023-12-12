using System.ComponentModel.DataAnnotations;

public class LoginViewModel
{
    [Required]
    [Display(Name = "Username")]
    public string NombreUsuario { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Contrasenna { get; set; }

    // Puedes agregar más propiedades si es necesario, como RememberMe, etc.
}
