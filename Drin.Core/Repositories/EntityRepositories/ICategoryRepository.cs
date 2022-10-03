using Drin.Core.Entities;

namespace Drin.Core.Repositories.EntityRepositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetSingleCategoryByIdWithProductsAsync(int categoryId);
    }
}
