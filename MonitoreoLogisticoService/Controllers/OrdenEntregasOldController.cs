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
    public class OrdenEntregasController : ApiController
    {
        private MonitoreoContext db = new MonitoreoContext();

        // GET: api/OrdenEntregas
        public List<OrdenEntrega> GetOrdenEntregas()
        {
            return db.OrdenEntregas.ToList();
        }

        // GET: api/OrdenEntregas/5
        [ResponseType(typeof(OrdenEntrega))]
        public IHttpActionResult GetOrdenEntrega(int id)
        {
            OrdenEntrega ordenEntrega = db.OrdenEntregas.Find(id);
            if (ordenEntrega == null)
            {
                return NotFound();
            }

            return Ok(ordenEntrega);
        }

        // PUT: api/OrdenEntregas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrdenEntrega(int id, OrdenEntrega ordenEntrega)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ordenEntrega.Id)
            {
                return BadRequest();
            }

            db.Entry(ordenEntrega).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenEntregaExists(id))
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

        // POST: api/OrdenEntregas
        [ResponseType(typeof(OrdenEntrega))]
        public IHttpActionResult PostOrdenEntrega(OrdenEntrega ordenEntrega)
        {
            

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ordenEntrega.FechaEmision = DateTime.Now;
            db.OrdenEntregas.Add(ordenEntrega);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ordenEntrega.Id }, ordenEntrega);
        }

        // DELETE: api/OrdenEntregas/5
        [ResponseType(typeof(OrdenEntrega))]
        public IHttpActionResult DeleteOrdenEntrega(int id)
        {
            OrdenEntrega ordenEntrega = db.OrdenEntregas.Find(id);
            if (ordenEntrega == null)
            {
                return NotFound();
            }

            db.OrdenEntregas.Remove(ordenEntrega);
            db.SaveChanges();

            return Ok(ordenEntrega);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrdenEntregaExists(int id)
        {
            return db.OrdenEntregas.Count(e => e.Id == id) > 0;
        }
    }
}