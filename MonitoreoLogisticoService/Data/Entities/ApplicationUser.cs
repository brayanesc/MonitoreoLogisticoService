using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoService.Data.Entities
{
    [Table("ApplicationUser")]
    public class ApplicationUser
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        //[ForeignKey("UserRole")]
        public int RoleId { get; set; }

        //public virtual UserRole UserRole { get; set; }
    }
}