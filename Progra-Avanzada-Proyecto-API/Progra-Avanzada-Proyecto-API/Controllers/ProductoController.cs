using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using PrograAvanzadaProyectoAPI.Models;

public class ProductosController : ApiController
{
    private MiCateringContext db = new MiCateringContext();

    // GET: api/Productos
    public IQueryable<ProductoModel> GetProductos()
    {
        return db.Productos;
    }

    // GET: api/Productos/5
    [ResponseType(typeof(ProductoModel))]
    public IHttpActionResult GetProducto(int id)
    {
        ProductoModel producto = db.Productos.Find(id);
        if (producto == null)
        {
            return NotFound();
        }

        return Ok(producto);
    }

    // POST: api/Productos
    [ResponseType(typeof(ProductoModel))]
    public IHttpActionResult PostProducto(ProductoModel producto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        db.Productos.Add(producto);
        db.SaveChanges();

        return CreatedAtRoute("DefaultApi", new { id = producto.ID }, producto);
    }

    // PUT: api/Productos/5
    [ResponseType(typeof(void))]
    public IHttpActionResult PutProducto(int id, ProductoModel producto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (id != producto.ID)
        {
            return BadRequest();
        }

        db.Entry(producto).State = System.Data.Entity.EntityState.Modified;

        try
        {
            db.SaveChanges();
        }
        catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException)
        {
            if (!ProductoExists(id))
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

    // DELETE: api/Productos/5
    [ResponseType(typeof(ProductoModel))]
    public IHttpActionResult DeleteProducto(int id)
    {
        ProductoModel producto = db.Productos.Find(id);
        if (producto == null)
        {
            return NotFound();
        }

        db.Productos.Remove(producto);
        db.SaveChanges();

        return Ok(producto);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            db.Dispose();
        }
        base.Dispose(disposing);
    }

    private bool ProductoExists(int id)
    {
        return db.Productos.Count(e => e.ID == id) > 0;
    }
}