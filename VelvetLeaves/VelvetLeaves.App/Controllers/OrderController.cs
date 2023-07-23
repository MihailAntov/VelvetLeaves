using Microsoft.AspNetCore.Mvc;

namespace VelvetLeaves.Web.App.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
