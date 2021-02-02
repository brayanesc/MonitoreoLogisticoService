using MonitoreoLogisticoService.Data;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace MonitoreoLogisticoService.Controllers
{
    public class ReportesController : ApiController
    {
        private MonitoreoContext db = new MonitoreoContext();

        // GET: Reportes
        [Route("api/Reportes/MotivoNoEntregas")]
        [HttpGet]
        public List<JObject> MotivoNoEntregas() {
            var response = new List<JObject>();
            var motivos = db.MotivoNoEntregas.ToList();
            var marcaciones = db.MarcacionEntregas.ToList();
            var ordenes = db.OrdenEntregas.ToList();
            var itinerarios = db.Itinerarios.ToList();

            foreach (var x in motivos) {
                var marcacion = marcaciones.Find(y => y.Id == x.MarcacionId);
                var orden = ordenes.Find(z => z.Id == marcacion.OrdenEntregaId);
                var itinerario = itinerarios.Find(a => a.Id == orden.ItinerarioId);

                var result = new JObject();
                result.Add("Factura", orden.NroFactura);
                result.Add("Itinerario", itinerario.Descripcion);
                result.Add("Fecha", marcacion.Fecha);
                result.Add("Motivo", x.Descripcion);

                response.Add(result);
            }


            return response;
        }

        [Route("api/Reportes/CumplimientoXRepartidor")]
        [HttpGet]
        public List<JObject> CumplimientoXRepartidor() {
            var response = new List<JObject>();

            var ordenes = db.OrdenEntregas.ToList();
            var clientes = db.Clientes.ToList();
            var repartidores = db.Repartidores.ToList();

            foreach (var o in ordenes) {
                var result = new JObject();

                var cliente = clientes.Find(x => x.Id == o.ClienteId);

                result.Add("CodigoCliente", cliente.Id);
                result.Add("Factura", o.NroFactura);
                result.Add("NombreCliente", cliente.Nombre + " " + cliente.ApellidoMaterno + " " + cliente.ApellidoPaterno);
                result.Add("Estado", o.Estado);

                response.Add(result);

            }
            

            return response;
        }


        [Route("api/Reportes/MarcacionesSemanales")]
        [HttpGet]
        public List<JObject> MarcacionesSemanales() {
            var response = new List<JObject>();

            var noentregas = db.MotivoNoEntregas.ToList();
            var marcaciones = db.MarcacionEntregas.ToList();
            var ordenes = db.OrdenEntregas.ToList();

            foreach (var m in marcaciones) {
                var result = new JObject();

                var orden = ordenes.Find(x => x.Id == m.OrdenEntregaId);

                result.Add("Orden", orden.Id);
                result.Add("Itinerario", orden.ItinerarioId);
                result.Add("FechaEmision", orden.FechaEmision);
                result.Add("Cliente", orden.ClienteId);
                result.Add("Estado", orden.Estado);
                result.Add("Factura", orden.NroFactura);
                result.Add("Fecha", m.Fecha);

                response.Add(result);

                
            }

            return response;

        }
        
    }
}