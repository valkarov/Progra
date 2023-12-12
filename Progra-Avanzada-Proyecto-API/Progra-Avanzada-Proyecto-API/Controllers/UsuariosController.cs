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
using BCrypt.Net;
using Progra_Avanzada_Proyecto_API;

namespace Progra_Avanzada_Proyecto_API.Controllers
{
    public class UsuariosController : ApiController
    {
        private ProyectoPrograContext db = new ProyectoPrograContext();

        // GET: api/Usuarios
        public IQueryable<Usuario> GetUsuarios()
        {
            return db.Usuarios;
        }

        // GET: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult GetUsuario(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }


        // POST: api/Usuarios
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult PostUsuario(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Verificar si el usuario ya existe
            if (db.Usuarios.Any(u => u.NombreUsuario == usuario.NombreUsuario))
            {
                return Conflict(); // O un mensaje personalizado de que el nombre de usuario ya existe
            }

            // Hashear la contraseña antes de guardarla
            usuario.Contrasenna = BCrypt.Net.BCrypt.HashPassword(usuario.Contrasenna);

            db.Usuarios.Add(usuario);
            try
            {
                db.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                var errorMessages = e.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                var fullErrorMessage = string.Join("; ", errorMessages);
                var exceptionMessage = string.Concat(e.Message, " Los errores de validación son: ", fullErrorMessage);

                // Considera registrar este mensaje de error para depurar
                throw new System.Data.Entity.Validation.DbEntityValidationException(exceptionMessage, e.EntityValidationErrors);
            }

            return CreatedAtRoute("DefaultApi", new { id = usuario.ID }, usuario);
        }

        // DELETE: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult DeleteUsuario(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            db.Usuarios.Remove(usuario);
            db.SaveChanges();

            return Ok(usuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioExists(int id)
        {
            return db.Usuarios.Count(e => e.ID == id) > 0;
        }
    }
}