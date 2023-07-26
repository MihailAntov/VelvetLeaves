using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.ProductSeries;

namespace VelvetLeaves.App.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    public class ProductSeriesController : Controller
	{
		private readonly ICategoryService _categoryService;
		private readonly ISubcategoryService _subcategoryService;
		private readonly IColorService _colorService;
		private readonly IMaterialService _materialService;
		private readonly ITagService _tagService;
		private readonly IProductSeriesService _productSeriesService;

        public ProductSeriesController
			(ICategoryService categoryService,
            ISubcategoryService subcategoryService,
            IColorService colorService,
            IMaterialService materialService,
            ITagService tagService,
            IProductSeriesService productSeriesService)
        {
            _categoryService = categoryService;
            _subcategoryService = subcategoryService;
            _colorService = colorService;
            _materialService = materialService;
            _tagService = tagService;
            _productSeriesService = productSeriesService;
        }



        [HttpGet]
		public async Task<IActionResult> Add(int categoryId, int subcategoryId)
		{
			
			var model = new ProductSeriesFormViewModel();
			var categories = await _categoryService.AllCategoriesAsync();
			model.CategoryId = (categoryId <= 0 || categoryId > categories.Count()) ? await _categoryService.GetDefaultCategoryIdAsync() : categoryId;
			model.CategoryOptions = categories;
			var subCategories = await _subcategoryService.SubcategoriesByCategoryIdAsync(model.CategoryId);
			model.SubcategoryId = (subcategoryId <= 0 || subcategoryId > subCategories.Count()) ? await _subcategoryService.GetDefaultSubcategoryIdAsync(model.CategoryId) : subcategoryId;
			model.SubcategoryOptions = subCategories;



			model.ColorOptions = await _colorService.GetAllColorsAsync();
			model.MaterialOptions = await _materialService.GetAllMaterialsAsync();
			model.TagOptions = await _tagService.GetAllTagsAsync();


			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(ProductSeriesFormViewModel model)
		{
			await _productSeriesService.AddAsync(model);

			return LocalRedirect($"~/Admin/Products/All?categoryId={model.CategoryId}&subcategoryId={model.SubcategoryId}");
		}

        [HttpGet]
		public async Task<IActionResult> FetchProductSeries(int subcategoryId)
        {
			var model = await _productSeriesService.ProductSeriesBySubcategoryIdAsync(subcategoryId);
			return Json(model);
        }
	}
}
