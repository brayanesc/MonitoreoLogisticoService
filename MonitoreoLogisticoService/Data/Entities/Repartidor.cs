using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoService.Data.Entities
{
    [Table("Repartidor")]
    public class Repartidor
    {
        public Repartidor()
        {
            this.FechaIngreso = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }


        [StringLength(100, ErrorMessage = "Este campo debe tener maximo 100 caracteres")]
        public string NombreCompleto { get; set; }


        [StringLength(15,MinimumLength = 7,ErrorMessage = "Este campo debe tener maximo 15 caracteres y minimo 7")]
        public string Telefono { get; set;}


        [StringLength(30, ErrorMessage = "Este campo debe tener maximo 30 caracteres")]
        public string Email { get; set; }


        public DateTime FechaIngreso { get; set; }


        [StringLength(15, ErrorMessage = "Este campo debe tener maximo 15 caracteres")]
        public string CI { get; set; }


        public int Edad { get; set; }


        [Required(ErrorMessage ="No se especifico un Usuario asociado")]
        public int UsuarioId { get; set; }
        
    }
}