

using VelvetLeaves.Common.Enums;
using VelvetLeaves.Service.Models.ShoppingCart;
using VelvetLeaves.ViewModels.Checkout;
using VelvetLeaves.ViewModels.Order;

namespace VelvetLeaves.Services.Contracts
{
	public interface  IOrderService
    {
        Task<ShoppingCartViewModel> GetShoppingCartForCheckoutAsync(ShoppingCart cart);

        Task<bool> CartValidAsync(ShoppingCartViewModel model);

        CheckoutFormViewModel GetCheckoutInfo(ShoppingCartViewModel cart);

        Task PlaceOrderAsync(CheckoutFormViewModel model,string userId);

        Task<IEnumerable<OrderListViewModel>> AllByIdAsync(string userId);
        Task<IEnumerable<OrderProcessViewModel>> AllAsync(int? status);
    }
}
