using Drin.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Drin.Data.SeedData
{
    internal class SeedProduct : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new { Id = 1, CategoryId = 1, Name = "Uçlu Kalem", Price = (decimal)100, Stock = 20, CreatedDate = DateTime.Now },
                new { Id = 2, CategoryId = 1, Name = "Tükenmez Kalem", Price = (decimal)10, Stock = 200, CreatedDate = DateTime.Now },
                new { Id = 3, CategoryId = 2, Name = "Roamn", Price = (decimal)50, Stock = 100, CreatedDate = DateTime.Now },
                new { Id = 4, CategoryId = 3, Name = "Çizgili Defter", Price = (decimal)80, Stock = 40, CreatedDate = DateTime.Now }); 
        }
    }
}
