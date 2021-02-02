using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoService.Data.Entities
{
    [Table("Zona")]
    public class Zona
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}