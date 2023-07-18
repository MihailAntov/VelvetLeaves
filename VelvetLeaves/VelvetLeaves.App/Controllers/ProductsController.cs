using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Services;
using VelvetLeaves.Services.Contracts;

namespace VelvetLeaves.App.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<IActionResult> Products(int categoryId)
        {
            var model = await productService.AllProducts(categoryId);
            return View();
        }
    }
}
