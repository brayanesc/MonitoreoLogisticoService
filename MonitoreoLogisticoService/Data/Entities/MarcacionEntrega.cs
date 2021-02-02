using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoService.Data.Entities
{
    [Table("MarcacionEntrega")]
    public class MarcacionEntrega
    {
        [Key]
        public int Id { get; set; }
        public DateTime Hora { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public int OrdenEntregaId { get; set; }
    }
}