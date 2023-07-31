using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Order;
using VelvetLeaves.Web.Infrastructure.Services.Contracts;

namespace VelvetLeaves.Web.App.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IOrderService _orderService;
        public OrderController(IShoppingCartService shoppingCartService, IOrderService orderService)
        {
            _shoppingCartService = shoppingCartService;
            _orderService = orderService;
        }
        public  IActionResult ShoppingCart()
        {
            var cart = _shoppingCartService.GetShoppingCart();
            var model = _orderService.GetShoppingCartForCheckout(cart);
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
