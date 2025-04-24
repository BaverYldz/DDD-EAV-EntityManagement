using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternshipProject.Domain.Entities;
using InternshipProject.Infrastructure.Data;

namespace InternshipProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttributeValueController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AttributeValueController(AppDbContext context)
        {
            _context = context;
        }


        //GET 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttributeValue>>> GetAttributeValue()
        {
            return await _context.AttributeValues
                .Include(av => av.Employee)
                .Include(av => av.CustomAttribute)
                .ToListAsync();
        }


        //POST 
        [HttpPost]
        public async Task<ActionResult<AttributeValue>> PostAttributeValue(AttributeValue attributeValue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AttributeValues.Add(attributeValue);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAttributeValue), new { id = attributeValue.Id }, attributeValue);
        }
    }
}
