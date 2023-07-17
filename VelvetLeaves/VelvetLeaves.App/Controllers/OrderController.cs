using Microsoft.AspNetCore.Mvc;

namespace VelvetLeaves.App.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
