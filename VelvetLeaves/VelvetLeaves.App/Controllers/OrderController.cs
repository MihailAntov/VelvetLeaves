using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VelvetLeaves.Web.App.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
