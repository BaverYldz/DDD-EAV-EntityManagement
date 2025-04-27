using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternshipProject.Domain.Entities;


namespace InternshipProject.Application.Interfaces
{
    public interface ICustomAttributeService
    {
        Task<List<CustomAttribute>> GetAllAsync();
        Task<CustomAttribute> GetByIdAsync(Guid id);
        Task<CustomAttribute> CreateAsync(CustomAttribute customAttribute);
        Task<bool> UpdateAsync(Guid id, CustomAttribute customAttribute);
        Task<bool> DeleteAsync(Guid id);
    }
}
