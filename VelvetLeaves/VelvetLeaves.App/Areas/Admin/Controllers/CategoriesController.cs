using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VelvetLeaves.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles="Admin,Moderator")]
    public class CategoriesController : Controller
    {
        public IActionResult All()
        {
            return View();
        }
    }
}
