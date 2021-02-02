using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoService.Data.Entities
{
    [Table("DetalleItinerario")]
    public class DetalleItinerario
    {
        [Key]
        public int Id { get; set; }
        public DateTime? Salida { get; set; }
        public DateTime? Llegada { get; set; }
    }
}