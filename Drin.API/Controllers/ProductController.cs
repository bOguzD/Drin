using AutoMapper;
using Drin.Core.DTOs;
using Drin.Core.Entities;
using Drin.Core.Responses;
using Drin.Core.Services.EntityServices;
using Microsoft.AspNetCore.Mvc;

namespace Drin.API.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IMapper mapper;
        private readonly IProductService _service;

        public ProductController(IMapper mapper, IProductService service)
        {
            this.mapper = mapper;
            this._service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _service.GetAllAsync();
            var productDtos = mapper.Map<List<ProductDTO>>(products);

            return CreateActionResult(ServiceResponse.Success(200, "Ürünler başarı ile getirildi.", productDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productDto = mapper.Map<ProductDTO>(product);
            return CreateActionResult(ServiceResponse.Success(200, "Ürün getirildi.", productDto));
        }
        // GET api/product/GetProductsWithCategory
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _service.GetProductsWithCategory());
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductDTO productDto)
        {
            var product = mapper.Map<Product>(productDto);
            await _service.AddAsync(product);
            return CreateActionResult(ServiceResponse.Success(201, "Ürün eklendi", productDto));
        }

        [HttpPut]
        public async Task<IActionResult> Put(ProductDTO productDto)
        {
            await _service.UpdateAsync(mapper.Map<Product>(productDto));
            return CreateActionResult(ServiceResponse.Success(204, "Ürün başarı ile eklendi."));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _service.GetByIdAsync(id);

            //Şimdilik burada kalsın
            if (product == null) return CreateActionResult(ServiceResponse.Failure(404, "Silinmek istenen ürün bulunamadı"));

            await _service.DeleteAsync(product);

            return CreateActionResult(ServiceResponse.Success(204, "Ürün başarı ile silindi."));
        }
    }
}
