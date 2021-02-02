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
    //public class OrdenEntregasController : ApiController
    //{
    //    private MonitoreoContext db = new MonitoreoContext();

    //    // GET: api/OrdenEntregas
    //    public List<OrdenEntregas> Getordenentregas()
    //    {
    //        return db.ordenentregas.ToList();
    //    }

    //    // GET: api/OrdenEntregas/5
    //    [ResponseType(typeof(OrdenEntregas))]
    //    public IHttpActionResult GetOrdenEntregas(int id)
    //    {
    //        OrdenEntregas ordenEntregas = db.ordenentregas.Find(id);
    //        if (ordenEntregas == null)
    //        {
    //            return NotFound();
    //        }

    //        return Ok(ordenEntregas);
    //    }

    //    // PUT: api/OrdenEntregas/5
    //    [ResponseType(typeof(void))]
    //    public IHttpActionResult PutOrdenEntregas(int id, OrdenEntregas ordenEntregas)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

    //        if (id != ordenEntregas.codigoOrdenEntrega)
    //        {
    //            return BadRequest();
    //        }

    //        db.Entry(ordenEntregas).State = EntityState.Modified;

    //        try
    //        {
    //            db.SaveChanges();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!OrdenEntregasExists(id))
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

    //    // POST: api/OrdenEntregas
    //    [ResponseType(typeof(OrdenEntregas))]
    //    public IHttpActionResult PostOrdenEntregas(OrdenEntregas ordenEntregas)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

    //        db.ordenentregas.Add(ordenEntregas);
    //        db.SaveChanges();

    //        return CreatedAtRoute("DefaultApi", new { id = ordenEntregas.codigoOrdenEntrega }, ordenEntregas);
    //    }

    //    // DELETE: api/OrdenEntregas/5
    //    [ResponseType(typeof(OrdenEntregas))]
    //    public IHttpActionResult DeleteOrdenEntregas(int id)
    //    {
    //        OrdenEntregas ordenEntregas = db.ordenentregas.Find(id);
    //        if (ordenEntregas == null)
    //        {
    //            return NotFound();
    //        }

    //        db.ordenentregas.Remove(ordenEntregas);
    //        db.SaveChanges();

    //        return Ok(ordenEntregas);
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //            db.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }

    //    private bool OrdenEntregasExists(int id)
    //    {
    //        return db.ordenentregas.Count(e => e.codigoOrdenEntrega == id) > 0;
    //    }
    //}
}