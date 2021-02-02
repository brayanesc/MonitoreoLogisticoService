using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoService.Models.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private List<Student> student = new List<Student>
        {

            new Student { StudentId = 1, Studentname = "rajeev", StudentAddress = "Noida" },
            new Student { StudentId = 2, Studentname = "rohit", StudentAddress = "Pune" },
            new Student { StudentId = 3, Studentname = "Manish", StudentAddress = "Mumbai" },
            new Student { StudentId = 4, Studentname = "Mohit", StudentAddress = "Delhi" },
            new Student { StudentId = 5, Studentname = "Rajeev Ranjan", StudentAddress = "Hazaribagh" }
    };

        public IEnumerable<Student> GetAll()
        {
            return student;
        }
        public Student GetById(int id)
        {
            return student.Find(x => x.StudentId == id);
        }
    }
}