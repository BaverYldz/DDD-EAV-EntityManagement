using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternshipProject.Domain.Entities;
using InternshipProject.Infrastructure.Data;
using InternshipProject.Application.Interfaces;


namespace InternshipProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        //GET
        [HttpGet]
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
           var employees = await _employeeService.GetAllAsync();
            return employees;
        }


        //GET by Id
        [HttpGet("{id}")]
        public async Task<Employee> GetById(Guid id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null)
            {
                return null;
            }
            return employee;
        }


        //POST
        [HttpPost]
        public async Task<Employee> Create(Employee employee)
        {
            var createdEmployee = await _employeeService.CreateAsync(employee);
            return createdEmployee;

        }

        // PUT api/employee/{id}
        [HttpPut]
        public async Task<Employee> Update(Employee employee)
        {
          
            var result = await _employeeService.UpdateAsync(employee);
            return result;
        }

        // DELETE api/employee/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _employeeService.DeleteAsync(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
