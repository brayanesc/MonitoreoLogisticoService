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
using MonitoreoLogisticoService.Hubs;
using Microsoft.AspNet.SignalR;

namespace MonitoreoLogisticoService.Controllers
{
    public class MotivosNoEntregaController : ApiController
    {
        private MonitoreoContext db = new MonitoreoContext();

        // GET: api/MotivosNoEntrega
        public List<MotivoNoEntrega> GetMotivosNoEntrega()
        {
            return db.MotivosNoEntrega.ToList();
        }

        // GET: api/MotivosNoEntrega/5
        [ResponseType(typeof(MotivoNoEntrega))]
        public async Task<IHttpActionResult> GetMotivoNoEntrega(int id)
        {
            MotivoNoEntrega motivoNoEntrega = await db.MotivosNoEntrega.FindAsync(id);
            if (motivoNoEntrega == null)
            {
                return NotFound();
            }

            return Ok(motivoNoEntrega);
        }

        // PUT: api/MotivosNoEntrega/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMotivoNoEntrega(int id, MotivoNoEntrega motivoNoEntrega)
        {
            if (motivoNoEntrega == null)
            {
                return BadRequest("El modelo esta vacio");
            }

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
                await db.SaveChangesAsync();
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
            MotivoNoEntrega m = db.MotivosNoEntrega.Find(id);
            return Ok(m);
            //return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/MotivosNoEntrega
        [ResponseType(typeof(MotivoNoEntrega))]
        public async Task<IHttpActionResult> PostMotivoNoEntrega(MotivoNoEntrega motivoNoEntrega)
        {
            if (motivoNoEntrega == null)
            {
                return BadRequest("El modelo esta vacio");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MotivosNoEntrega.Add(motivoNoEntrega);
            MarcacionEntrega marcacionEntrega = db.MarcacionesEntrega.FirstOrDefault(x => x.Id == motivoNoEntrega.MarcacionEntregaId);
            OrdenEntrega orden = db.OrdenesEntrega.FirstOrDefault(x => x.Id == marcacionEntrega.OrdenEntregaId);
            orden.Estado = "No Entregado";
            await db.SaveChangesAsync();

            var hubContext = GlobalHost.ConnectionManager.GetHubContext<hubPrueba>();
            hubContext.Clients.All.Send("actualizarEntregas");
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = motivoNoEntrega.Id }, motivoNoEntrega);
        }

        // DELETE: api/MotivosNoEntrega/5
        [ResponseType(typeof(MotivoNoEntrega))]
        public async Task<IHttpActionResult> DeleteMotivoNoEntrega(int id)
        {
            MotivoNoEntrega motivoNoEntrega = await db.MotivosNoEntrega.FindAsync(id);
            if (motivoNoEntrega == null)
            {
                return NotFound();
            }

            db.MotivosNoEntrega.Remove(motivoNoEntrega);
            await db.SaveChangesAsync();

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
            return db.MotivosNoEntrega.Count(e => e.Id == id) > 0;
        }
    }
}