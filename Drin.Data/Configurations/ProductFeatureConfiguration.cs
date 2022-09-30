using Drin.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Drin.Data.Configurations
{
    internal class ProductFeatureConfiguration : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Weight).HasColumnType("decimal(18,2)").IsRequired();

            builder.HasOne(x => x.Product).WithOne(x => x.ProductFeature).HasForeignKey<ProductFeature>(x => x.ProductId);
        }
    }
}
