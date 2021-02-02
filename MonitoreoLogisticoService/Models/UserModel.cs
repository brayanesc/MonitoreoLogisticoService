using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoService.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Especificar Nombre de Usuario!")]
        [Display(Name = "Nombre de Usuario")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "Especificar Contraseña!")]
        [Display(Name = "Contraseña")]
        [StringLength(25, ErrorMessage = "la {0} debe ser de por lo menos {2} caracteres", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }
    }
}