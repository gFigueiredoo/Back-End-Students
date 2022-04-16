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

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Student>>> GetStudents()
        {
            try
            {
                var students = await _studentService.GetStudents();
                return Ok(students);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getStudents");
            }
        }
    }
}
