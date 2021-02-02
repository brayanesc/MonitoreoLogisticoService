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
    [AllowAnonymous]
    public class ClientesPersonaController : ApiController
    {
        private MonitoreoContext db = new MonitoreoContext();

        // GET: api/ClientesPersona
        public List<ClientePersona> GetClientesPersona()
        {
            return db.ClientesPersona.ToList();
        }

        // GET: api/ClientesPersona/5
        [ResponseType(typeof(ClientePersona))]
        public async Task<IHttpActionResult> GetClientePersona(int id)
        {
            ClientePersona clientePersona = await db.ClientesPersona.FindAsync(id);
            if (clientePersona == null)
            {
                return NotFound();
            }

            return Ok(clientePersona);
        }

        // PUT: api/ClientesPersona/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClientePersona(int id, ClientePersona clientePersona)
        {
            if (clientePersona == null)
            {
                return BadRequest("El modelo esta vacio");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientePersona.Id)
            {
                return BadRequest();
            }

            db.Entry(clientePersona).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientePersonaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            ClientePersona cp = db.ClientesPersona.Find(id);
            return Ok(cp);
            //return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ClientesPersona
        [ResponseType(typeof(ClientePersona))]
        public async Task<IHttpActionResult> PostClientePersona(ClientePersona clientePersona)
        {
            if (clientePersona == null)
            {
                return BadRequest("El modelo esta vacio");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                db.ClientesPersona.Add(clientePersona);
                await db.SaveChangesAsync();

            }
            catch (Exception e) {
                var a = e;
            }

            return CreatedAtRoute("DefaultApi", new { id = clientePersona.Id }, clientePersona);
        }

        // DELETE: api/ClientesPersona/5
        [ResponseType(typeof(ClientePersona))]
        public async Task<IHttpActionResult> DeleteClientePersona(int id)
        {
            ClientePersona clientePersona = await db.ClientesPersona.FindAsync(id);
            if (clientePersona == null)
            {
                return NotFound();
            }

            db.ClientesPersona.Remove(clientePersona);
            await db.SaveChangesAsync();

            return Ok(clientePersona);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientePersonaExists(int id)
        {
            return db.ClientesPersona.Count(e => e.Id == id) > 0;
        }
    }
}