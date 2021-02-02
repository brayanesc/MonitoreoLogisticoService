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
using MonitoreoLogisticoService.Data;
using MonitoreoLogisticoService.Data.Entities.Monitoreo;

namespace MonitoreoLogisticoService.Controllers
{
    public class CoordenadasController : ApiController
    {
        private MonitoreoContext db = new MonitoreoContext();

        // GET: api/Coordenadas
        public IQueryable<Coordenada> GetCoordenadas()
        {
            return db.Coordenadas;
        }

        // GET: api/Coordenadas/5
        [ResponseType(typeof(Coordenada))]
        public IHttpActionResult GetCoordenada(int id)
        {
            Coordenada coordenada = db.Coordenadas.Find(id);
            if (coordenada == null)
            {
                return NotFound();
            }

            return Ok(coordenada);
        }

        // PUT: api/Coordenadas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCoordenada(int id, Coordenada coordenada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coordenada.Id)
            {
                return BadRequest();
            }

            db.Entry(coordenada).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
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

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Coordenadas
        [ResponseType(typeof(Coordenada))]
        public IHttpActionResult PostCoordenada(Coordenada coordenada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Coordenadas.Add(coordenada);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = coordenada.Id }, coordenada);
        }

        // DELETE: api/Coordenadas/5
        [ResponseType(typeof(Coordenada))]
        public IHttpActionResult DeleteCoordenada(int id)
        {
            Coordenada coordenada = db.Coordenadas.Find(id);
            if (coordenada == null)
            {
                return NotFound();
            }

            db.Coordenadas.Remove(coordenada);
            db.SaveChanges();

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