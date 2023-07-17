using Microsoft.AspNetCore.Mvc;

namespace VelvetLeaves.App.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
