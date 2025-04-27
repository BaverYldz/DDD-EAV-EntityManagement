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
    public class CustomAttributeController : ControllerBase
    {
 
        private readonly ICustomAttributeService _customAttributeService;

        public CustomAttributeController(ICustomAttributeService customAttributeService)
        {
            _customAttributeService = customAttributeService;
        }


        //GET : api/CustomAttribute
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomAttribute>>> GetCustomAttributes()
        {
            var customAttributes = await _customAttributeService.GetAllAsync();
            return Ok(customAttributes);
        }

        //GET : api/CustomAttribute/id
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomAttribute>> GetCustomAttribute(Guid id)
        {
            var customAttribute = await _customAttributeService.GetByIdAsync(id);

            if (customAttribute == null)
            {
                return NotFound();
            }

            return Ok(customAttribute);
        }


        //POST : api/CustomAttribute
        [HttpPost]
        public async Task<ActionResult<CustomAttribute>> PostCustomAttribute(CustomAttribute customAttribute)
        {
           var createdCustomAttribute = await _customAttributeService.CreateAsync(customAttribute);
            return CreatedAtAction(nameof(GetCustomAttribute), new { id = createdCustomAttribute.Id }, createdCustomAttribute);
        }



        //PUT api/CustomAttribute/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomAttribute(Guid id, CustomAttribute customAttribute)
        {
            var updated = await _customAttributeService.UpdateAsync(id, customAttribute);
            if(!updated)
            {
                return BadRequest();
            }

            return NoContent();
        }

        


        //DELETE api/CustomAttribute/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomAttribute(Guid id)
        {
            var deleted = await _customAttributeService.DeleteAsync(id);
            if(!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}
