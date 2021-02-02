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
    public class UbicacionesController : ApiController
    {
        private MonitoreoContext db = new MonitoreoContext();

        // GET: api/Ubicaciones
        public List<Ubicacion> GetUbicaciones()
        {
            return db.Ubicaciones.ToList();
        }

        // GET: api/Ubicaciones/5
        [ResponseType(typeof(Ubicacion))]
        public async Task<IHttpActionResult> GetUbicacion(int id)
        {
            Ubicacion ubicacion = await db.Ubicaciones.FindAsync(id);
            if (ubicacion == null)
            {
                return NotFound();
            }

            return Ok(ubicacion);
        }

        // PUT: api/Ubicaciones/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUbicacion(int id, Ubicacion ubicacion)
        {
            if (ubicacion == null)
            {
                return BadRequest("El modelo esta vacio");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (ubicacion.Id == 0 && id > 0)
            {
                ubicacion.Id = id;
            }

            db.Entry(ubicacion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                var a = e;
            }
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!UbicacionExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
            Ubicacion u = db.Ubicaciones.Find(id);
            return Ok(u);
            //return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Ubicaciones
        [ResponseType(typeof(Ubicacion))]
        public async Task<IHttpActionResult> PostUbicacion(Ubicacion ubicacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ubicaciones.Add(ubicacion);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = ubicacion.Id }, ubicacion);
        }

        // DELETE: api/Ubicaciones/5
        [ResponseType(typeof(Ubicacion))]
        public async Task<IHttpActionResult> DeleteUbicacion(int id)
        {
            Ubicacion ubicacion = await db.Ubicaciones.FindAsync(id);
            if (ubicacion == null)
            {
                return NotFound();
            }

            db.Ubicaciones.Remove(ubicacion);
            await db.SaveChangesAsync();

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