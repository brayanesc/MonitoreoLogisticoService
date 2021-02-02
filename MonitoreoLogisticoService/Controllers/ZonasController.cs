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
using MonitoreoLogisticoService.Models.Dtos;

namespace MonitoreoLogisticoService.Controllers
{
    public class ZonasController : ApiController
    {
        private MonitoreoContext db = new MonitoreoContext();

        // GET: api/Zonas
        public List<Zona> GetZonas()
        {
            return db.Zonas.ToList();
        }

        // GET: api/Zonas/5
        [ResponseType(typeof(Zona))]
        public async Task<IHttpActionResult> GetZona(int id)
        {
            Zona zona = await db.Zonas.FindAsync(id);
            if (zona == null)
            {
                return NotFound();
            }

            return Ok(zona);
        }

        // PUT: api/Zonas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutZona(int id, Zona zona)
        {
            if (zona == null)
            {
                return BadRequest("El modelo esta vacio");
            }

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
                await db.SaveChangesAsync();
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

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Zonas
        [ResponseType(typeof(Zona))]
        public async Task<IHttpActionResult> PostZona(Zona zona)
        {
            if (zona == null)
            {
                return BadRequest("El modelo esta vacio");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Zonas.Add(zona);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = zona.Id }, zona);
        }

        // DELETE: api/Zonas/5
        [ResponseType(typeof(Zona))]
        public async Task<IHttpActionResult> DeleteZona(int id)
        {
            Zona zona = await db.Zonas.FindAsync(id);
            if (zona == null)
            {
                return NotFound();
            }

            db.Zonas.Remove(zona);
            await db.SaveChangesAsync();

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