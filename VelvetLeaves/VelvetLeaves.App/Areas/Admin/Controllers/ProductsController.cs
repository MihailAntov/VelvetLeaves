using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Data;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Product;

namespace VelvetLeaves.Web.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator")]
    
    public class ProductsController : Controller
    {
        private readonly ICategoryService _categoryService;
        public ProductsController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        /// <summary>
        /// Returns all products, grouped by product series, then by subcategory, then by category, to be browsed in a tree-like structure.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> All()
        {
            var model = await _categoryService.GetProductTreeAsync();
            
            return View(model);
        }

        public Task<IActionResult> Add()
        {
            throw new NotImplementedException();
        }

        public  Task<IActionResult> Add(ProductFormViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
