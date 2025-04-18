using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using InternshipProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

       
        public DbSet<Employee> Employees { get; set; }
        public DbSet<CustomAttribute> CustomAttributes { get; set; }  
        public DbSet<AttributeValue> AttributeValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // EAV ilişkileri
            modelBuilder.Entity<AttributeValue>()
                .HasOne(av => av.Employee)
                .WithMany(e => e.Attributes)
                .HasForeignKey(av => av.EmployeeId);

            modelBuilder.Entity<AttributeValue>()
                .HasOne(av => av.CustomAttribute)
                .WithMany(a => a.AttributeValues)
                .HasForeignKey(av => av.AttributeId);
        }
    }
}
