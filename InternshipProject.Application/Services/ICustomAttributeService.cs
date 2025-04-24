using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace InternshipProject.Application.Services
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
