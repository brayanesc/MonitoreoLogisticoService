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
    public class RolesController : ApiController
    {
        private MonitoreoContext db = new MonitoreoContext();

        // GET: api/Roles
        public List<Rol> GetRoles()
        {
            return db.Roles.ToList();
        }

        // GET: api/Roles/5
        [ResponseType(typeof(Rol))]
        public async Task<IHttpActionResult> GetRol(int id)
        {
            Rol rol = await db.Roles.FindAsync(id);
            if (rol == null)
            {
                return NotFound();
            }

            return Ok(rol);
        }

        // PUT: api/Roles/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRol(int id, Rol rol)
        {
            if (rol == null)
            {
                return BadRequest("El modelo esta vacio");
            }


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (rol.Id == 0 && id > 0)
            {
                rol.Id = id;
            }

            //if (id != rol.Id)
            //{
            //    return BadRequest();
            //}

            db.Entry(rol).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            Rol r = db.Roles.Find(id);
            return Ok(r);
        }

        // POST: api/Roles
        [ResponseType(typeof(Rol))]
        public async Task<IHttpActionResult> PostRol(Rol rol)
        {
            if (rol == null)
            {
                return BadRequest("El modelo esta vacio");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Roles.Add(rol);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = rol.Id }, rol);
        }

        // DELETE: api/Roles/5
        [ResponseType(typeof(Rol))]
        public async Task<IHttpActionResult> DeleteRol(int id)
        {
            Rol rol = await db.Roles.FindAsync(id);
            if (rol == null)
            {
                return NotFound();
            }

            db.Roles.Remove(rol);
            await db.SaveChangesAsync();

            return Ok(rol);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RolExists(int id)
        {
            return db.Roles.Count(e => e.Id == id) > 0;
        }
    }
}