using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoService.Models.Requests
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Especificar Nombre de Usuario!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Especificar Contraseña!")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
    }
}