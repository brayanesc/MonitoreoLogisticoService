using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoService.Data.Entities
{
    [Table("Rol")]
    public class Rol
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage ="Este campo no puede estar vacio")]
        [StringLength(100,MinimumLength =3,ErrorMessage = "Este campo debe tener maximo 100 caracteres y minimo 3")]
        public string NombreRol { get; set; }
    }
}