using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoService.Data.Entities
{
    [Table("EncargadoLogistica")]
    public class EncargadoLogistica
    {
        [Key]
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string CI { get; set; }
        public int Edad { get; set; }
        public int UsuarioId { get; set; }
    }
}