

using VelvetLeaves.Service.Models.ShoppingCart;
using VelvetLeaves.ViewModels.Order;


namespace VelvetLeaves.Web.Infrastructure.Services.Contracts
{
    public interface IShoppingCartService
    {
        ShoppingCart AddItemToShoppingCart(int productId);

        ShoppingCart RemoveItemFromShoppingCart(int productId);

        ShoppingCart GetShoppingCart();
    }
}
