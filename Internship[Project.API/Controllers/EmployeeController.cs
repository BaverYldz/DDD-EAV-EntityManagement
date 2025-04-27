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
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
           var employees = await _employeeService.GetAllAsync();
            return Ok(employees);
        }


        //GET by Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetById(Guid id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }


        //POST
        [HttpPost]
        public async Task<ActionResult<Employee>> Create(Employee employee)
        {
            var createdEmployee = await _employeeService.CreateAsync(employee);
            return CreatedAtAction(nameof(GetById), new { id = createdEmployee.Id }, createdEmployee);

        }

        // PUT api/employee/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            var result = await _employeeService.UpdateAsync(id, employee);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
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
