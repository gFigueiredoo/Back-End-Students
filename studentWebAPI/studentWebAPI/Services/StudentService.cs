using Microsoft.EntityFrameworkCore;
using studentWebAPI.Context;
using studentWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentWebAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            var students = await _context.Students.ToListAsync();
            return students;
        }
        public async Task<Student> GetStudent(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Student>> GetStudentsByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task CreateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
