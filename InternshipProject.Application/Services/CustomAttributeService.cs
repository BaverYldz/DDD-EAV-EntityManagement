using InternshipProject.Infrastructure.Data;
using System;
using System.Reflection.Metadata;


namespace InternshipProject.Application.Services
{
    public class CustomAttributeService : ICustomAttributeService
    {
        private readonly AppDbContext _context;

        public CustomAttributeService(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<CustomAttribute> CreateAsync(CustomAttribute customAttribute)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CustomAttribute>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CustomAttribute> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Guid id, CustomAttribute customAttribute)
        {
            throw new NotImplementedException();
        }
    }
}
