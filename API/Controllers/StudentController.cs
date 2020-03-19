using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    [Route("/api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentContext _context;
        public StudentController(StudentContext context)
        {
            _context = context;
        }

        // Get student with id.
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        // Add new student to _context.
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var dept = await _context.Departments.FindAsync(student.DepartmentID);
            if (dept == null)
            {
                ModelState.AddModelError("Department ID", $"Department {student.DepartmentID} does not exist");
                return BadRequest(ModelState);
            }
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return Ok(new { StudentID = student.ID });
        }
    }

}