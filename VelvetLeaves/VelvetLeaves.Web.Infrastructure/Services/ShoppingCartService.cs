

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

        public void AddItemToShoppingCart(int productId)
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

        public void RemoveItemFromShoppingCart(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
