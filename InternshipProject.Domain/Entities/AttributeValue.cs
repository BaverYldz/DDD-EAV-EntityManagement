﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public CustomAttribute CustomAttribute { get; set; }

        [Required(ErrorMessage = "Value is required.")]
        public string Value { get; set; }

    }
}
