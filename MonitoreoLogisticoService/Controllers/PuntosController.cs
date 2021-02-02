using MonitoreoLogisticoService.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MonitoreoLogisticoService.Controllers
{
    [RoutePrefix("api")]
    public class PuntosController : ApiController
    {
        // GET: Puntos
        [Route("puntos")]
        [HttpPost]
        public async Task<IHttpActionResult> CargarCoordenadas(ZonaCoordenadas_dto data)
        {
            return Ok(data);
        }
    }
}