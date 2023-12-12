using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Progra_Avanzada_Proyecto.Models;
using System.Web.Mvc;

namespace Progra_Avanzada_Proyecto.Controllers
{
    public class LoginController : Controller
    {
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
                // Configurar la base de la URL de la API.
                client.BaseAddress = new Uri("https://localhost:44356/"); // Asegúrate de que esta es la URL correcta de tu API.

                try
                {
                    // Realiza la llamada a la API
                    var json = JsonConvert.SerializeObject(model);
                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("api/login/authenticate", content);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(responseContent);

                        // Asumiendo que la API responde con el nombre de usuario y el rol
                        // y deseas almacenar esta información en la sesión.
                        Session["Usuario"] = loginResponse.NombreUsuario;
                        Session["Rol"] = loginResponse.Rol;

                        // Redirige a todos los usuarios a la página de inicio después del inicio de sesión exitoso.
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Usuario o contraseña inválidos.");
                    }
                }
                catch (HttpRequestException e)
                {
                    // Registra la excepción en tu sistema de logging.
                    ModelState.AddModelError("", "Error de comunicación con el servicio de autenticación: " + e.Message);
                }
            }

            // Si el modelo no es válido o la autenticación falla, vuelve a mostrar la vista de inicio de sesión con errores de validación.
            return View(model);
        }
    }

    // El modelo de respuesta que esperas de tu API
    public class LoginResponse
    {
        public string NombreUsuario { get; set; }
        public string Rol { get; set; }
        // Puedes agregar más propiedades según lo que tu API responda.
    }
}
