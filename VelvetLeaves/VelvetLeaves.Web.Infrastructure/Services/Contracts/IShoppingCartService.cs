

using VelvetLeaves.Web.Infrastructure.Models;

namespace VelvetLeaves.Web.Infrastructure.Services.Contracts
{
    public interface IShoppingCartService
    {
        void AddItemToShoppingCart(int productId);

        Task RemoveItemFromShoppingCart(int productId);

        Task<ShoppingCart> GetShoppingCart();
    }
}
