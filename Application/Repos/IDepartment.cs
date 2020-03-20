using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;

namespace Application.Repos
{
    public interface IDepartment
    {
        Task<Department> GetDepartment(int id); 
    }
}