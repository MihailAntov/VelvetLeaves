

using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data;
using VelvetLeaves.Data.Models;
using VelvetLeaves.Service.Models.ShoppingCart;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.Common.Enums;
using VelvetLeaves.ViewModels.Checkout;
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

		public Task<IEnumerable<OrderListViewModel>> AllAsync()
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<OrderListViewModel>> AllByIdAsync(string userId)
		{
            var orders = await _context
                .Orders
                .Where(o => o.Id.ToString() == userId)
                .Select(o => new OrderListViewModel()
                {
                    Address = $"{o.Country} - {o.City} - {o.StreetAddress}",
                    ZipCode = o.ZipCode,
                    Recipient = $"{o.FirstName} {o.LastName}",
                    Status = o.OrderStatus.ToString(),
                    Date = o.DateTime.ToString("MMMM dd yy"),
                    PhoneNumber = o.PhoneNumber,
                    Products = o.Products
                                .Select(p => new OrderProductListViewModel()
								{
                                    ProductId = p.Id,
                                    Price = p.Price,
                                    ImageId = p.Images.First().Id,
                                    Name = p.Name

								})
                }).ToArrayAsync();

            return orders;
		}

		public async Task<bool> CartValidAsync(ShoppingCartViewModel model)
        {
            foreach(var item in model.Items)
            {
                if(!await _productService.ProductExistsAsync(item.Id))
                {
                    return false;
                }
            }
            return true;

            
        }

        public CheckoutFormViewModel GetCheckoutInfo(ShoppingCartViewModel cart)
        {
            var model = new CheckoutFormViewModel();
            model.Items = cart.Items
                .Select(i => new CheckoutItemViewModel()
                {
                    Id = i.Id,
                    Quantity = i.Quantity
                }).ToArray();

            return model;
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
                    ImageId = item.ImageId,
                    Quantity = cart.Items.First(i => i.Id == item.Id).Quantity
                };

                model.Items.Add(itemModel);

                model.Total = model.Items.Select(i => i.Quantity * i.Price).Sum();
                model.TotalItems = model.Items.Select(i=>i.Quantity).Sum();
                model.Currency = "лв.";
                
            }

            return model;
        }

        public async Task PlaceOrderAsync(CheckoutFormViewModel model, string userId)
        {
            int[] productIds = model.Items.Select(i => i.Id).ToArray();
            var products = await _context
                .Products
                .Where(p => productIds.Contains(p.Id))
                .ToArrayAsync();

            var order = new Order
            {
                Country = model.Country,
                City = model.City,
                StreetAddress = model.Address,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                ZipCode = model.ZipCode,
                OrderStatus = OrderStatus.Processing,
                UserId = userId,
                Products = products,
                DateTime = DateTime.UtcNow
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }
    }
}
