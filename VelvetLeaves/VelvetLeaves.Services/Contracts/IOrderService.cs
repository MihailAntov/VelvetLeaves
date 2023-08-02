

using VelvetLeaves.Service.Models.ShoppingCart;
using VelvetLeaves.ViewModels.Order;

namespace VelvetLeaves.Services.Contracts
{
    public interface  IOrderService
    {
        Task<ShoppingCartViewModel> GetShoppingCartForCheckoutAsync(ShoppingCart cart);

        Task<bool> CartValidAsync(ShoppingCartViewModel model);

        CheckoutFormViewModel GetCheckoutInfo(ShoppingCartViewModel cart);

        Task PlaceOrderAsync(CheckoutFormViewModel model,string userId);
    }
}
