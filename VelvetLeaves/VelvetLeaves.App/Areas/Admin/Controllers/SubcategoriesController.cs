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
		public SubcategoriesController(IImageService imageService)
		{
			_imageService = imageService;
		}

		[HttpGet]
		public async Task<IActionResult> Add(int categoryId)
		{
			return View();
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

			await _categoryService.AddCategoryAsync(model.Name, imageId!);


			return RedirectToAction("All", "Products");
		}
	}
}
