using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipProject.Domain.Entities
{
    public class CustomAttribute
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Attribute name is required.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Data type is required.")]
        public string DataType { get; set; }

        public List<AttributeValue> AttributeValues { get; set; } = new();

    }
}
