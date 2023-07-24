using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VelvetLeaves.App.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Moderator")]
        public IActionResult Admin()
        {
            return Redirect("/Admin/Products/All");
        }


    }
}
