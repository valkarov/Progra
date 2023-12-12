using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Progra_Avanzada_Proyecto.Models; // Asegúrate de usar el espacio de nombres correcto para tu modelo LoginViewModel

namespace Progra_Avanzada_Proyecto.Controllers
{
    public class LoginController : Controller
    {
        // Asegúrate de tener HttpClient configurado para ser reutilizado o instanciado aquí si es necesario
        private static readonly HttpClient client = new HttpClient();

        [HttpGet]
        public ActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Define la base de la URL de la API si aún no lo has hecho en otro lugar
                client.BaseAddress = new Uri("http://tuapi.com/");

                try
                {
                    // Realiza la llamada a la API
                    var response = await client.PostAsJsonAsync("api/login/authenticate", model);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(responseContent);

                        Session["Usuario"] = loginResponse.NombreUsuario;
                        Session["Rol"] = loginResponse.Rol;

                        // Redirige al usuario basado en el rol
                        return RedirectToRoleBasedPage(loginResponse.Rol);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Usuario o contraseña inválidos.");
                    }
                }
                catch (HttpRequestException e)
                {
                    // Maneja excepciones de la solicitud HTTP aquí
                    ModelState.AddModelError("", "Error de comunicación con el servicio de autenticación.");
                }
            }

            // Si el modelo no es válido o la autenticación falla, vuelve a mostrar la vista de inicio de sesión con errores de validación
            return View(model);
        }

        private ActionResult RedirectToRoleBasedPage(string rol)
        {
            if (rol == "Admin")
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }

    // El modelo de respuesta que esperas de tu API
    public class LoginResponse
    {
        public string NombreUsuario { get; set; }
        public string Rol { get; set; }
        // Añade más propiedades según la respuesta de tu API
    }
}
