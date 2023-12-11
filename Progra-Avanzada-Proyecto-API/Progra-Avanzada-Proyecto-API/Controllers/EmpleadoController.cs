using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using PrograAvanzadaProyectoAPI.Models;

public class EmpleadoController : ApiController
{
    private MiCateringContext db = new MiCateringContext();

    // GET: api/Empleados
    public IQueryable<EmpleadoModel> GetEmpleados()
    {
        return db.Empleado;
    }

    // GET: api/Empleado/5
    [ResponseType(typeof(EmpleadoModel))]
    public IHttpActionResult GetEmpleado(int id)
    {
        EmpleadoModel empleado = db.Empleado.Find(id);
        if (empleado == null)
        {
            return NotFound();
        }

        return Ok(empleado);
    }

    // PUT: api/Empleado/5
    [ResponseType(typeof(void))]
    public IHttpActionResult PutEmpleado(int id, EmpleadoModel empleado)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (id != empleado.ID)
        {
            return BadRequest();
        }

        db.Entry(empleado).State = EntityState.Modified;

        try
        {
            db.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EmpleadoExists(id))
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

    // POST: api/Empleados
    [ResponseType(typeof(EmpleadoModel))]
    public IHttpActionResult PostEmpleado(EmpleadoModel empleado)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        db.Empleado.Add(empleado);
        db.SaveChanges();

        return CreatedAtRoute("DefaultApi", new { id = empleado.ID }, empleado);
    }

    // DELETE: api/Empleado/5
    [ResponseType(typeof(EmpleadoModel))]
    public IHttpActionResult DeleteEmpleado(int id)
    {
        EmpleadoModel empleado = db.Empleado.Find(id);
        if (empleado == null)
        {
            return NotFound();
        }

        db.Empleado.Remove(empleado);
        db.SaveChanges();

        return Ok(empleado);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            db.Dispose();
        }
        base.Dispose(disposing);
    }

    private bool EmpleadoExists(int id)
    {
        return db.Empleado.Count(e => e.ID == id) > 0;
    }
}
