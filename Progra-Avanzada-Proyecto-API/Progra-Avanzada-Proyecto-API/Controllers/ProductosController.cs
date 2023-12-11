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
    public class ProductosController : ApiController
    {
        private ProyectoPrograContext db = new ProyectoPrograContext();

        // GET: api/Productos
        public IQueryable<ProductosServicio> GetProductosServicios()
        {
            return db.ProductosServicios;
        }

        // GET: api/Productos/5
        [ResponseType(typeof(ProductosServicio))]
        public IHttpActionResult GetProductosServicio(int id)
        {
            ProductosServicio productosServicio = db.ProductosServicios.Find(id);
            if (productosServicio == null)
            {
                return NotFound();
            }

            return Ok(productosServicio);
        }

        // PUT: api/Productos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductosServicio(int id, ProductosServicio productosServicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productosServicio.ID)
            {
                return BadRequest();
            }

            db.Entry(productosServicio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductosServicioExists(id))
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

        // POST: api/Productos
        [ResponseType(typeof(ProductosServicio))]
        public IHttpActionResult PostProductosServicio(ProductosServicio productosServicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductosServicios.Add(productosServicio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = productosServicio.ID }, productosServicio);
        }

        // DELETE: api/Productos/5
        [ResponseType(typeof(ProductosServicio))]
        public IHttpActionResult DeleteProductosServicio(int id)
        {
            ProductosServicio productosServicio = db.ProductosServicios.Find(id);
            if (productosServicio == null)
            {
                return NotFound();
            }

            db.ProductosServicios.Remove(productosServicio);
            db.SaveChanges();

            return Ok(productosServicio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductosServicioExists(int id)
        {
            return db.ProductosServicios.Count(e => e.ID == id) > 0;
        }
    }
}