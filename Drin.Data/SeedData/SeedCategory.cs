using Drin.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Drin.Data.SeedData
{
    public class SeedCategory : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new { Id = 1, Name = "Kalemler", CreatedDate = DateTime.Now }, 
                new { Id = 2, Name = "Kitaplar", CreatedDate = DateTime.Now }, 
                new { Id = 3, Name = "Defterler", CreatedDate = DateTime.Now });
        }
    }
}
