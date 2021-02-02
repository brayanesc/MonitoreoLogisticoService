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
using Microsoft.AspNet.SignalR;
using MonitoreoLogisticoService.Hubs;

namespace MonitoreoLogisticoService.Controllers
{
    public class ZonasController : ApiController
    {
        private MonitoreoContext db = new MonitoreoContext();

        // GET: api/Zonas
        public List<Zona> GetZonas()
        {
            var hub = GlobalHost.ConnectionManager.GetHubContext<hubPrueba>();
            hub.Clients.All.actualizar("entro a GET");
            return db.Zonas.ToList();
        }

        // GET: api/Zonas/5
        [ResponseType(typeof(Zona))]
        public IHttpActionResult GetZona(int id)
        {
            Zona zona = db.Zonas.Find(id);
            if (zona == null)
            {
                return NotFound();
            }

            return Ok(zona);
        }

        // PUT: api/Zonas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutZona(int id, Zona zona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (zona.Id == 0 && id > 0)
            {
                zona.Id = id;
            }

            db.Entry(zona).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZonaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            Zona z = db.Zonas.Find(id);
            return Ok(z);
        }

        // POST: api/Zonas
        [ResponseType(typeof(Zona))]
        public IHttpActionResult PostZona(Zona zona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Zonas.Add(zona);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = zona.Id }, zona);
        }

        // DELETE: api/Zonas/5
        [ResponseType(typeof(Zona))]
        public IHttpActionResult DeleteZona(int id)
        {
            Zona zona = db.Zonas.Find(id);
            if (zona == null)
            {
                return NotFound();
            }

            db.Zonas.Remove(zona);
            db.SaveChanges();

            return Ok(zona);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZonaExists(int id)
        {
            return db.Zonas.Count(e => e.Id == id) > 0;
        }
    }
}