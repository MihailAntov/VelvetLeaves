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
        public ProductsController(IProductService productService, IColorService colorService, IMaterialService materialService, ITagService tagService)
        {
            _productService = productService;
            _colorService = colorService;
            _materialService = materialService;
            _tagService = tagService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> ProductsFiltered(ProductsQueryModel queryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            ProductsFilteredAndPagedServiceModel serviceModel = await _productService.ProductsFilteredAndPagedAsync(queryModel);

            queryModel.Products = serviceModel.Products;
            queryModel.TotalProducts = serviceModel.TotalProductCount;
            queryModel.ColorOptions = await _colorService.GetColorOptionsAsync(queryModel.CategoryId, queryModel.SubCategoryId);
            queryModel.MaterialOptions = await _materialService.GetMaterialOptionsAsync(queryModel.CategoryId, queryModel.SubCategoryId);
            queryModel.TagOptions = await _tagService.GetTagOptionsAsync(queryModel.CategoryId, queryModel.SubCategoryId);

            return View("Products", queryModel);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (!await _productService.ExistsByIdAsync(id))
            {
                return BadRequest();
            }
            var model = await _productService.DetailsByIdAsync(id);

            return View(model);
        }

        [HttpGet]
        public async Task AddToFavorites(int productId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task RemoveFromFavorites(int productId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> ViewFavorites()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = await _productService.GetFavoritesByUserIdAsync(userId);
            return View(model);
        }
    }
}
