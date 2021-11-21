using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniApp1.Core.Models;

namespace MiniApp1.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.SurName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Salary).HasColumnType("decimal(18,2)");
            builder.Property(x => x.Position).HasMaxLength(50);
            
        }
    }
}
