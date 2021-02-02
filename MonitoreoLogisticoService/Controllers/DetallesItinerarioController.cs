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
    public class DetallesItinerarioController : ApiController
    {
        private MonitoreoContext db = new MonitoreoContext();

        // GET: api/DetallesItinerario
        public List<DetalleItinerario> GetDetallesItinerarios()
        {
            var a = db.DetallesItinerarios.ToList();
            return db.DetallesItinerarios.ToList();
        }

        // GET: api/DetallesItinerario/5
        [ResponseType(typeof(DetalleItinerario))]
        public async Task<IHttpActionResult> GetDetalleItinerario(int id)
        {
            DetalleItinerario detalleItinerario = await db.DetallesItinerarios.FindAsync(id);
            if (detalleItinerario == null)
            {
                return NotFound();
            }

            return Ok(detalleItinerario);
        }

        // PUT: api/DetallesItinerario/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDetalleItinerario(int id, DetalleItinerario detalleItinerario)
        {
            if (detalleItinerario == null)
            {
                return BadRequest("El modelo esta vacio");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (detalleItinerario.Id == 0 && id > 0)
            {
                detalleItinerario.Id = id;
            }

            db.Entry(detalleItinerario).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleItinerarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            DetalleItinerario d = db.DetallesItinerarios.Find(id);
            return Ok(d);
            //return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/DetallesItinerario
        [ResponseType(typeof(DetalleItinerario))]
        public async Task<IHttpActionResult> PostDetalleItinerario(DetalleItinerario detalleItinerario)
        {
            if (detalleItinerario == null)
            {
                return BadRequest("El modelo esta vacio");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DetallesItinerarios.Add(detalleItinerario);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = detalleItinerario.Id }, detalleItinerario);
        }

        // DELETE: api/DetallesItinerario/5
        [ResponseType(typeof(DetalleItinerario))]
        public async Task<IHttpActionResult> DeleteDetalleItinerario(int id)
        {
            DetalleItinerario detalleItinerario = await db.DetallesItinerarios.FindAsync(id);
            if (detalleItinerario == null)
            {
                return NotFound();
            }

            try
            {
                db.DetallesItinerarios.Remove(detalleItinerario);
                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                var a = e.Message;
            }


            return Ok(detalleItinerario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DetalleItinerarioExists(int id)
        {
            return db.DetallesItinerarios.Count(e => e.Id == id) > 0;
        }
    }
}