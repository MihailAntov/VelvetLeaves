

using VelvetLeaves.Service.Models.ShoppingCart;
using VelvetLeaves.ViewModels.Order;


namespace VelvetLeaves.Web.Infrastructure.Services.Contracts
{
    public interface IShoppingCartService
    {
       Task<ShoppingCart> AddOneItemToShoppingCart(int productId);

        ShoppingCart RemoveOneItemFromShoppingCart(int productId);

        Task<ShoppingCart> GetShoppingCart();

        int TotalItems();

        ShoppingCart DeleteItemFromShoppingCart(int productId);

        void EmptyShoppingCart();
    }
}
