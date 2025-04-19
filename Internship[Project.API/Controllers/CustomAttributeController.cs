using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternshipProject.Domain.Entities;
using InternshipProject.Infrastructure.Data;

namespace InternshipProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomAttributeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomAttributeController(AppDbContext context)
        { 
            _context = context;
        }
        

        //GET : api/CustomAttribute
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomAttribute>>> GetCustomAttributes()
        {
            return await _context.CustomAttributes.ToListAsync();
        }

        //GET : api/CustomAttribute/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomAttribute>> GetCustomAttribute(Guid id)
        {
            var customAttribute = await _context.CustomAttributes.FindAsync(id);

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
            _context.CustomAttributes.Add(customAttribute);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomAttribute) , new {id  = customAttribute.Id}, customAttribute);
        }



    }
}
