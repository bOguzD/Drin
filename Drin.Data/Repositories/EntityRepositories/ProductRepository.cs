using Drin.Core.Entities;
using Drin.Core.Repositories.EntityRepositories;

namespace Drin.Data.Repositories.EntityRepositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private DrinDbContext context { get => context as DrinDbContext; }
        public ProductRepository(DrinDbContext context) : base(context)
        {
        }
    }
}
