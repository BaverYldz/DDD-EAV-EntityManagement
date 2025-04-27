using InternshipProject.Application.Interfaces;
using InternshipProject.Domain.Entities;
using InternshipProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class AttributeValueService : IAttributeValueService
{
    private readonly AppDbContext _context;

    public AttributeValueService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<AttributeValue>> GetAllAsync()
    {
        return await _context.AttributeValues
            .Include(av => av.Employee)
            .Include(av => av.CustomAttribute)
            .ToListAsync();
    }

    public async Task<AttributeValue> GetByIdAsync(Guid id)
    {
        return await _context.AttributeValues
            .Include(av => av.Employee)
            .Include(av => av.CustomAttribute)
            .FirstOrDefaultAsync(av => av.Id == id);
    }

    public async Task<AttributeValue> CreateAsync(AttributeValue attributeValue)
    {
        _context.AttributeValues.Add(attributeValue);
        await _context.SaveChangesAsync();
        return attributeValue;
    }

    public async Task<bool> UpdateAsync(Guid id, AttributeValue attributeValue)
    {
        if (id != attributeValue.Id)
            return false;

        _context.Entry(attributeValue).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var attributeValue = await _context.AttributeValues.FindAsync(id);
        if (attributeValue == null)
            return false;

        _context.AttributeValues.Remove(attributeValue);
        await _context.SaveChangesAsync();
        return true;
    }
}
