using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternshipProject.Domain.Entities;

namespace InternshipProject.Application.Interfaces
{
    public interface IAttributeValueService
    {
        Task<List<AttributeValue>> GetAllAsync();
        Task<AttributeValue> GetByIdAsync(Guid id);

        Task<AttributeValue> CreateAsync(AttributeValue attrivuteValue);

        Task<bool> UpdateAsync(Guid id, AttributeValue attributevalue);

        Task<bool> DeleteAsync(Guid id);
    }
}
