using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Progra_Avanzada_Proyecto.Models;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Web.Security;
using System.Web;

namespace Progra_Avanzada_Proyecto.Controllers
{
    public class AccountController : Controller
    {
        // Se inicializa HttpClient con la BaseAddress aquí.
        private static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44356/") // Establece la dirección base aquí.
        };

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
                try
                {
                    // Serializa el modelo a JSON y crea el contenido de la solicitud.
                    var json = JsonConvert.SerializeObject(model);
                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    // Realiza la llamada a la API sin modificar la BaseAddress
                    var response = await client.PostAsync("api/login/authenticate", content);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(responseContent);

                        if (loginResponse != null)
                        {
                            // Almacena el nombre de usuario y el rol en la sesión
                            Session["NombreUsuario"] = loginResponse.NombreUsuario;
                            Session["Rol"] = loginResponse.Rol;
                            return RedirectToAction("Index", "Home");
                        }


                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Usuario o contraseña inválidos.");
                    }
                }
                catch (HttpRequestException e)
                {
                    ModelState.AddModelError("", "Error de comunicación con el servicio de autenticación: " + e.Message);
                }
            }

            return View(model);
        }

        // Acción para mostrar el formulario de registro
        [HttpGet]
        public ActionResult Register()
        {
            return View(); // Buscará la vista en Views/Account/Register.cshtml
        }

        // Método POST para procesar el formulario de registro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = new
                {
                    NombreUsuario = model.NombreUsuario,
                    Contrasenna = model.Contrasenna,
                    Rol = "User", // Valor predeterminado
                    Permiso = "Parcial" // Valor predeterminado
                };

                var json = JsonConvert.SerializeObject(usuario);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await client.PostAsync("api/Usuarios", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home"); // O a una página de confirmación
                }
                else
                {
                    ModelState.AddModelError("", "Error al registrar el usuario.");
                }
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Clear(); // Limpia la sesión
            return RedirectToAction("Index", "Home"); // Redirecciona a la página de inicio
        }

        public ActionResult Recovery()
        {
            return View(new LoginViewModel());
        }


    }

    // El modelo de respuesta que esperas de tu API
    public class LoginResponse
    {
        public string NombreUsuario { get; set; }
        public string Rol { get; set; }
    }
}
