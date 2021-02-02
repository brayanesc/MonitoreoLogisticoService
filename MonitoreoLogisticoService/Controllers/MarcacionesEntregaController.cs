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
using Microsoft.AspNet.SignalR;
using MonitoreoLogisticoService.Hubs;

namespace MonitoreoLogisticoService.Controllers
{
    public class MarcacionesEntregaController : ApiController
    {
        private MonitoreoContext db = new MonitoreoContext();

        // GET: api/MarcacionesEntrega
        public List<MarcacionEntrega> GetMarcacionesEntrega()
        {
            try
            {
                var a = db.MarcacionesEntrega.ToList();
                return a;
            }
            catch (Exception e)
            {
                var b = e.Message;
            }
            return new List<MarcacionEntrega>();
        }

        // GET: api/MarcacionesEntrega/5
        [ResponseType(typeof(MarcacionEntrega))]
        public async Task<IHttpActionResult> GetMarcacionEntrega(int id)
        {
            MarcacionEntrega marcacionEntrega = await db.MarcacionesEntrega.FindAsync(id);
            if (marcacionEntrega == null)
            {
                return NotFound();
            }

            return Ok(marcacionEntrega);
        }

        // PUT: api/MarcacionesEntrega/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMarcacionEntrega(int id, MarcacionEntrega marcacionEntrega)
        {
            if (marcacionEntrega == null)
            {
                return BadRequest("El modelo esta vacio");
            }

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
                await db.SaveChangesAsync();
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

            MarcacionEntrega m = db.MarcacionesEntrega.Find(id);
            
            return Ok(m);
            //return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/MarcacionesEntrega
        [ResponseType(typeof(MarcacionEntrega))]
        public async Task<IHttpActionResult> PostMarcacionEntrega(MarcacionEntrega marcacionEntrega)
        {


            if (marcacionEntrega == null)
            {
                return BadRequest("El modelo esta vacio");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            marcacionEntrega.Hora = DateTime.Now;
            db.MarcacionesEntrega.Add(marcacionEntrega);
            try
            {
                OrdenEntrega orden = db.OrdenesEntrega.FirstOrDefault(x => x.Id == marcacionEntrega.OrdenEntregaId);
                orden.Estado = "Entregado";
                await db.SaveChangesAsync();

                var hubContext = GlobalHost.ConnectionManager.GetHubContext<hubPrueba>();
                hubContext.Clients.All.Send("actualizarEntregas");


            }
            catch (Exception e)
            {
                Exception a = e;
            }

            return CreatedAtRoute("DefaultApi", new { id = marcacionEntrega.Id }, marcacionEntrega);
        }

        // DELETE: api/MarcacionesEntrega/5
        [ResponseType(typeof(MarcacionEntrega))]
        public async Task<IHttpActionResult> DeleteMarcacionEntrega(int id)
        {
            MarcacionEntrega marcacionEntrega = await db.MarcacionesEntrega.FindAsync(id);
            if (marcacionEntrega == null)
            {
                return NotFound();
            }

            db.MarcacionesEntrega.Remove(marcacionEntrega);
            await db.SaveChangesAsync();

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
            return db.MarcacionesEntrega.Count(e => e.Id == id) > 0;
        }
    }
}