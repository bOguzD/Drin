using Drin.Core.Services.EntityServices;
using Microsoft.AspNetCore.Mvc;

namespace Drin.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProductsWithCategory();
            return View(products.Data);
        }
    }
}
