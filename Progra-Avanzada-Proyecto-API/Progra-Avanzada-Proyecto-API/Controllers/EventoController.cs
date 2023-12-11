using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Progra_Avanzada_Proyecto_API;
using PrograAvanzadaProyectoAPI.Models;

public class EventoController : ApiController
{
    private MiCateringContext db = new MiCateringContext();

    // GET: api/Eventos
    public IQueryable<EventoModel> GetEventos()
    {
        return db.Eventos;
    }

    // GET: api/Eventos/5
    [ResponseType(typeof(EventoModel))]
    public IHttpActionResult GetEvento(int id)
    {
        EventoModel evento = db.Eventos.Find(id);
        if (evento == null)
        {
            return NotFound();
        }

        return Ok(evento);
    }

    // POST: api/Eventos
    [ResponseType(typeof(EventoModel))]
    public IHttpActionResult PostEvento(EventoModel evento)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        db.Eventos.Add(evento);
        db.SaveChanges();

        return CreatedAtRoute("DefaultApi", new { id = evento.ID }, evento);
    }

    // PUT: api/Eventos/5
    [ResponseType(typeof(void))]
    public IHttpActionResult PutEvento(int id, EventoModel evento)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (id != evento.ID)
        {
            return BadRequest();
        }

        db.Entry(evento).State = EntityState.Modified;
        db.SaveChanges();

        return StatusCode(HttpStatusCode.NoContent);
    }

    // DELETE: api/Eventos/5
    [ResponseType(typeof(EventoModel))]
    public IHttpActionResult DeleteEvento(int id)
    {
        EventoModel evento = db.Eventos.Find(id);
        if (evento == null)
        {
            return NotFound();
        }

        db.Eventos.Remove(evento);
        db.SaveChanges();

        return Ok(evento);
    }
}