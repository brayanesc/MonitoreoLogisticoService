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
using MonitoreoLogisticoService.Models.Requests;
using Newtonsoft.Json.Linq;
using MonitoreoLogisticoService.Models.Responses;

namespace MonitoreoLogisticoService.Controllers
{
    public class OrdenesEntregaController : ApiController
    {
        private MonitoreoContext db = new MonitoreoContext();

        // GET: api/OrdenesEntrega
        public List<OrdenEntrega> GetOrdenesEntrega()
        {
            return db.OrdenesEntrega.ToList();
        }

        // GET: api/OrdenesEntrega/5
        [ResponseType(typeof(OrdenEntrega))]
        public async Task<IHttpActionResult> GetOrdenEntrega(int id)
        {
            OrdenEntrega ordenEntrega = await db.OrdenesEntrega.FindAsync(id);
            if (ordenEntrega == null)
            {
                return NotFound();
            }

            return Ok(ordenEntrega);
        }

        // PUT: api/OrdenesEntrega/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOrdenEntrega(int id, OrdenEntrega ordenEntrega)
        {
            if (ordenEntrega == null)
            {
                return BadRequest("El modelo esta vacio");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (ordenEntrega.Id == 0 && id > 0)
            {
                ordenEntrega.Id = id;
            }

            db.Entry(ordenEntrega).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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
            OrdenEntrega o = db.OrdenesEntrega.Find(id);
            return Ok(o);
            //return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/OrdenesEntrega
        [ResponseType(typeof(OrdenEntrega))]
        public async Task<IHttpActionResult> PostOrdenEntrega(OrdenEntrega ordenEntrega)
        {
            if (ordenEntrega == null)
            {
                return BadRequest("El modelo esta vacio");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.OrdenesEntrega.Add(ordenEntrega);
                await db.SaveChangesAsync();
            }
            catch (Exception e) {
                var a = e.Message;
            }

            return CreatedAtRoute("DefaultApi", new { id = ordenEntrega.Id }, ordenEntrega);
        }

        // DELETE: api/OrdenesEntrega/5
        [ResponseType(typeof(OrdenEntrega))]
        public async Task<IHttpActionResult> DeleteOrdenEntrega(int id)
        {
            OrdenEntrega ordenEntrega = await db.OrdenesEntrega.FindAsync(id);
            if (ordenEntrega == null)
            {
                return NotFound();
            }

            db.OrdenesEntrega.Remove(ordenEntrega);
            await db.SaveChangesAsync();

            return Ok(ordenEntrega);
        }


        [Route("api/OrdenesEntrega/ObtenerOrdenes")]
        [HttpPost]
        public async Task<IHttpActionResult> ObtenerOrdenes(UserInfo data) {

            List<OrdenEntregaResponse> datos = new List<OrdenEntregaResponse>();

            List<Itinerario> itinerarios = db.Itinerarios.Where(x => x.RepartidorId == data.userId).ToList();

            foreach (var itinerario in itinerarios)
            {
                List<OrdenEntrega> ordenesAsignadas = db.OrdenesEntrega.Where(x => x.ItinerarioId == itinerario.Id).ToList();
                foreach (var orden in ordenesAsignadas)
                {
                    Cliente cliente = db.Clientes.FirstOrDefault(x => x.Id == orden.ClienteId);
                    Ubicacion ubicacion = db.Ubicaciones.FirstOrDefault(x => x.Id == cliente.UbicacionId);

                    OrdenEntregaResponse dato = new OrdenEntregaResponse();

                    dato.Id = orden.Id;
                    dato.FechaEmision = orden.FecharEmision;
                    dato.NroFactura = orden.NroFactura;
                    dato.Estado = orden.Estado;
                    dato.Prioridad = orden.Prioridad;
                    dato.ItinerarioId = orden.ItinerarioId;

                    dato.IdCliente = cliente.Id;
                    dato.NombreCliente = cliente.NombreCompleto;
                    dato.TelefonoCliente = cliente.Telefono;

                    dato.DescripcionUbicacion = ubicacion.Descripcion;
                    dato.LatitudUbicacion = ubicacion.Latitud;
                    dato.LongitudUbicacion = ubicacion.Longitud;

                    datos.Add(dato);

                }
            }
            
            return Ok(JToken.FromObject(datos));
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
            return db.OrdenesEntrega.Count(e => e.Id == id) > 0;
        }
    }
}