using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VelvetLeaves.Web.App.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        public Task<IActionResult> ShoppingCart()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public  IActionResult AddToCart(int productId)
        {
            TempData["Message"] = "Successfully added to shopping cart.";
            return RedirectToAction("All", "Products", productId);
        }
    }
}
