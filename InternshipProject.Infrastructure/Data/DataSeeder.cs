using InternshipProject.Domain.Entities;
using InternshipProject.Infrastructure.Data;

public static class DataSeeder
{
    public static void Seed(AppDbContext context)
    {
        context.Database.EnsureCreated();

        if (context.CustomAttributes.Any()) return;

        var attributes = new List<CustomAttribute>
        {
            new CustomAttribute { Name = "Cinsiyet", DataType = "string" },
            new CustomAttribute { Name = "Doğum Tarihi", DataType = "datetime" },
            new CustomAttribute { Name = "Unvan", DataType = "string" }
        };

        context.CustomAttributes.AddRange(attributes);
        context.SaveChanges();

        var employee = new Employee
        {
            FirstName = "Ayşe",
            LastName = "Yılmaz",
            DepartmentId = Guid.NewGuid(),
            StartDate = DateTime.Now
        };

        context.Employees.Add(employee);
        context.SaveChanges();

        var values = new List<AttributeValue>
        {
            new AttributeValue
            {
                EmployeeId = employee.Id,
                AttributeId = attributes.First(a => a.Name == "Cinsiyet").Id,
                Value = "Kadın"
            },
            new AttributeValue
            {
                EmployeeId = employee.Id,
                AttributeId = attributes.First(a => a.Name == "Doğum Tarihi").Id,
                Value = new DateTime(1995, 5, 20).ToString("yyyy-MM-dd")
            }
        };

        context.AttributeValues.AddRange(values);
        context.SaveChanges();
    }
}
