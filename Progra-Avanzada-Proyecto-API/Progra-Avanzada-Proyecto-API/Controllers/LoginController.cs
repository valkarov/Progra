using System.Linq;
using System.Web.Http;
using BCrypt.Net; 

namespace Progra_Avanzada_Proyecto_API.Controllers
{
    public class LoginController : ApiController
    {
        private ProyectoPrograContext db = new ProyectoPrograContext();

        // POST: api/Login/authenticate
        [HttpPost]
        [Route("api/Login/authenticate")]
        public IHttpActionResult Authenticate([FromBody] Usuario usuarioLogin)
        {
            if (usuarioLogin == null || string.IsNullOrEmpty(usuarioLogin.NombreUsuario) || string.IsNullOrEmpty(usuarioLogin.Contrasenna))
            {
                return BadRequest("Nombre de usuario y contraseña son requeridos");
            }

            var usuario = db.Usuarios.FirstOrDefault(u => u.NombreUsuario == usuarioLogin.NombreUsuario);

            if (usuario != null && BCrypt.Net.BCrypt.Verify(usuarioLogin.Contrasenna, usuario.Contrasenna))
            {
                // Crear un objeto con la información necesaria
                var userInfo = new
                {
                    NombreUsuario = usuario.NombreUsuario,
                    Rol = usuario.Rol 
                };

                return Ok(userInfo); 
            }
            else
            {
                return Unauthorized(); 
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
