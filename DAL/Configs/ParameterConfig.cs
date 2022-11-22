using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities;

namespace DAL.Configs
{
    public class ParameterConfig : IEntityTypeConfiguration<Parameter>
    {
        public void Configure(EntityTypeBuilder<Parameter> builder)
        {
            builder.HasKey(x => x.Year);

            builder.Property(x => x.MinThreshold).IsRequired();
            builder.Property(x => x.MaxThreshold).IsRequired();
            builder.Property(x => x.TotalIncomeTaxPercentage).IsRequired();
            builder.Property(x => x.HealthAndSocialInsurancePercentage).IsRequired();

            builder.HasMany(x => x.Parameters)
              .WithOne(x => x.Parameter);
        }
    }
}
