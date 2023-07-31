using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Web.Infrastructure.Models;
using VelvetLeaves.Web.Infrastructure.Services.Contracts;

namespace VelvetLeaves.Web.App.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        public OrderController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }
        public async Task<IActionResult> ShoppingCart()
        {
            ShoppingCart model = await _shoppingCartService.GetShoppingCart();
            return View(model);

        }

        [HttpGet]
        public IActionResult AddToCart(int productId)
        {
            _shoppingCartService.AddItemToShoppingCart(productId);

           return Json(new { text = "Successfully added to shopping cart." });
        }
    }
}
