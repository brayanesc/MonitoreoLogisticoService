using MonitoreoLogisticoService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MonitoreoLogisticoService.Controllers
{

    public class UserAccessController : ApiController
    {
        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult GetToken(UserModel usuariologin)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            string resultContent = "";
            using (HttpClient httpClient = new HttpClient())
            {

                HttpContent content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("grant_type","password"),
                    new KeyValuePair<string,string>("UserName",usuariologin.UserName),
                    new KeyValuePair<string,string>("Password",usuariologin.Password)

                });
                HttpResponseMessage result = httpClient.PostAsync("http://localhost:52517/token", content).Result;
                resultContent = result.Content.ReadAsStringAsync().Result;

            }

            return Ok(resultContent);

        }
    }
}
