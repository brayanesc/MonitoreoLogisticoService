using MonitoreoLogisticoService.Data;
using MonitoreoLogisticoService.Data.Entities;
using MonitoreoLogisticoService.Models;
using MonitoreoLogisticoService.Models.Requests;
using MonitoreoLogisticoService.Models.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace MonitoreoLogisticoService.Controllers.Accesos
{
    [RoutePrefix("Accesos")]
    public class AccesosController : ApiController
    {
        private MonitoreoContext db = new MonitoreoContext();

        // GET: Accesos
        [AllowAnonymous]
        [ResponseType(typeof(TokenResponse))]
        [Route("ObtenerToken")]
        public IHttpActionResult ObtenerToken(UserModel usuario)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string resultContent = "";
            var token = new TokenResponse();
            using (HttpClient httpClient = new HttpClient())
            {

                HttpContent content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("grant_type","password"),
                    new KeyValuePair<string,string>("username",usuario.NombreUsuario),
                    new KeyValuePair<string,string>("password",usuario.Contrasena)

                });
                HttpResponseMessage result = httpClient.PostAsync("http://localhost/MonitoreoLogisticoService/token", content).Result;
                resultContent = result.Content.ReadAsStringAsync().Result;

                token = JsonConvert.DeserializeObject<TokenResponse>(resultContent);

            }

            return Ok(token);
        }

        [AllowAnonymous]
        [Route("IniciarSesion")]
        [HttpPost]
        public IHttpActionResult IniciarSesion([FromBody] LoginRequest model)
        {

            List<Usuario> usuarios = db.Usuarios.ToList();
            try
            {
                var usuarioa = usuarios.FirstOrDefault(x => x.NombreUsuario == model.Username);
                Usuario usuario = usuarios.FirstOrDefault(x => x.NombreUsuario == model.Username && x.Contrasena == model.Password);


                if (usuario != null)
                {
                    List<EncargadoLogistica> encargados = db.EncargadosLogistica.ToList();
                    List<Repartidor> repartidores = db.Repartidores.ToList();

                    EncargadoLogistica encargado = encargados.FirstOrDefault(x => x.UsuarioId == usuario.Id);

                    Repartidor repartidor = repartidores.FirstOrDefault(x => x.UsuarioId == usuario.Id);

                    if (encargado != null)
                    {
                        LoginResponse res = new LoginResponse();
                        var token = new TokenResponse();
                        using (HttpClient httpClient = new HttpClient())
                        {

                            HttpContent content = new FormUrlEncodedContent(new[]
                            {
                            new KeyValuePair<string,string>("grant_type","password"),
                            new KeyValuePair<string,string>("username",usuario.NombreUsuario),
                            new KeyValuePair<string,string>("password",usuario.Contrasena)

                        });
                            //HttpResponseMessage result = httpClient.PostAsync("http://localhost/MonitoreoLogisticoService/token", content).Result;
                            HttpResponseMessage result = httpClient.PostAsync("http://localhost:5757/token", content).Result;
                            var resultContent = result.Content.ReadAsStringAsync().Result;

                            token = JsonConvert.DeserializeObject<TokenResponse>(resultContent);

                            res.NombreCompleto = encargado.NombreCompleto;
                            res.Email = encargado.Email;
                            res.EncargadoId = encargado.Id;
                            res.Token = token.access_token;

                            var json = JToken.FromObject(res);
                            return Ok(json);

                        }
                    }
                    else
                    {
                        if (repartidor != null)
                        {
                            LoginResponse res = new LoginResponse();
                            var token = new TokenResponse();
                            using (HttpClient httpClient = new HttpClient())
                            {

                                HttpContent content = new FormUrlEncodedContent(new[]
                                {
                            new KeyValuePair<string,string>("grant_type","password"),
                            new KeyValuePair<string,string>("username",usuario.NombreUsuario),
                            new KeyValuePair<string,string>("password",usuario.Contrasena)

                        });
                                //HttpResponseMessage result = httpClient.PostAsync("http://localhost/MonitoreoLogisticoService/token", content).Result;
                                HttpResponseMessage result = httpClient.PostAsync("http://localhost:5757/token", content).Result;
                                var resultContent = result.Content.ReadAsStringAsync().Result;

                                token = JsonConvert.DeserializeObject<TokenResponse>(resultContent);

                                res.NombreCompleto = repartidor.NombreCompleto;
                                res.Email = repartidor.Email;
                                res.EncargadoId = repartidor.Id;
                                res.Token = token.access_token;

                                var json = JToken.FromObject(res);
                                return Ok(json);

                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {
                var a = e.Message;
            }
            return BadRequest();

        }
    }
}