using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configs
{
    public class ParameterConfig : IEntityTypeConfiguration<Parameter>
    {
        public void Configure(EntityTypeBuilder<Parameter> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Year).IsRequired();
            builder.Property(x => x.MinThreshold).IsRequired();
            builder.Property(x => x.MaxThreshold).IsRequired();
            builder.Property(x => x.TotalIncomeTaxPercentage).IsRequired();
            builder.Property(x => x.HealthAndSocialInsurancePercentage).IsRequired();

            builder.HasMany(x => x.Parameters)
              .WithOne(x => x.Parameter);
        }
    }
}
