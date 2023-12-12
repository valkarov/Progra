using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Progra_Avanzada_Proyecto_API;

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
                // Aquí manejarías un inicio de sesión exitoso
                // Idealmente, deberías devolver un token de autenticación
                return Ok("Autenticación exitosa"); // Reemplazar con la lógica adecuada
            }
            else
            {
                return Unauthorized(); // Credenciales incorrectas
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
