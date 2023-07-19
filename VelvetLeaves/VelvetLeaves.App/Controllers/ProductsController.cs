using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Services;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Product;

namespace VelvetLeaves.App.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<IActionResult> ProductsByCategory(int categoryId)
        {
            var model = await productService.AllProductsByCategoryAsync(categoryId);
            return View("Products",model);
        }

        public async Task<IActionResult> ProductsBySubcategory(int subcategoryId)
        {
            var model = await productService.AllProductsBySubCategoryAsync(subcategoryId);
            return View("Products", model);
        }

        public async Task<IActionResult> ProductsFiltered(ProductsQueryModel model)
		{

		}
    }
}
