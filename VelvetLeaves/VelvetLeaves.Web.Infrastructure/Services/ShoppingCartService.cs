

using Microsoft.AspNetCore.Http;
using VelvetLeaves.Service.Models.ShoppingCart;
using VelvetLeaves.ViewModels.Order;
using VelvetLeaves.Web.Infrastructure.Extensions;
using VelvetLeaves.Web.Infrastructure.Services.Contracts;

namespace VelvetLeaves.Web.Infrastructure.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ShoppingCartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ShoppingCart AddItemToShoppingCart(int productId)
        {
            ShoppingCart? cart = _httpContextAccessor.HttpContext.Session.Get<ShoppingCart>("cart");
            if(cart == null)
            {
                cart = new ShoppingCart();
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

        public ShoppingCart GetShoppingCart()
        {
            ShoppingCart? cart = _httpContextAccessor.HttpContext.Session.Get<ShoppingCart>("cart");
            if(cart == null)
            {
                cart = new ShoppingCart();
            }
            return cart;
        }

        public ShoppingCart RemoveItemFromShoppingCart(int productId)
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

            product.Quantity--;
            if(product.Quantity <= 0)
            {
                cart.Items.Remove(product);
            }

            _httpContextAccessor.HttpContext.Session.Set("cart", cart);

            return cart;
        }
    }
}
