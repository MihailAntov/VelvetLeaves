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

            IList<string> urls = await _imageService.WriteToDisk(model.Image, model.Name);

            if(urls.Count > 0)
            {
                string url = urls[0];
                await _categoryService.AddCategoryAsync(model.Name, url);
            }

            return RedirectToAction("All","Products");

            
        }
    }
}
