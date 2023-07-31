

using VelvetLeaves.Service.Models.ShoppingCart;
using VelvetLeaves.ViewModels.Order;


namespace VelvetLeaves.Web.Infrastructure.Services.Contracts
{
    public interface IShoppingCartService
    {
        void AddItemToShoppingCart(int productId);

        void RemoveItemFromShoppingCart(int productId);

        ShoppingCart GetShoppingCart();
    }
}
