using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.ViewModels.Category;

namespace VelvetLeaves.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    public class CategoriesController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CategoryFormViewModel model)
        {
            if (!ModelState.IsValid)
            {

            }
            throw new NotImplementedException();
        }
    }
}
