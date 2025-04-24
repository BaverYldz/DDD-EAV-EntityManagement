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

        //GET : api/CustomAttribute/id
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CustomAttributes.Add(customAttribute);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomAttribute) , new {id  = customAttribute.Id}, customAttribute);
        }



        //PUT api/CustomAttribute/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomAttribute(Guid id, CustomAttribute customAttribute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (id != customAttribute.Id)
            {
                return BadRequest();
            }

            _context.Entry(customAttribute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomAttributeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }


            }
            return NoContent();
        }

        private bool CustomAttributeExists(Guid id)
        {
            return _context.CustomAttributes.Any(e => e.Id == id);
        }


        //DELETE api/CustomAttribute/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomAttribute(Guid id)
        {
            var customAttribute = await _context.CustomAttributes.FindAsync(id);
            if (customAttribute != null)
            {
                return NotFound();
            }

            _context.CustomAttributes.Remove(customAttribute);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
