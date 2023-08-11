using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using VelvetLeaves.App.Hubs;
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
        private readonly IHubContext<OrderTrackerHub> _hubContext;
        public OrdersController(
            IShoppingCartService shoppingCartService,
            IOrderService orderService,
            IHubContext<OrderTrackerHub> hubContext)
        {
            _shoppingCartService = shoppingCartService;
            _orderService = orderService;
            _hubContext = hubContext;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ShoppingCart()
        {
            try
            {
                var cart = await _shoppingCartService.GetShoppingCart();
                var model = await _orderService.GetShoppingCartForCheckoutAsync(cart);

                return View(model);
            }
            catch (Exception)
            {
                return NotFound();
            }

            

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AddToCart(int productId)
        {
            try
            {

            var newCart = await _shoppingCartService.AddOneItemToShoppingCart(productId);
            var model = await _orderService.GetShoppingCartForCheckoutAsync(newCart);
            return Json(model);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            try
            {

            var newCart = _shoppingCartService.RemoveOneItemFromShoppingCart(productId);
            var model = await _orderService.GetShoppingCartForCheckoutAsync(newCart);
            return Json(model);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async  Task<IActionResult> DeleteFromCart(int productId)
        {
            try
            {

            var newCart = _shoppingCartService.DeleteItemFromShoppingCart(productId);
            var model = await _orderService.GetShoppingCartForCheckoutAsync(newCart);

            return PartialView("ShoppingCart",model);
            }
            catch(Exception){
                return NotFound();
            }
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


            if (User?.Identity?.IsAuthenticated ?? false)
            {
                model.Email = User.FindFirstValue(ClaimTypes.Email);
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                await _orderService.PlaceOrderAsync(model, userId);
                await _hubContext.Clients.All.SendAsync("NewOrderPlaced");

                _shoppingCartService.EmptyShoppingCart();

                if (User?.Identity?.IsAuthenticated ?? false)
                {

                    return RedirectToAction("All", "Orders");
                }

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return NotFound();
            }
            


            


        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var model = await _orderService.AllByIdAsync(userId);
                return View(model);
            }
            catch (Exception)
            {
                return NotFound();
            }
            
        }


    }
}
