using Microsoft.EntityFrameworkCore;
using MiniApp1.Core.Models;
using MiniApp1.Data.Configurations;

namespace MiniApp1.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new AssignmentConfiguration());


            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
