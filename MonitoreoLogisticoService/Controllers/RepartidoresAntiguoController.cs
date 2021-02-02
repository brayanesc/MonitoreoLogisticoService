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
using MonitoreoLogisticoService.Data.Entities;

namespace MonitoreoLogisticoService.Controllers
{
    //public class RepartidoresController : ApiController
    //{
    //    private MonitoreoContext db = new MonitoreoContext();

    //    // GET: api/Repartidores
    //    public IQueryable<Repartidores> Getrepartidores()
    //    {
    //        return db.repartidores;
    //    }

    //    // GET: api/Repartidores/5
    //    [ResponseType(typeof(Repartidores))]
    //    public IHttpActionResult GetRepartidores(int id)
    //    {
    //        Repartidores repartidores = db.repartidores.Find(id);
    //        if (repartidores == null)
    //        {
    //            return NotFound();
    //        }

    //        return Ok(repartidores);
    //    }

    //    // PUT: api/Repartidores/5
    //    [ResponseType(typeof(void))]
    //    public IHttpActionResult PutRepartidores(int id, Repartidores repartidores)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

    //        if (id != repartidores.codigoRepartidor)
    //        {
    //            return BadRequest();
    //        }

    //        db.Entry(repartidores).State = EntityState.Modified;

    //        try
    //        {
    //            db.SaveChanges();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!RepartidoresExists(id))
    //            {
    //                return NotFound();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //        return StatusCode(HttpStatusCode.NoContent);
    //    }

    //    // POST: api/Repartidores
    //    [ResponseType(typeof(Repartidores))]
    //    public IHttpActionResult PostRepartidores(Repartidores repartidores)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

    //        db.repartidores.Add(repartidores);
    //        db.SaveChanges();

    //        return CreatedAtRoute("DefaultApi", new { id = repartidores.codigoRepartidor }, repartidores);
    //    }

    //    // DELETE: api/Repartidores/5
    //    [ResponseType(typeof(Repartidores))]
    //    public IHttpActionResult DeleteRepartidores(int id)
    //    {
    //        Repartidores repartidores = db.repartidores.Find(id);
    //        if (repartidores == null)
    //        {
    //            return NotFound();
    //        }

    //        db.repartidores.Remove(repartidores);
    //        db.SaveChanges();

    //        return Ok(repartidores);
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //            db.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }

    //    private bool RepartidoresExists(int id)
    //    {
    //        return db.repartidores.Count(e => e.codigoRepartidor == id) > 0;
    //    }
    //}
}