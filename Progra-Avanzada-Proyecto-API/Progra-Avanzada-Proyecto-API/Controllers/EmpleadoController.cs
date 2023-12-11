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
    public IQueryable<Empleado> GetEmpleados()
    {
        return db.Empleados;
    }

    // GET: api/Empleado/5
    [ResponseType(typeof(Empleado))]
    public IHttpActionResult GetEmpleado(int id)
    {
        Empleado empleado = db.Empleados.Find(id);
        if (empleado == null)
        {
            return NotFound();
        }

        return Ok(empleado);
    }

    // PUT: api/Empleado/5
    [ResponseType(typeof(void))]
    public IHttpActionResult PutEmpleado(int id, Empleado empleado)
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
    [ResponseType(typeof(Empleado))]
    public IHttpActionResult PostEmpleado(Empleado empleado)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        db.Empleados.Add(empleado);
        db.SaveChanges();

        return CreatedAtRoute("DefaultApi", new { id = empleado.ID }, empleado);
    }

    // DELETE: api/Empleado/5
    [ResponseType(typeof(Empleado))]
    public IHttpActionResult DeleteEmpleado(int id)
    {
        Empleado empleado = db.Empleados.Find(id);
        if (empleado == null)
        {
            return NotFound();
        }

        db.Empleados.Remove(empleado);
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
        return db.Empleados.Count(e => e.ID == id) > 0;
    }
}
