using Drin.Core;
using Drin.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Drin.Data
{
    public class DrinDbContext : DbContext
    {
        public DrinDbContext(DbContextOptions<DrinDbContext> options) : base(options) {

            //Product üzerinden işleme girmesi best-practise açısından uygun
            //var p = new Product() { ProductFeature = new ProductFeature() { } };
        }

        public DbSet<Category>  Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductFeature> ProductFeature { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //Tek tek yazmak istersek bu şekilde, üstteki gibi olduğunda hepsini alıyor
            //builder.ApplyConfiguration(new ProductConfiguration());


            //SeedData'yı eğer burada eklemek istersek diye örnek
            builder.Entity<ProductFeature>().HasData(
                new ProductFeature { Id = 1, Colour = "Black", Weight = 40, ProductId = 1 },
                new ProductFeature { Id = 2, Colour = "Blue", Weight = 10, ProductId = 2 });


            base.OnModelCreating(builder);
        }
    }
}
