using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Subcategory;

namespace VelvetLeaves.App.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin,Moderator")]
	public class SubcategoriesController : Controller
	{
		private readonly IImageService _imageService;
		private readonly ISubcategoryService _subcategoryService;
		private readonly ICategoryService _categoryService;
		public SubcategoriesController(IImageService imageService, ISubcategoryService subcategoryService, ICategoryService categoryService)
		{
			_imageService = imageService;
			_subcategoryService = subcategoryService;
			_categoryService = categoryService;	
		}

		[HttpGet]
		public async Task<IActionResult> Add(int categoryId)
		{
			var model = new SubcategoryFormViewModel();
			model.CategoryOptions = await _categoryService.AllCategoriesAsync();
			if(categoryId > 0 && categoryId <= model.CategoryOptions.Count())
            {
				model.CategoryId = categoryId;
            }
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(SubcategoryFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}


			string? imageId = await _imageService.CreateAsync(model.Image);

			if (imageId == null)
			{
				ModelState.AddModelError("Image", "Image upload unsuccessful.");
			}

			await _subcategoryService.AddAsync(model.Name, model.CategoryId, imageId!);


			return LocalRedirect($"~/Admin/Products/All?categoryId={model.CategoryId}");
		}

        [HttpGet]
		public async Task<IActionResult> FetchSubcategories(int categoryId)
        {
			var model = await _subcategoryService.SubcategoriesByCategoryIdAsync(categoryId);

			return Json(model);
        }
	}
}
