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
    public class RepartidoresController : ApiController
    {
        private MonitoreoContext db = new MonitoreoContext();
        private List<string> excluded = new List<string>() { };

        // GET: api/Repartidores
        public List<Repartidor> GetRepartidores()
        {
            return db.Repartidores.ToList();
        }

        // GET: api/Repartidores/5
        [ResponseType(typeof(Repartidor))]
        public async Task<IHttpActionResult> GetRepartidor(int id)
        {
            Repartidor repartidor = await db.Repartidores.FindAsync(id);
            if (repartidor == null)
            {
                return NotFound();
            }

            return Ok(repartidor);
        }

        // PUT: api/Repartidores/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRepartidor(int id, Repartidor repartidor)
        {
            if (repartidor == null)
            {
                return BadRequest("El modelo esta vacio");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (repartidor.Id == 0 && id > 0)
            {
                repartidor.Id = id;
            }

            //if (id != repartidor.Id)
            //{
            //    return BadRequest();
            //}

            db.Repartidores.Attach(repartidor);
            db.Entry(repartidor).State = EntityState.Modified;
            foreach (var name in excluded)
            {
                db.Entry(repartidor).Property(name).IsModified = false;
            }

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepartidorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            Repartidor r = db.Repartidores.Find(id);
            return Ok(r);
            //return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Repartidores
        [ResponseType(typeof(Repartidor))]
        public async Task<IHttpActionResult> PostRepartidor(Repartidor repartidor)
        {
            if (repartidor == null)
            {
                return BadRequest("El modelo esta vacio");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Repartidores.Add(repartidor);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = repartidor.Id }, repartidor);
        }

        // DELETE: api/Repartidores/5
        [ResponseType(typeof(Repartidor))]
        public async Task<IHttpActionResult> DeleteRepartidor(int id)
        {
            Repartidor repartidor = await db.Repartidores.FindAsync(id);
            if (repartidor == null)
            {
                return NotFound();
            }

            db.Repartidores.Remove(repartidor);
            await db.SaveChangesAsync();

            return Ok(repartidor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RepartidorExists(int id)
        {
            return db.Repartidores.Count(e => e.Id == id) > 0;
        }
    }
}