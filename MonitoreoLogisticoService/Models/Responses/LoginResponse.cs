using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoService.Models.Responses
{
    public class LoginResponse
    {
        public string NombreCompleto { get;set; }
        public string Email { get; set; }
        public int EncargadoId { get; set; }
        public string Token { get; set; }
        
    }
}