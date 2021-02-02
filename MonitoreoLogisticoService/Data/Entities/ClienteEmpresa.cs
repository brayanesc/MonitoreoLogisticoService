using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoService.Data.Entities
{
    [Table("ClienteEmpresa")]
    public class ClienteEmpresa
    {
        [Key]
        public int Id { get; set; }
        public string Abreviacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Sociedad { get; set; }
        public string Rubro { get; set; }
    }
}