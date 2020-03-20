using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Persistence;

namespace Application.Repos
{
    public class DepartmentRepo : IDepartment
    {
        private readonly StudentContext _context;
        public DepartmentRepo(StudentContext context)
        {
            _context = context;

        }

        public async Task<Department> GetDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            return department;
        }
    }
}