using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InternshipProject.Domain.Entities;
using InternshipProject.Infrastructure.Data;

namespace InternshipProject.Application.Services
{
    // Application/Services/CustomAttributeService.cs
    public class CustomAttributeService : ICustomAttributeService
    {
        private readonly AppDbContext _context;

        public CustomAttributeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CustomAttribute>> GetAllAsync()
        {
            return await _context.CustomAttributes.ToListAsync();
        }

        public async Task<CustomAttribute> GetByIdAsync(Guid id)
        {
            return await _context.CustomAttributes.FindAsync(id);
        }

        public async Task<CustomAttribute> CreateAsync(CustomAttribute customAttribute)
        {
            _context.CustomAttributes.Add(customAttribute);
            await _context.SaveChangesAsync();
            return customAttribute;
        }

        public async Task<bool> UpdateAsync(Guid id, CustomAttribute customAttribute)
        {
            if (id != customAttribute.Id)
            {
                return false;
            }

            _context.Entry(customAttribute).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var customAttribute = await _context.CustomAttributes.FindAsync(id);
            if (customAttribute == null)
            {
                return false;
            }

            _context.CustomAttributes.Remove(customAttribute);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
