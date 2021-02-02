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
    public class EncargadosLogisticaController : ApiController
    {
        private MonitoreoContext db = new MonitoreoContext();
        private List<string> excluded = new List<string>() { "FechaIngreso" };

        // GET: api/EncargadosLogistica
        public List<EncargadoLogistica> GetEncargadosLogistica()
        {
            return db.EncargadosLogistica.ToList();
        }

        // GET: api/EncargadosLogistica/5
        [ResponseType(typeof(EncargadoLogistica))]
        public async Task<IHttpActionResult> GetEncargadoLogistica(int id)
        {
            EncargadoLogistica encargadoLogistica = await db.EncargadosLogistica.FindAsync(id);
            if (encargadoLogistica == null)
            {
                return NotFound();
            }

            return Ok(encargadoLogistica);
        }

        // PUT: api/EncargadosLogistica/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEncargadoLogistica(int id, EncargadoLogistica encargadoLogistica)
        {
            if (encargadoLogistica == null)
            {
                return BadRequest("El modelo esta vacio");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            if (encargadoLogistica.Id == 0 && id > 0)
            {
                encargadoLogistica.Id = id;
            }
            db.EncargadosLogistica.Attach(encargadoLogistica);
            db.Entry(encargadoLogistica).State = EntityState.Modified;
            foreach (var name in excluded)
            {
                db.Entry(encargadoLogistica).Property(name).IsModified = false;
            }

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EncargadoLogisticaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            EncargadoLogistica e = db.EncargadosLogistica.Find(id);
            return Ok(e);
            //return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/EncargadosLogistica
        [ResponseType(typeof(EncargadoLogistica))]
        public async Task<IHttpActionResult> PostEncargadoLogistica(EncargadoLogistica encargadoLogistica)
        {
            if (encargadoLogistica == null)
            {
                return BadRequest("El modelo esta vacio");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EncargadosLogistica.Add(encargadoLogistica);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = encargadoLogistica.Id }, encargadoLogistica);
        }

        // DELETE: api/EncargadosLogistica/5
        [ResponseType(typeof(EncargadoLogistica))]
        public async Task<IHttpActionResult> DeleteEncargadoLogistica(int id)
        {
            EncargadoLogistica encargadoLogistica = await db.EncargadosLogistica.FindAsync(id);
            if (encargadoLogistica == null)
            {
                return NotFound();
            }

            db.EncargadosLogistica.Remove(encargadoLogistica);
            await db.SaveChangesAsync();

            return Ok(encargadoLogistica);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EncargadoLogisticaExists(int id)
        {
            return db.EncargadosLogistica.Count(e => e.Id == id) > 0;
        }
    }
}