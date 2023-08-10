

using Microsoft.AspNetCore.Http;
using VelvetLeaves.Service.Models.ShoppingCart;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Order;
using VelvetLeaves.Web.Infrastructure.Extensions;
using VelvetLeaves.Web.Infrastructure.Services.Contracts;

namespace VelvetLeaves.Web.Infrastructure.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProductService _productService;
        public ShoppingCartService(IHttpContextAccessor httpContextAccessor, IProductService productService)
        {
            _httpContextAccessor = httpContextAccessor;
            _productService = productService;
        }

        public async Task<ShoppingCart> AddOneItemToShoppingCart(int productId)
        {
            
            
            ShoppingCart? cart = _httpContextAccessor.HttpContext.Session.Get<ShoppingCart>("cart");
            if(cart == null)
            {
                cart = new ShoppingCart();
            }

            if (!await _productService.ExistsByIdAsync(productId))
            {
                throw new InvalidOperationException();
            }

            var product = cart.Items.FirstOrDefault(i => i.Id == productId);
            if(product == null)
            {
                product = new ShoppingCartItem()
                {
                    Id  = productId,
                    Quantity = 0
                };
                cart.Items.Add(product);
                
            }

            product.Quantity++;

            _httpContextAccessor.HttpContext.Session.Set("cart", cart);

            return cart;
            
        }

        public async Task<ShoppingCart> GetShoppingCart()
        {
            ShoppingCart? cart = _httpContextAccessor.HttpContext.Session.Get<ShoppingCart>("cart");
            

            var newCart = new ShoppingCart();

            if(cart != null)
            {
                foreach(var item in cart.Items)
                {
                    if(await _productService.ExistsByIdAsync(item.Id))
                    {
                        newCart.Items.Add(item);
                        
                    }
                }
            }
            
           
            return newCart;
        }

        public ShoppingCart RemoveOneItemFromShoppingCart(int productId)
        {
            ShoppingCart? cart = _httpContextAccessor.HttpContext.Session.Get<ShoppingCart>("cart");
            if (cart == null)
            {
                throw new InvalidOperationException();
            }

            var product = cart.Items.FirstOrDefault(i => i.Id == productId);
            if (product == null)
            {
                throw new InvalidOperationException();
                
            }
            if(product.Quantity > 1)
            {
                product.Quantity--;
                

            }


            _httpContextAccessor.HttpContext.Session.Set("cart", cart);

            return cart;
        }

        public ShoppingCart DeleteItemFromShoppingCart(int productId)
        {
            ShoppingCart? cart = _httpContextAccessor.HttpContext.Session.Get<ShoppingCart>("cart");
            if (cart == null)
            {
                throw new InvalidOperationException();
            }

            var product = cart.Items.FirstOrDefault(i => i.Id == productId);
            if (product == null)
            {
                throw new InvalidOperationException();

            }
            
            cart.Items.Remove(product);

            _httpContextAccessor.HttpContext.Session.Set("cart", cart);

            return cart;
        }

		public void EmptyShoppingCart()
		{
			var cart = new ShoppingCart();
            _httpContextAccessor.HttpContext.Session.Set("cart", cart);
		}

        public int TotalItems()
		{
            ShoppingCart? cart = _httpContextAccessor.HttpContext.Session.Get<ShoppingCart>("cart");
            if(cart == null)
			{
                return 0;
			}
            return cart.Items.Select(i => i.Quantity).Sum();
        }
	}
}
