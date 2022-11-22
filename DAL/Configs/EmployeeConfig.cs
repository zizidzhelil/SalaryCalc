using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configs
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName).HasMaxLength(200).IsRequired();
            builder.Property(x => x.MiddleName).HasMaxLength(200).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(200).IsRequired();  
            builder.Property(x => x.BirthDate).IsRequired();

            builder.HasMany(x => x.Parameters)
                .WithOne(x => x.Employee);
        }
    }
}
