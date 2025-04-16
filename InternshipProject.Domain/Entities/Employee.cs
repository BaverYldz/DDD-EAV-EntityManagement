using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipProject.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid DepartmentId { get; set; }
        public DateTime StartDate { get; set; }

        //EAV sistemi icin value attribute listesi
        public List<AttributeValue> Attributes { get; set; } = new();
    }
}
