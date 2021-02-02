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
    public class CoordenadasController : ApiController
    {
        private MonitoreoContext db = new MonitoreoContext();

        // GET: api/Coordenadas
        public List<Coordenada> GetCoordenadas()
        {
            return db.Coordenadas.ToList();
        }

        // GET: api/Coordenadas/5
        [ResponseType(typeof(Coordenada))]
        public async Task<IHttpActionResult> GetCoordenada(int id)
        {
            Coordenada coordenada = await db.Coordenadas.FindAsync(id);
            if (coordenada == null)
            {
                return NotFound();
            }

            return Ok(coordenada);
        }

        // PUT: api/Coordenadas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCoordenada(int id, Coordenada coordenada)
        {
            if (coordenada == null)
            {
                return BadRequest("El modelo esta vacio");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (coordenada.Id == 0 && id > 0)
            {
                coordenada.Id = id;
            }

            db.Entry(coordenada).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoordenadaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            Coordenada c = db.Coordenadas.Find(id);
            return Ok(c);
            //return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Coordenadas
        [ResponseType(typeof(Coordenada))]
        public async Task<IHttpActionResult> PostCoordenada(Coordenada coordenada)
        {
            if (coordenada == null)
            {
                return BadRequest("El modelo esta vacio");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Coordenadas.Add(coordenada);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = coordenada.Id }, coordenada);
        }

        // DELETE: api/Coordenadas/5
        [ResponseType(typeof(Coordenada))]
        public async Task<IHttpActionResult> DeleteCoordenada(int id)
        {
            Coordenada coordenada = await db.Coordenadas.FindAsync(id);
            if (coordenada == null)
            {
                return NotFound();
            }

            db.Coordenadas.Remove(coordenada);
            await db.SaveChangesAsync();

            return Ok(coordenada);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CoordenadaExists(int id)
        {
            return db.Coordenadas.Count(e => e.Id == id) > 0;
        }
    }
}