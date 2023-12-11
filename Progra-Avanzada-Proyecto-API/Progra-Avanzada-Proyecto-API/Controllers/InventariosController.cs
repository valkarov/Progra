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
    public class InventariosController : ApiController
    {
        private ProyectoPrograContext db = new ProyectoPrograContext();

        // GET: api/Inventarios
        public IQueryable<Inventario> GetInventarios()
        {
            return db.Inventarios;
        }

        // GET: api/Inventarios/5
        [ResponseType(typeof(Inventario))]
        public IHttpActionResult GetInventario(int id)
        {
            Inventario inventario = db.Inventarios.Find(id);
            if (inventario == null)
            {
                return NotFound();
            }

            return Ok(inventario);
        }

        // PUT: api/Inventarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInventario(int id, Inventario inventario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventario.ID)
            {
                return BadRequest();
            }

            db.Entry(inventario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Inventarios
        [ResponseType(typeof(Inventario))]
        public IHttpActionResult PostInventario(Inventario inventario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Inventarios.Add(inventario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = inventario.ID }, inventario);
        }

        // DELETE: api/Inventarios/5
        [ResponseType(typeof(Inventario))]
        public IHttpActionResult DeleteInventario(int id)
        {
            Inventario inventario = db.Inventarios.Find(id);
            if (inventario == null)
            {
                return NotFound();
            }

            db.Inventarios.Remove(inventario);
            db.SaveChanges();

            return Ok(inventario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InventarioExists(int id)
        {
            return db.Inventarios.Count(e => e.ID == id) > 0;
        }
    }
}