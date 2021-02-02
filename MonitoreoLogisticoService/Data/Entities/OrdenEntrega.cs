using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoService.Data.Entities
{
    [Table("OrdenEntrega")]
    public class OrdenEntrega
    {
        [Key]
        public int Id { get; set; }
        public DateTime FecharEmision { get; set; }
        public string NroFactura { get; set; }
        public string Estado { get; set; }
        public string Prioridad { get; set; }
        public int ItinerarioId { get; set; }
        public int ClienteId { get; set; }
    }
}