using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipProject.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "First name is required!")]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required!")]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        public Guid DepartmentId { get; set; }

        [Required] 
        public DateTime StartDate { get; set; }

        //EAV sistemi icin value attribute listesi
        public List<AttributeValue> Attributes { get; set; } = new();
    }
}
