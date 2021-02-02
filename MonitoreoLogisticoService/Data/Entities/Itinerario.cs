using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoService.Data.Entities
{
    [Table("Itinerario")]
    public class Itinerario
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int RepartidorId { get; set; }
        public int DetalleItinerarioId { get; set; }
        public int ZonaId { get; set; }
    }
}