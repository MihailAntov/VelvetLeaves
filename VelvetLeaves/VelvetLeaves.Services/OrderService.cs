

using VelvetLeaves.Data;
using VelvetLeaves.Service.Models.ShoppingCart;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Order;

namespace VelvetLeaves.Services
{
    public class OrderService : IOrderService
    {
        private readonly VelvetLeavesDbContext _context;
        private readonly IProductService _productService;
        public OrderService(VelvetLeavesDbContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        public async Task<ShoppingCartViewModel> GetShoppingCartForCheckoutAsync(ShoppingCart cart)
        {
            ShoppingCartViewModel model = new ShoppingCartViewModel();
            var products = await _productService.GetProductsForCart(cart.Items.Select(i=> i.Id));
            foreach(var item in products)
            {
                ShoppingCartItemViewModel itemModel = new ShoppingCartItemViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = cart.Items.First(i => i.Id == item.Id).Quantity
                };

                model.Items.Add(itemModel);

                model.Total = model.Items.Select(i => i.Quantity * i.Price).Sum();
                
            }

            return model;
        }
    }
}
