using Drin.Core.Entities;
using Drin.Core.Responses;

namespace Drin.Core.Services.EntityServices
{
    public interface ICategoryService : IService<Category>
    {
        public Task<ServiceResponse> GetSingleCategoryByIdWithProductsAsync(int categoryId);
    }
}
