using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Services.Contracts;

namespace VelvetLeaves.App.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICategoryService _categoryService;
        public AdminController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AppPreferences()
        {
            return View();
        }

        public async Task<IActionResult> Categories()
        {
            var model = await _categoryService.AllCategoriesAsync();
            return View(model);
        }

        public IActionResult Subcategories()
        {
            return View();
        }

        public IActionResult Products()
        {
            return View();
        }

        public IActionResult Colors()
        {
            return View();
        }
    }
}
