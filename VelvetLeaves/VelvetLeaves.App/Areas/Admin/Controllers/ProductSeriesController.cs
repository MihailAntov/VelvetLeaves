using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.ViewModels.ProductSeries;

namespace VelvetLeaves.App.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin,Moderator")]
	public class ProductSeriesController : Controller
	{
		private readonly ICategoryService _categoryService;
		private readonly ISubcategoryService subcategoryService;
		[HttpGet]
		public async Task<IActionResult> Add(int categoryId, int subcategoryId)
		{
			var model = new ProductSeriesFormViewModel();
			model.CategoryOptions = await _categoryService.AllCategoriesAsync();
			if (categoryId > 0 && categoryId <= model.CategoryOptions.Count())
			{
				model.CategoryId = categoryId;
			}
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(ProductSeriesFormViewModel model)
		{
			throw new NotImplementedException();
		}
	}
}
