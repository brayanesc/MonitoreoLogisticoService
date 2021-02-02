using MonitoreoLogisticoService.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MonitoreoLogisticoService.Controllers
{
    public class studentController : ApiController
    {
        StudentRepository _student = new StudentRepository();

        // GET: api/student
        public IEnumerable<Student> Get()
        {
            return _student.GetAll();
        }

        // GET: api/student/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/student
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/student/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/student/5
        public void Delete(int id)
        {
        }
    }
}
