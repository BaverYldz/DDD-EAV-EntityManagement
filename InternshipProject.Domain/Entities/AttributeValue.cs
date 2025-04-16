using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipProject.Domain.Entities
{
    public class AttributeValue
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public Guid AttributeId { get; set; }
        public Attribute Attribute { get; set; }

        public string Value { get; set; }

    }
}
