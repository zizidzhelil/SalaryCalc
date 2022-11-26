using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configs
{
    public class EmployeeParameterConfig : IEntityTypeConfiguration<EmployeeParameter>
    {
        public void Configure(EntityTypeBuilder<EmployeeParameter> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.AnnualSalary).IsRequired();
            builder.Property(x => x.EmployeeId).IsRequired();
            builder.Property(x => x.Year).IsRequired();

            builder.HasOne(x => x.Employee)
                .WithMany(x => x.Parameters)
                .HasForeignKey(x => x.EmployeeId);


            builder.HasOne(x => x.Parameter)
              .WithMany(x => x.Parameters)
              .HasForeignKey(x => x.Year);
        }
    }
}