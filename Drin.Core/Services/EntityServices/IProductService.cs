using Drin.Core.DTOs;
using Drin.Core.Entities;
using Drin.Core.Responses;

namespace Drin.Core.Services.EntityServices
{
    public interface IProductService : IService<Product>
    {
        //Burada özelleştirilmiş olarak dönüyoruz
        Task<ServiceResponse> GetProductsWithCategory();
    }
}
