﻿

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
        Task<AllOrderProcessViewModel> AllAsync(OrderStatus status);

        Task<OrderProcessViewModel> DetailsAsync(string orderId);

        Task ChangeStatusAsync(string orderId, OrderStatus status);

        Task<string> AddAdminNoteAsync(string note, string orderId);

        Task<bool> ExistsByIdAsync(string orderId);


    }
}
