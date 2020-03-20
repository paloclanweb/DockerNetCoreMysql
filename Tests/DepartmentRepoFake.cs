using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repos;
using Domain;
using Persistence;
using Xunit;

namespace Tests
{
    public class DepartmentRepoFake : IDepartment
    {
        private readonly List<Department> _departments;
        public DepartmentRepoFake()
        {
            _departments = new List<Department>()
            {
                new Department() 
                {
                    ID =   1,
                    Name = "Department A"
                },
                new Department()
                {
                    ID =   2,
                    Name = "Department B"
                },
                new Department()
                {
                    ID =   3,
                    Name = "Department C"
                }
            };
        }
       
        public Task<Department> GetDepartment(int id)
        {
            var department = _departments.Find(a => a.ID == id);
            return Task.FromResult(department);
        }
    }
}