using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Category;
using static VelvetLeaves.Common.ApplicationConstants;

namespace VelvetLeaves.App.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = $"{AdminRoleName},${ModeratorRoleName}")]
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
            var model = await _categoryService.GetForEditAsync(categoryId);
            return View(model);
		}

		[HttpPost]
        public async Task<IActionResult> Edit(CategoryEditFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
                return View(model);
			}
            
            await _categoryService.EditAsync(model);

            return RedirectToAction("All", "Products");
        }

		[HttpGet]
        public async Task<IActionResult> Delete(int categoryId)
		{
            await _categoryService.DeleteAsync(categoryId);
            return RedirectToAction("All", "Products");
        }
    }
}
