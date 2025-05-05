using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using InternshipProject.Domain.Entities;

namespace InternshipProject.Tests
{
    public class EmployeeTests
    {
        [Fact]
        public void Employee_Should_Have_Default_Id()
        {
            // Arrange & Act
            var employee = new Employee();

            // Assert
            Assert.NotEqual(Guid.Empty, employee.Id);
        }

        [Fact]
        public void Employee_Should_Require_FirstName()
        {
            // Arrange
            var employee = new Employee { FirstName = null };

            // Act
            var validationResults = ValidateModel(employee);

            // Assert
            Assert.Contains(validationResults, v => v.ErrorMessage == "First name is required!");
        }

        [Fact]
        public void Employee_Should_Enforce_MaxLength_On_FirstName()
        {
            // Arrange
            var employee = new Employee { FirstName = new string('A', 21) };

            // Act
            var validationResults = ValidateModel(employee);

            // Assert
            Assert.Contains(validationResults, v => v.ErrorMessage.Contains("The field FirstName must be a string or array type with a maximum length of '20'."));
        }

        [Fact]
        public void Employee_Should_Require_LastName()
        {
            // Arrange
            var employee = new Employee { LastName = null };

            // Act
            var validationResults = ValidateModel(employee);

            // Assert
            Assert.Contains(validationResults, v => v.ErrorMessage == "Last name is required!");
        }

        [Fact]
        public void Employee_Should_Enforce_MaxLength_On_LastName()
        {
            // Arrange
            var employee = new Employee { LastName = new string('A', 21) };

            // Act
            var validationResults = ValidateModel(employee);

            // Assert
            Assert.Contains(validationResults, v => v.ErrorMessage.Contains("The field LastName must be a string or array type with a maximum length of '20'."));
        }

        [Fact]
        public void Employee_Should_Require_DepartmentId()
        {
            // Arrange
            var employee = new Employee { DepartmentId = Guid.Empty };

            // Act
            var validationResults = ValidateModel(employee);

            // Assert
            Assert.Contains(validationResults, v => v.ErrorMessage == "The DepartmentId field is required.");
        }

        [Fact]
        public void Employee_Should_Require_StartDate()
        {
            // Arrange
            var employee = new Employee { StartDate = default };

            // Act
            var validationResults = ValidateModel(employee);

            // Assert
            Assert.Contains(validationResults, v => v.ErrorMessage == "The StartDate field is required.");
        }

        [Fact]
        public void Employee_Should_Have_Empty_Attributes_By_Default()
        {
            // Arrange & Act
            var employee = new Employee();

            // Assert
            Assert.NotNull(employee.Attributes);
            Assert.Empty(employee.Attributes);
        }

        private List<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            return validationResults;
        }
    }
}
