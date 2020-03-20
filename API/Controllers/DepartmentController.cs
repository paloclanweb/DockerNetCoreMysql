using System.Threading.Tasks;
using Application.Repos;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly StudentContext _context;
        private readonly IDepartment _repo;
        public DepartmentController(IDepartment repo, StudentContext context )
        {
            _repo = repo;
            _context = context;
        }


        // Get department with given id.
        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            // var department = await _context.Departments.FindAsync(id);
            var department = await _repo.GetDepartment(id);
            if (department == null)
            {
                return NotFound();
            }
            return department;
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