using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MonitoreoLogisticoService.Data;
using MonitoreoLogisticoService.Data.Entities;

namespace MonitoreoLogisticoService.Controllers
{
    public class ItinerariosController : ApiController
    {
        private MonitoreoContext db = new MonitoreoContext();

        // GET: api/Itinerarios
        public List<Itinerario> GetItinerarios()
        {
            return db.Itinerarios.ToList();
        }

        // GET: api/Itinerarios/5
        [ResponseType(typeof(Itinerario))]
        public async Task<IHttpActionResult> GetItinerario(int id)
        {
            Itinerario itinerario = await db.Itinerarios.FindAsync(id);
            if (itinerario == null)
            {
                return NotFound();
            }

            return Ok(itinerario);
        }

        // PUT: api/Itinerarios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutItinerario(int id, Itinerario itinerario)
        {
            if (itinerario == null)
            {
                return BadRequest("El modelo esta vacio");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (itinerario.Id == 0 && id > 0)
            {
                itinerario.Id = id;
            }

            db.Entry(itinerario).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItinerarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            Itinerario i = db.Itinerarios.Find(id);
            return Ok(i);
            //return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Itinerarios
        [ResponseType(typeof(Itinerario))]
        public async Task<IHttpActionResult> PostItinerario(Itinerario itinerario)
        {
            if (itinerario == null)
            {
                return BadRequest("El modelo esta vacio");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DetalleItinerario detalles = new DetalleItinerario();

            try
            {
                detalles.Salida = DateTime.Now;
                db.DetallesItinerarios.Add(detalles);

                await db.SaveChangesAsync();

            }
            catch (Exception e) {
                var a = e.Message;
            }
            itinerario.DetalleItinerarioId = detalles.Id;
            db.Itinerarios.Add(itinerario);
            
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = itinerario.Id }, itinerario);
        }

        // DELETE: api/Itinerarios/5
        [ResponseType(typeof(Itinerario))]
        public async Task<IHttpActionResult> DeleteItinerario(int id)
        {
            Itinerario itinerario = await db.Itinerarios.FindAsync(id);
            if (itinerario == null)
            {
                return NotFound();
            }

            db.Itinerarios.Remove(itinerario);
            await db.SaveChangesAsync();

            return Ok(itinerario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItinerarioExists(int id)
        {
            return db.Itinerarios.Count(e => e.Id == id) > 0;
        }
    }
}