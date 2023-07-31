﻿

using VelvetLeaves.Service.Models.ShoppingCart;
using VelvetLeaves.ViewModels.Order;


namespace VelvetLeaves.Web.Infrastructure.Services.Contracts
{
    public interface IShoppingCartService
    {
        ShoppingCart AddOneItemToShoppingCart(int productId);

        ShoppingCart RemoveOneItemFromShoppingCart(int productId);

        ShoppingCart GetShoppingCart();

        ShoppingCart DeleteItemFromShoppingCart(int productId);
    }
}
