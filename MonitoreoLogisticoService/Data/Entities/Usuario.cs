using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoService.Data.Entities
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }


        [StringLength(100,MinimumLength =3,ErrorMessage = "Este campo debe tener maximo 100 caracteres y minimo 3")]
        public string NombreUsuario { get; set; }


        [StringLength(30, MinimumLength = 5, ErrorMessage = "Este campo debe tener maximo 30 caracteres y minimo 5")]
        public string Contrasena { get; set; }

        [Required(ErrorMessage = "No se especifico un Rol asociado")]
        public int RolId { get; set; }
        
    }
}