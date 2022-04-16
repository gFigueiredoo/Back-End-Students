using studentWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentWebAPI.Services
{
    interface IStudentService
    {
        Task<IEnumerable<Student>> GetStudents();

        Task<Student> GetStudent(int id);

        Task<IEnumerable<Student>> GetStudentsByName(string name);

        Task CreateStudent(Student student);

        Task UpdateStudent(Student student);

        Task RemoveStudent(Student student);
    }
}
