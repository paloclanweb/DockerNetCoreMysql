using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly StudentContext _context;
        public DepartmentController(StudentContext context)
        {
            _context = context;
        }


        // Get department with given id.
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == default(Department))
            {
                return NotFound();
            }
            return Ok(department);
        }

        // Add a department to _context.
        [HttpPost]
        public async Task<IActionResult> AddDepartment([FromBody] Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _context.AddAsync(department);
            await _context.SaveChangesAsync();
            return Ok(department.ID);
        }

    }
}