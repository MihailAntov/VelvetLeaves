using Microsoft.AspNetCore.Mvc;

namespace VelvetLeaves.App.Controllers
{
    public class GalleriesController : Controller
    {
        public IActionResult Featured()
        {
            return View();
        }
    }
}
