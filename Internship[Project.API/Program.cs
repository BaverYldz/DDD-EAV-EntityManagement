using InternshipProject.Application.Interfaces;
using InternshipProject.Application.Services;
using InternshipProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;
using Swashbuckle.AspNetCore.SwaggerGen; // Add this using directive for AddSwaggerGen extension method  

var builder = WebApplication.CreateBuilder(args);



// Inject DbContext using the connection string from configuration  
builder.Services.AddDbContext<AppDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Swagger services  
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Internship Project API",
        Version = "v1",
        Description = "API documentation for the Internship Project"
    });
});

// Services  
builder.Services.AddScoped<ICustomAttributeService, CustomAttributeService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAttributeValueService, AttributeValueService>();

builder.Services.AddControllers()
   .AddJsonOptions(options =>
   {
       options.JsonSerializerOptions.ReferenceHandler = null;
       options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull; 
   });

var app = builder.Build();

// Configure the HTTP request pipeline.  
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();

    // Enable Swagger middleware  
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Internship Project API v1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the root  
    });
}

app.UseHttpsRedirection();  
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    DataSeeder.Seed(context);
}

app.Run();
