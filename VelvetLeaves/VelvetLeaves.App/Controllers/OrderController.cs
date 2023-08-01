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
        [HttpGet]
        public async Task<IActionResult> ShoppingCart()
        {
            var cart = _shoppingCartService.GetShoppingCart();
            var model = await _orderService.GetShoppingCartForCheckoutAsync(cart);
            
            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> AddToCart(int productId)
        {
            var newCart = _shoppingCartService.AddOneItemToShoppingCart(productId);
            var model = await _orderService.GetShoppingCartForCheckoutAsync(newCart);
            return Json(model);
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            var newCart = _shoppingCartService.RemoveOneItemFromShoppingCart(productId);
            var model = await _orderService.GetShoppingCartForCheckoutAsync(newCart);
            return Json(model);
        }

        [HttpGet]
        public async  Task<IActionResult> DeleteFromCart(int productId)
        {
            var newCart = _shoppingCartService.DeleteItemFromShoppingCart(productId);
            var model = await _orderService.GetShoppingCartForCheckoutAsync(newCart);

            return Json(model);
        }

        [HttpPost]
        public async Task<IActionResult> ShoppingCart(ShoppingCartViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!await _orderService.CartValidAsync(model))
            {
                ModelState.AddModelError("cart", "Cart contents are not valid.");
                return View(model);
            }

            return View("Checkout",model);
        }

        
        private async Task<IActionResult> Checkout()
        {
            var cart = _shoppingCartService.GetShoppingCart();
            var cartModel = await _orderService.GetShoppingCartForCheckoutAsync(cart);

            if(cartModel == null)
            {
                return BadRequest();
            }
            var  model = _orderService.GetCheckoutInfo(cartModel);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _orderService.PlaceOrderAsync(model);

            return RedirectToAction("All", "Order");
        }


    }
}
