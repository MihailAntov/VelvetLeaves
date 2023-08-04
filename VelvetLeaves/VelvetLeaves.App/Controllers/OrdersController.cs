using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Checkout;
using VelvetLeaves.ViewModels.Order;
using VelvetLeaves.Web.Infrastructure.Services.Contracts;

namespace VelvetLeaves.Web.App.Controllers
{
	[Authorize]
    public class OrdersController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IOrderService _orderService;
        public OrdersController(IShoppingCartService shoppingCartService, IOrderService orderService)
        {
            _shoppingCartService = shoppingCartService;
            _orderService = orderService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ShoppingCart()
        {
            var cart = _shoppingCartService.GetShoppingCart();
            var model = await _orderService.GetShoppingCartForCheckoutAsync(cart);
            
            return View(model);

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AddToCart(int productId)
        {
            var newCart = _shoppingCartService.AddOneItemToShoppingCart(productId);
            var model = await _orderService.GetShoppingCartForCheckoutAsync(newCart);
            return Json(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            var newCart = _shoppingCartService.RemoveOneItemFromShoppingCart(productId);
            var model = await _orderService.GetShoppingCartForCheckoutAsync(newCart);
            return Json(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async  Task<IActionResult> DeleteFromCart(int productId)
        {
            var newCart = _shoppingCartService.DeleteItemFromShoppingCart(productId);
            var model = await _orderService.GetShoppingCartForCheckoutAsync(newCart);

            return PartialView("ShoppingCart",model);
        }

        [HttpPost]
        [AllowAnonymous]
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

            var checkOutModel = _orderService.GetCheckoutInfo(model);
            
            return View("Checkout", checkOutModel);
        }

        

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Checkout(CheckoutFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _orderService.PlaceOrderAsync(model,userId);


            _shoppingCartService.EmptyShoppingCart();

			if (User?.Identity?.IsAuthenticated ?? false)
			{

                return RedirectToAction("All", "Orders");
			}

            return RedirectToAction("Index", "Home");


        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = await _orderService.AllByIdAsync(userId);
            return View(model);
        }


    }
}
