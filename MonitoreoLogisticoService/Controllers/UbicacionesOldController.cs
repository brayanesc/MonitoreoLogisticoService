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
    public class UbicacionesController : ApiController
    {
        private MonitoreoContext db = new MonitoreoContext();


        public IHttpActionResult ActualizarUbicacion()
        {
            return Ok();
        }

        // GET: api/Ubicaciones
        public List<Ubicacion> GetUbicacions()
        {
            var a = db.Ubicaciones.ToList();
            return a;
        }

        // GET: api/Ubicaciones/5
        [ResponseType(typeof(Ubicacion))]
        public IHttpActionResult GetUbicacion(int id)
        {
            Ubicacion ubicacion = db.Ubicaciones.Find(id);
            if (ubicacion == null)
            {
                return NotFound();
            }

            return Ok(ubicacion);
        }

        // PUT: api/Ubicaciones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUbicacion(int id, Ubicacion ubicacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ubicacion.Id)
            {
                return BadRequest();
            }

            db.Entry(ubicacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UbicacionExists(id))
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

        // POST: api/Ubicaciones
        [ResponseType(typeof(Ubicacion))]
        public IHttpActionResult PostUbicacion(Ubicacion ubicacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ubicaciones.Add(ubicacion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ubicacion.Id }, ubicacion);
        }

        // DELETE: api/Ubicaciones/5
        [ResponseType(typeof(Ubicacion))]
        public IHttpActionResult DeleteUbicacion(int id)
        {
            Ubicacion ubicacion = db.Ubicaciones.Find(id);
            if (ubicacion == null)
            {
                return NotFound();
            }

            db.Ubicaciones.Remove(ubicacion);
            db.SaveChanges();

            return Ok(ubicacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UbicacionExists(int id)
        {
            return db.Ubicaciones.Count(e => e.Id == id) > 0;
        }
    }
}