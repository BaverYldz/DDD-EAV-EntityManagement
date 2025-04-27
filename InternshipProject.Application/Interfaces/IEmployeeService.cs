using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternshipProject.Domain.Entities;

namespace InternshipProject.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(Guid id);
        Task<Employee> CreateAsync(Employee employee);

        Task <bool> UpdateAsync(Guid id, Employee employee);    

        Task <bool> DeleteAsync(Guid id);
    }
}
