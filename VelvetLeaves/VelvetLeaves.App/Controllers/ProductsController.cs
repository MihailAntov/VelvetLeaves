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
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductsFiltered(ProductsQueryModel queryModel)
		{
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            ProductsFilteredAndPagedServiceModel serviceModel = await productService.ProductsFilteredAndPagedAsync(queryModel);
            
            queryModel.Products = serviceModel.Products;
            queryModel.TotalProducts = serviceModel.TotalProductCount;
            queryModel.ColorOptions = await productService.GetColorOptionsAsync(queryModel.CategoryId, queryModel.SubCategoryId);
            queryModel.MaterialOptions = await productService.GetMaterialOptionsAsync(queryModel.CategoryId, queryModel.SubCategoryId);
            queryModel.TagOptions = await productService.GetTagOptionsAsync(queryModel.CategoryId, queryModel.SubCategoryId);

            return View("Products",queryModel);
		}

		[HttpGet]
        public async Task<IActionResult> Details(int id)
		{
            return View();
		}
    }
}
