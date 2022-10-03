using Drin.Core.Entities;

namespace Drin.Core.Repositories.EntityRepositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetProductsWithCategory();
    }
}
