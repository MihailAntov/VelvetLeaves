using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Data;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Product;
using VelvetLeaves.ViewModels.ProductSeries;

namespace VelvetLeaves.Web.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator")]
    
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISubcategoryService _subcategoryService;
        private readonly IProductSeriesService _productSeriesService;
        private readonly IColorService _colorService;
        private readonly IMaterialService _materialService;
        private readonly ITagService _tagService;
        private readonly IImageService _imageService;
        public ProductsController(
            IProductService productService,
            ICategoryService categoryService,
            ISubcategoryService subcategoryService,
            IProductSeriesService productSeriesService,
            IColorService colorService,
            IMaterialService materialService,
            ITagService tagService,
            IImageService imageService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _subcategoryService = subcategoryService;
            _productSeriesService = productSeriesService;
            _colorService = colorService;
            _materialService = materialService;
            _tagService = tagService;
            _imageService = imageService;   
        }
        /// <summary>
        /// Returns all products, grouped by product series, then by subcategory, then by category, to be browsed in a tree-like structure.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> All(int? categoryId, int? subcategoryId, int? productSeriesId)
        {
            var model = await _productService.GetProductTreeAsync(categoryId, subcategoryId, productSeriesId);
            
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add(int categoryId, int subcategoryId, int productSeriesId)
        {
            var model = new ProductFormViewModel();
            var categories = await _categoryService.AllCategoriesAsync();
            model.CategoryId = categories.Select(c=> c.Id).Contains(categoryId) ? categoryId : await _categoryService.GetDefaultCategoryIdAsync() ;
            model.CategoryOptions = categories;
            var subCategories = await _subcategoryService.SubcategoriesByCategoryIdAsync(model.CategoryId);
            model.SubcategoryId = subCategories.Select(c=>c.Id).Contains(subcategoryId) ? subcategoryId : await _subcategoryService.GetDefaultSubcategoryIdAsync(model.CategoryId);
            model.SubcategoryOptions = subCategories;
            var productSeries = await _productSeriesService.ProductSeriesBySubcategoryIdAsync(model.SubcategoryId);
            model.ProductSeriesId = productSeries.Select(ps => ps.Id).Contains(productSeriesId) ? productSeriesId : await _productSeriesService.GetDefaultProductSeriesIdAsync(model.SubcategoryId);
            model.ProductSeriesOptions = productSeries;

            model.ColorOptions = await _colorService.GetAllColorsAsync();
            model.MaterialOptions = await _materialService.GetAllMaterialsAsync();
            model.TagOptions = await _tagService.GetAllTagsAsync();



            ProductSeriesDefaultValues defaultValues = await _productSeriesService.GetDefaultValues(model.ProductSeriesId);
            model.DefaultTagIds = defaultValues.TagIds;
            model.DefaultColorIds = defaultValues.ColorIds;
            model.DefaultMaterialIds = defaultValues.MaterialIds;
            model.Name = defaultValues.Name??String.Empty;
            model.Price = defaultValues.Price ?? 0.00M;
            model.Description = defaultValues.Description ?? String.Empty;

            return View(model);

        }

        [HttpPost]
        public  async Task<IActionResult> Add(ProductFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            string? imageId = await _imageService.CreateAsync(model.Image);
            if(imageId == null)
            {
                ModelState.AddModelError("image", "Image upload unsuccessful.");
                return View(model);
            }
            model.ImageId = imageId!;
            await _productService.AddAsync(model);

            return LocalRedirect($"~/Admin/Products/All?categoryId={model.CategoryId}&subcategoryId={model.SubcategoryId}&productSeriesId={model.ProductSeriesId}");
        }

        [HttpGet]
        public async Task<IActionResult> FetchDefaultValues(int productSeriesId)
        {
            var model = await _productSeriesService.GetDefaultValues(productSeriesId);
            return Json(model);
        }
    }
}
