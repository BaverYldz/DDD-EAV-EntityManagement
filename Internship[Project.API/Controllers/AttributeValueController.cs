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
    public class AttributeValueController : ControllerBase
    {
        private readonly IAttributeValueService _attributeValueService;

        public AttributeValueController(IAttributeValueService attributeValueService)
        {
            _attributeValueService = attributeValueService;
        }


        //GET 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttributeValue>>> GetAttributeValue()
        {
            var attributeValues = await _attributeValueService.GetAllAsync();
            return Ok(attributeValues);
        }


        //GET By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<AttributeValue>> GetAttributeValue(Guid id)
        {
            var attributeValue = await _attributeValueService.GetByIdAsync(id);
            if (attributeValue == null)
                return NotFound();
            return Ok(attributeValue);
        }


        //POST 
        [HttpPost]
        public async Task<ActionResult<AttributeValue>> PostAttributeValue(AttributeValue attributeValue)
        {
            var created = await _attributeValueService.CreateAsync(attributeValue);
            return CreatedAtAction(nameof(GetAttributeValue), new { id = created.Id }, created);
        }


        //PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttributeValue(Guid id, AttributeValue attributeValue)
        {
            var result = await _attributeValueService.UpdateAsync(id, attributeValue);
            if (!result)
                return BadRequest();
            return NoContent();
        }


        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttributeValue(Guid id)
        {
            var result = await _attributeValueService.DeleteAsync(id);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}
