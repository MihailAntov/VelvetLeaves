using Microsoft.AspNetCore.Mvc;

namespace VelvetLeaves.App.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Featured()
        {
            return View();
        }
    }
}
