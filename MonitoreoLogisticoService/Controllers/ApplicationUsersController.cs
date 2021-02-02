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
using MonitoreoLogisticoService.Data.Repositories;
using MonitoreoLogisticoService.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MonitoreoLogisticoService.Controllers
{
    public class ApplicationUsersController : ApiController
    {
        private MonitoreoContext db = new MonitoreoContext();
        //private ApplicationUserRepositorio user_repo = new ApplicationUserRepositorio();

        [HttpPost]
        [AllowAnonymous]
        [ResponseType(typeof(TokenResponse))]
        [Route("GetToken")]
        public IHttpActionResult GetToken(UserModel usuariologin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string resultContent = "";
            var token = new TokenResponse();
            using (HttpClient httpClient = new HttpClient()) {

                HttpContent content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("grant_type","password"),
                    new KeyValuePair<string,string>("UserName",usuariologin.UserName),
                    new KeyValuePair<string,string>("Password",usuariologin.Password)

                });
                HttpResponseMessage result = httpClient.PostAsync("http://localhost:52517/token", content).Result;
                resultContent = result.Content.ReadAsStringAsync().Result;

                token = JsonConvert.DeserializeObject<TokenResponse>(resultContent);

            }

            return Ok(token);

        }



        // GET: api/ApplicationUsers
        public List<Data.Entities.Usuario> GetApplicationUsers()
        {
            //List<ApplicationUser> users = user_repo.GetAll().ToList();
            //return users;
            return db.Usuarios.ToList();
        }

        // GET: api/ApplicationUsers/5
        [ResponseType(typeof(Data.Entities.ApplicationUser))]
        public IHttpActionResult GetApplicationUser(int id)
        {
            Data.Entities.Usuario applicationUser = db.Usuarios.Find(id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return Ok(applicationUser);
        }

        // PUT: api/ApplicationUsers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutApplicationUser(int id, Data.Entities.ApplicationUser applicationUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != applicationUser.Id)
            {
                return BadRequest();
            }

            db.Entry(applicationUser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationUserExists(id))
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

        // POST: api/ApplicationUsers
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult PostApplicationUser(Usuario applicationUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Usuarios.Add(applicationUser);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = applicationUser.Id }, applicationUser);
        }

        // DELETE: api/ApplicationUsers/5
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult DeleteApplicationUser(int id)
        {
            Usuario applicationUser = db.Usuarios.Find(id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            db.Usuarios.Remove(applicationUser);
            db.SaveChanges();

            return Ok(applicationUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApplicationUserExists(int id)
        {
            return db.ApplicationUsers.Count(e => e.Id == id) > 0;
        }
    }
}