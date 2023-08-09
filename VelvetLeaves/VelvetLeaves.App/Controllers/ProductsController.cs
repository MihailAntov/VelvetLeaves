using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VelvetLeaves.Service.Models;
using VelvetLeaves.Services;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Product;

namespace VelvetLeaves.Web.App.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IColorService _colorService;
        private readonly IMaterialService _materialService;
        private readonly ITagService _tagService;
        private readonly IFavoriteService _favoriteService;
        public ProductsController(
            IProductService productService,
            IColorService colorService,
            IMaterialService materialService,
            ITagService tagService,
            IFavoriteService favoriteService)
        {
            _productService = productService;
            _colorService = colorService;
            _materialService = materialService;
            _tagService = tagService;
            _favoriteService = favoriteService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> ProductsFiltered(ProductsQueryModel queryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //ProductsFilteredAndPagedServiceModel serviceModel = await _productService.ProductsFilteredAndPagedAsync(queryModel);

            //queryModel.Products = serviceModel.Products;
            //queryModel.TotalProducts = serviceModel.TotalProductCount;
            //queryModel.ColorOptions = await _colorService.GetColorOptionsAsync(queryModel.CategoryId, queryModel.SubCategoryId);
            //queryModel.MaterialOptions = await _materialService.GetMaterialOptionsAsync(queryModel.CategoryId, queryModel.SubCategoryId);
            //queryModel.TagOptions = await _tagService.GetTagOptionsAsync(queryModel.CategoryId, queryModel.SubCategoryId);
            try
            {
                queryModel = await _productService.ProductsFilteredAndPagedAsync(queryModel);
                return View("Products", queryModel);
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var model = await _productService.DetailsByIdAsync(id);
                return View(model);
            }
            catch (Exception)
            {
                return NotFound();
            }
        } 
    }
}
