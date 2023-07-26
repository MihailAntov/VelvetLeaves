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

        public ProductSeriesController
			(ICategoryService categoryService,
			ISubcategoryService subcategoryService,
			IColorService colorService,
			IMaterialService materialService,
			ITagService tagService)
        {
            _categoryService = categoryService;
            _subcategoryService = subcategoryService;
			_colorService = colorService;
			_materialService = materialService;
			_tagService = tagService;
        }

		

		[HttpGet]
		public async Task<IActionResult> Add(int categoryId, int subcategoryId)
		{
			var model = new ProductSeriesFormViewModel();

			model.CategoryOptions = await _categoryService.AllCategoriesAsync();
			if(categoryId > 0 && categoryId <= model.CategoryOptions.Count())
            {
				model.SubcategoryOptions = await _subcategoryService.SubcategoriesByCategoryIdAsync(categoryId);
            }
            else
            {
				model.SubcategoryOptions = await _subcategoryService.AllSubcategoriesAsync();

            }
			if (categoryId > 0 && categoryId <= model.CategoryOptions.Count())
			{
				model.CategoryId = categoryId;
            }
            

			if(subcategoryId > 0 && subcategoryId <= model.SubcategoryOptions.Count())
            {
				model.SubcategoryId = subcategoryId;
            }

			model.ColorOptions = await _colorService.GetColorOptionsAsync(categoryId, subcategoryId);
			model.MaterialOptions = await _materialService.GetMaterialOptionsAsync(categoryId, subcategoryId);
			model.TagOptions = await _tagService.GetTagOptionsAsync(categoryId, subcategoryId);


			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(ProductSeriesFormViewModel model)
		{
			throw new NotImplementedException();
		}
	}
}
