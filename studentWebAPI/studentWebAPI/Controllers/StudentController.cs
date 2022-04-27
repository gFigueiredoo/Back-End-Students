using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using studentWebAPI.Models;
using studentWebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class StudentController : ControllerBase
    {
        private IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Student>>> GetStudents()
        {
            var students = await _studentService.GetStudents();

            if (students == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getStudents");
            }

            return Ok(students);
        }

        [HttpGet("StudentsForName")]
        public async Task<ActionResult<IAsyncEnumerable<Student>>> GetStudentsByName([FromQuery] string name)
        {

            var students = await _studentService.GetStudentsByName(name);

            if (students == null)
            {
                return NotFound($"There isn't students with the {name} name");
            }

            return Ok(students);
        }

        [HttpGet("{id:int}", Name = "GetStudent")]
        public async Task<ActionResult<IAsyncEnumerable<Student>>> GetStudent(int id)
        {
            var students = await _studentService.GetStudent(id);

            if (students == null)
            {
                return NotFound($"There isn't students with id = {id}");
            }

            return Ok(students);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Student student)
        {
            await _studentService.CreateStudent(student);
            return CreatedAtRoute(nameof(GetStudent), new { id = student.Id }, student);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromQuery] Student student)
        {
            if (student.Id == id)
            {
                await _studentService.UpdateStudent(student);
                return Ok($"Student {student.Name} updated");
            }

            return BadRequest("error when trying to edit");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Remove(int id)
        {
            var student = await _studentService.GetStudent(id);

            if (student == null)
            {
                return NotFound($"{student.Name} student don't found");
            }

            await _studentService.RemoveStudent(student);
            return Ok($"{student.Name} student removed");
        }
    }
}
