using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoService.Models.Responses
{
    public class OrdenEntregaResponse
    {
        public int Id { get; set; }
        public DateTime FechaEmision { get; set; }
        public string NroFactura { get; set; }
        public string Estado { get; set; }
        public string Prioridad { get; set; }
        public int ItinerarioId { get; set; }

        //datos cliente
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string TelefonoCliente { get; set; }

        //datos Ubicacion
        public string DescripcionUbicacion { get; set; }
        public string LatitudUbicacion { get; set; }
        public string LongitudUbicacion { get; set; }


    }
}