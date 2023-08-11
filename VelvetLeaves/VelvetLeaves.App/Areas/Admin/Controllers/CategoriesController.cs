using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Category;
using static VelvetLeaves.Common.ApplicationConstants;
using static VelvetLeaves.Web.Infrastructure.Extensions.ControllerExtensions;

namespace VelvetLeaves.App.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminAndModeratorRoleNames)]
    public class CategoriesController : Controller
    {
        private readonly IImageService _imageService;
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoriesController> logger;
        public CategoriesController(
            IImageService imageService,
            ICategoryService categoryService,
            ILogger<CategoriesController> logger)
        {
            _imageService = imageService;
            _categoryService = categoryService;
            this.logger = logger;
        }

        [HttpGet]
        [DisplayName("Add")]
        
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

            try
            {
                string? imageId = await _imageService.CreateAsync(model.Image);

                if (imageId == null)
                {
                    ModelState.AddModelError("Image", "Image upload unsuccessful.");
                }


                await _categoryService.AddCategoryAsync(model.Name, imageId!);


                return RedirectToAction("All", "Products");
            }
            catch (Exception)
            {
                return NotFound();
            }

            

            
        }

		[HttpGet]
        public async Task<IActionResult> Edit(int categoryId)
        {
            try
            {
                var model = await _categoryService.GetForEditAsync(categoryId);
                return View(model);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }

            
		}

		[HttpPost]
        public async Task<IActionResult> Edit(CategoryEditFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
                return View(model);
			}

            try
            {
                await _categoryService.EditAsync(model);
                return RedirectToAction("All", "Products");
            }
            catch (Exception)
            {
                return NotFound();
            }
            
        }

		[HttpGet]
        [DisplayName("Delete")]
        public async Task<IActionResult> Delete(int categoryId)
		{
            try
            {
                await _categoryService.DeleteAsync(categoryId);
                return RedirectToAction("All", "Products");
            }
            catch(Exception)
            {
                return NotFound();
            }
            
        }
    }
}
