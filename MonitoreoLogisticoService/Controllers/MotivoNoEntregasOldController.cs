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
    public class MotivoNoEntregasController : ApiController
    {
        private MonitoreoContext db = new MonitoreoContext();

        // GET: api/MotivoNoEntregas
        public List<MotivoNoEntrega> GetMotivoNoEntregas()
        {
            return db.MotivoNoEntregas.ToList();
        }

        // GET: api/MotivoNoEntregas/5
        [ResponseType(typeof(MotivoNoEntrega))]
        public IHttpActionResult GetMotivoNoEntrega(int id)
        {
            MotivoNoEntrega motivoNoEntrega = db.MotivoNoEntregas.Find(id);
            if (motivoNoEntrega == null)
            {
                return NotFound();
            }

            return Ok(motivoNoEntrega);
        }

        // PUT: api/MotivoNoEntregas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMotivoNoEntrega(int id, MotivoNoEntrega motivoNoEntrega)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != motivoNoEntrega.Id)
            {
                return BadRequest();
            }

            db.Entry(motivoNoEntrega).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotivoNoEntregaExists(id))
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

        // POST: api/MotivoNoEntregas
        [ResponseType(typeof(MotivoNoEntrega))]
        public IHttpActionResult PostMotivoNoEntrega(MotivoNoEntrega motivoNoEntrega)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MotivoNoEntregas.Add(motivoNoEntrega);

            MarcacionEntrega marcacion_asociada = db.MarcacionEntregas.FirstOrDefault(x => x.Id == motivoNoEntrega.MarcacionId);


            OrdenEntrega orden_asociada = db.OrdenEntregas.FirstOrDefault(x => x.Id == marcacion_asociada.OrdenEntregaId);

            orden_asociada.Estado = "NEntregado";

            //A Prueba
            var hub = GlobalHost.ConnectionManager.GetHubContext<hubPrueba>();
            hub.Clients.All.actualizar("Se actualizo No Entrega");



            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = motivoNoEntrega.Id }, motivoNoEntrega);
        }

        // DELETE: api/MotivoNoEntregas/5
        [ResponseType(typeof(MotivoNoEntrega))]
        public IHttpActionResult DeleteMotivoNoEntrega(int id)
        {
            MotivoNoEntrega motivoNoEntrega = db.MotivoNoEntregas.Find(id);
            if (motivoNoEntrega == null)
            {
                return NotFound();
            }

            db.MotivoNoEntregas.Remove(motivoNoEntrega);
            db.SaveChanges();

            return Ok(motivoNoEntrega);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MotivoNoEntregaExists(int id)
        {
            return db.MotivoNoEntregas.Count(e => e.Id == id) > 0;
        }
    }
}