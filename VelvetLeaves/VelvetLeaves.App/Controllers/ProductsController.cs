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
        private readonly IMaterialService materialService;
        private readonly ITagService tagService;
        public ProductsController(IProductService productService, IColorService colorService, IMaterialService materialService, ITagService tagService)
        {
            this.productService = productService;
            this.colorService = colorService;
            this.materialService = materialService;
            this.tagService = tagService;
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
            queryModel.ColorOptions = await colorService.GetColorOptionsAsync(queryModel.CategoryId, queryModel.SubCategoryId);
            queryModel.MaterialOptions = await materialService.GetMaterialOptionsAsync(queryModel.CategoryId, queryModel.SubCategoryId);
            queryModel.TagOptions = await tagService.GetTagOptionsAsync(queryModel.CategoryId, queryModel.SubCategoryId);

            return View("Products",queryModel);
		}

		[HttpGet]
        public async Task<IActionResult> Details(int id)
		{
            if (!await productService.ExistsByIdAsync(id))
            {
                return BadRequest();
            }
            var model = await productService.DetailsByIdAsync(id);

            return View(model);
		}
    }
}
