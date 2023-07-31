﻿

using VelvetLeaves.Service.Models.ShoppingCart;
using VelvetLeaves.ViewModels.Order;

namespace VelvetLeaves.Services.Contracts
{
    public interface  IOrderService
    {
        Task<ShoppingCartViewModel> GetShoppingCartForCheckout(ShoppingCart cart);
    }
}