using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Service.Models;
using VelvetLeaves.Services;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Product;

namespace VelvetLeaves.App.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly IColorService colorService;
        public ProductsController(IProductService productService, IColorService colorService)
        {
            this.productService = productService;
            this.colorService = colorService;
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

        public async Task<IActionResult> ProductsFiltered(ProductsQueryModel queryModel)
		{
            ProductsFilteredAndPagedServiceModel serviceModel = await productService.ProductsFilteredAndPagedAsync(queryModel);
            queryModel.Products = serviceModel.Products;
            queryModel.TotalProducts = serviceModel.TotalProductCount;
            queryModel.ColorOptions = await colorService.GetColorOptionsAsync(queryModel.CategoryId, queryModel.SubCategoryId);
            queryModel.MaterialOptions = await productService.GetMaterialOptionsAsync
		}
    }
}
