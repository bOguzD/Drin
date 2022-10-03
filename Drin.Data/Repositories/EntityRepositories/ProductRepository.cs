using Drin.Core.Entities;
using Drin.Core.Repositories.EntityRepositories;
using Microsoft.EntityFrameworkCore;

namespace Drin.Data.Repositories.EntityRepositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DrinDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
            //Include ile birlikte eager loading yaptık. Ürün ile birlikte category'yi de çektik
            return await _context.Product.Include(x => x.Category).ToListAsync();

            //Kategoriyi ihtiyaç olduğunda daha sonra çekebiliyorsak lazy loading olur 
        }
    }
}
