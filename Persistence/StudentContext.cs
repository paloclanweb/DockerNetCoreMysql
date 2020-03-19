using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
               : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Department> Departments { get; set; }
    }
}