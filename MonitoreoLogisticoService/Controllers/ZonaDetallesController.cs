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
    public class ZonaDetallesController : ApiController
    {
        private MonitoreoContext db = new MonitoreoContext();

        // GET: api/ZonaDetalles
        public List<ZonaDetalle> GetZonaDetalles()
        {
            return db.ZonaDetalles.ToList();
        }

        // GET: api/ZonaDetalles/5
        [ResponseType(typeof(ZonaDetalle))]
        public IHttpActionResult GetZonaDetalle(int id)
        {
            ZonaDetalle zonaDetalle = db.ZonaDetalles.Find(id);
            if (zonaDetalle == null)
            {
                return NotFound();
            }

            return Ok(zonaDetalle);
        }

        // PUT: api/ZonaDetalles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutZonaDetalle(int id, ZonaDetalle zonaDetalle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zonaDetalle.Id)
            {
                return BadRequest();
            }

            db.Entry(zonaDetalle).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZonaDetalleExists(id))
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

        // POST: api/ZonaDetalles
        [ResponseType(typeof(ZonaDetalle))]
        public IHttpActionResult PostZonaDetalle(ZonaDetalle zonaDetalle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ZonaDetalles.Add(zonaDetalle);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = zonaDetalle.Id }, zonaDetalle);
        }

        // DELETE: api/ZonaDetalles/5
        [ResponseType(typeof(ZonaDetalle))]
        public IHttpActionResult DeleteZonaDetalle(int id)
        {
            ZonaDetalle zonaDetalle = db.ZonaDetalles.Find(id);
            if (zonaDetalle == null)
            {
                return NotFound();
            }

            db.ZonaDetalles.Remove(zonaDetalle);
            db.SaveChanges();

            return Ok(zonaDetalle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZonaDetalleExists(int id)
        {
            return db.ZonaDetalles.Count(e => e.Id == id) > 0;
        }
    }
}