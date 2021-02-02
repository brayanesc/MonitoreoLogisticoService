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
    public class ClientesEmpresaController : ApiController
    {
        private MonitoreoContext db = new MonitoreoContext();

        // GET: api/ClientesEmpresa
        public List<ClienteEmpresa> GetClientesEmpresa()
        {
            return db.ClientesEmpresa.ToList();
        }

        // GET: api/ClientesEmpresa/5
        [ResponseType(typeof(ClienteEmpresa))]
        public async Task<IHttpActionResult> GetClienteEmpresa(int id)
        {
            ClienteEmpresa clienteEmpresa = await db.ClientesEmpresa.FindAsync(id);
            if (clienteEmpresa == null)
            {
                return NotFound();
            }

            return Ok(clienteEmpresa);
        }

        // PUT: api/ClientesEmpresa/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClienteEmpresa(int id, ClienteEmpresa clienteEmpresa)
        {
            if (clienteEmpresa == null)
            {
                return BadRequest("El modelo esta vacio");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (clienteEmpresa.Id == 0 && id > 0)
            {
                clienteEmpresa.Id = id;
            }

            db.Entry(clienteEmpresa).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteEmpresaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            ClienteEmpresa ce = db.ClientesEmpresa.Find(id);
            return Ok(ce);
            //return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ClientesEmpresa
        [ResponseType(typeof(ClienteEmpresa))]
        public async Task<IHttpActionResult> PostClienteEmpresa(ClienteEmpresa clienteEmpresa)
        {
            if (clienteEmpresa == null)
            {
                return BadRequest("El modelo esta vacio");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ClientesEmpresa.Add(clienteEmpresa);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = clienteEmpresa.Id }, clienteEmpresa);
        }

        // DELETE: api/ClientesEmpresa/5
        [ResponseType(typeof(ClienteEmpresa))]
        public async Task<IHttpActionResult> DeleteClienteEmpresa(int id)
        {
            ClienteEmpresa clienteEmpresa = await db.ClientesEmpresa.FindAsync(id);
            if (clienteEmpresa == null)
            {
                return NotFound();
            }

            db.ClientesEmpresa.Remove(clienteEmpresa);
            await db.SaveChangesAsync();

            return Ok(clienteEmpresa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClienteEmpresaExists(int id)
        {
            return db.ClientesEmpresa.Count(e => e.Id == id) > 0;
        }
    }
}