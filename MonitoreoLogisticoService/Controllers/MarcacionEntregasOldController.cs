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
    public class MarcacionEntregasController : ApiController
    {
        private MonitoreoContext db = new MonitoreoContext();

        // GET: api/MarcacionEntregas
        public List<MarcacionEntrega> GetMarcacionEntregas()
        {
            var a = db.MarcacionEntregas.ToList();
            return a;
        }

        // GET: api/MarcacionEntregas/5
        [ResponseType(typeof(MarcacionEntrega))]
        public IHttpActionResult GetMarcacionEntrega(int id)
        {
            MarcacionEntrega marcacionEntrega = db.MarcacionEntregas.Find(id);
            if (marcacionEntrega == null)
            {
                return NotFound();
            }

            return Ok(marcacionEntrega);
        }

        // PUT: api/MarcacionEntregas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMarcacionEntrega(int id, MarcacionEntrega marcacionEntrega)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != marcacionEntrega.Id)
            {
                return BadRequest();
            }

            db.Entry(marcacionEntrega).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarcacionEntregaExists(id))
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

        // POST: api/MarcacionEntregas
        [ResponseType(typeof(MarcacionEntrega))]
        public IHttpActionResult PostMarcacionEntrega(MarcacionEntrega marcacionEntrega)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MarcacionEntregas.Add(marcacionEntrega);

            OrdenEntrega orden_asociada = db.OrdenEntregas.FirstOrDefault(x => x.Id == marcacionEntrega.OrdenEntregaId);
            orden_asociada.Estado = "Entregado";
            db.SaveChanges();

            var hub = GlobalHost.ConnectionManager.GetHubContext<hubPrueba>();
            hub.Clients.All.actualizar("Se actualizo Entrega");

            return CreatedAtRoute("DefaultApi", new { id = marcacionEntrega.Id }, marcacionEntrega);
        }

        // DELETE: api/MarcacionEntregas/5
        [ResponseType(typeof(MarcacionEntrega))]
        public IHttpActionResult DeleteMarcacionEntrega(int id)
        {
            MarcacionEntrega marcacionEntrega = db.MarcacionEntregas.Find(id);
            if (marcacionEntrega == null)
            {
                return NotFound();
            }

            db.MarcacionEntregas.Remove(marcacionEntrega);
            db.SaveChanges();

            return Ok(marcacionEntrega);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MarcacionEntregaExists(int id)
        {
            return db.MarcacionEntregas.Count(e => e.Id == id) > 0;
        }
    }
}