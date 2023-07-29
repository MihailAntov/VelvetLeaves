using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Category;

namespace VelvetLeaves.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    public class CategoriesController : Controller
    {
        private readonly IImageService _imageService;
        private readonly ICategoryService _categoryService;
        public CategoriesController(IImageService imageService, ICategoryService categoryService)
        {
            _imageService = imageService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            string? imageId = await _imageService.CreateAsync(model.Image);

            if(imageId == null)
			{
                ModelState.AddModelError("Image", "Image upload unsuccessful.");
			}

            await _categoryService.AddCategoryAsync(model.Name, imageId!) ;
            

            return RedirectToAction("All","Products");

            
        }

		[HttpGet]
        public async Task<IActionResult> Edit(int categoryId)
		{
            return View();
		}

		[HttpPost]
        public async Task<IActionResult> Edit(int categoryId, CategoryFormViewModel model)
		{
            return View();
		}
    }
}
