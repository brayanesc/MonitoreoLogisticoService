using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoreoLogisticoService.Models.Repositories
{
    interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student GetById(int id);
    }
}
