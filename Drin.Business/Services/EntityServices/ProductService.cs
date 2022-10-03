using AutoMapper;
using Drin.Core.DTOs;
using Drin.Core.Entities;
using Drin.Core.Repositories;
using Drin.Core.Repositories.EntityRepositories;
using Drin.Core.Responses;
using Drin.Core.Services.EntityServices;
using Drin.Core.UnitOfWorks;

namespace Drin.Business.Services.EntityServices
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IRepository<Product> repository, IUnitOfWork unitOfWork, 
            IProductRepository productRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> GetProductsWithCategory()
        {
            var products = await _productRepository.GetProductsWithCategory();

            //Mapper kullanarak bu şekilde de dönebiliriz ama ben ServiceResponse'a data ekledim bakalım gelecek mi?
            //var productDTO = _mapper.Map<List<ProductWithCategoryDTO>>(products);

            return ServiceResponse.Success(200, "Ürün ve Kategori başarı ile getirildi.", products);

        }
    }
}
