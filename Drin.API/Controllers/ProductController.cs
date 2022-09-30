using AutoMapper;
using Drin.Core.DTOs;
using Drin.Core.Entities;
using Drin.Core.Responses;
using Drin.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Drin.API.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IMapper mapper;
        private readonly IService<Product> service;

        public ProductController(IMapper mapper, IService<Product> service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await service.GetAllAsync();
            var productDtos = mapper.Map<List<ProductDTO>>(products);

            return CreateActionResult(ServiceResponse.Success(200, "Ürünler başarı ile getirildi.", productDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var product = await service.GetByIdAsync(Id);
            var productDto = mapper.Map<ProductDTO>(product);
            return CreateActionResult(ServiceResponse.Success(200, "Ürün getirildi.", productDto));
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductDTO productDto)
        {
            var product = mapper.Map<Product>(productDto);
            await service.AddAsync(product);
            return CreateActionResult(ServiceResponse.Success(201, "Ürün eklendi", productDto));
        }

        [HttpPut]
        public async Task<IActionResult> Put(ProductDTO productDto)
        {
            await service.UpdateAsync(mapper.Map<Product>(productDto));
            return CreateActionResult(ServiceResponse.Success(204, "Ürün başarı ile eklendi."));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var product = await service.GetByIdAsync(Id);

            //Şimdilik burada kalsın
            if (product == null) return CreateActionResult(ServiceResponse.Failure(404, "Silinmek istenen ürün bulunamadı"));

            await service.DeleteAsync(product);

            return CreateActionResult(ServiceResponse.Success(204, "Ürün başarı ile silindi."));
        }
    }
}
