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
            var student = await _context.Students.FindAsync(id);
            return student;
        }

        public async Task<IEnumerable<Student>> GetStudentsByName(string name)
        {
            IEnumerable<Student> students = 
                !string.IsNullOrWhiteSpace(name)
                ? await _context.Students.Where(n => n.Name.Contains(name)).ToListAsync() 
                : await GetStudents();

            return students;
        }

        public async Task CreateStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudent(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveStudent(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}
