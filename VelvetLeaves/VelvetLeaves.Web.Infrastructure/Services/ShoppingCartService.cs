

using Microsoft.AspNetCore.Http;
using VelvetLeaves.Web.Infrastructure.Extensions;
using VelvetLeaves.Web.Infrastructure.Models;
using VelvetLeaves.Web.Infrastructure.Services.Contracts;

namespace VelvetLeaves.Web.Infrastructure.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly HttpContextAccessor _httpContextAccessor;
        public ShoppingCartService(HttpContextAccessor httpContextAccessor)
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

            var product = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if(product == null)
            {
                product = new ShoppingCartItem()
                {
                    ProductId = productId,
                    Quantity = 0
                };
                cart.Items.Append(product);
            }

            product.Quantity++;

            _httpContextAccessor.HttpContext.Session.Set<ShoppingCart>("cart", cart);
            
        }

        public Task<ShoppingCart> GetShoppingCart()
        {
            throw new NotImplementedException();
        }

        public Task RemoveItemFromShoppingCart(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
