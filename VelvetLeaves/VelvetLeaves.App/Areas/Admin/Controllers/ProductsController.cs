using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Data;
using VelvetLeaves.Services.Contracts;

namespace VelvetLeaves.Web.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly ICategoryService _categoryService;
        public ProductsController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> All()
        {
            var model = await _categoryService.GetProductTreeAsync();
            
            return View(model);
        }

        public IActionResult Categories()
        {
            throw new NotImplementedException();
        }
    }
}
