

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
        private readonly IHelperService _helperService;
        public OrderService(VelvetLeavesDbContext context,
            IProductService productService,
            IHelperService helperService)
        {
            _context = context;
            _productService = productService;
            _helperService = helperService;
        }



        public async Task<AllOrderProcessViewModel> AllAsync(OrderStatus status)
		{
            var orders = await _context.Orders
                .OrderByDescending(o=> o.DateTime)
                .Where(o => o.OrderStatus == (OrderStatus)status)
			    .Select(o => new OrderProcessViewModel()
                {
                    Id = o.Id.ToString(),
                    StreetAddress = o.StreetAddress,
                    City = o.City,
                    Country = o.Country,
                    ZipCode = o.ZipCode,
                    FirstName = o.FirstName,
                    LastName = o.LastName,
                    Status = o.OrderStatus,
                    Date = o.DateTime,
                    Total = o.OrdersProducts.Select(op => op.Product.Price * op.Quantity).Sum(),
                    PhoneNumber = o.PhoneNumber,
                    Products = o.OrdersProducts
                                .Select(op => new OrderProductListViewModel()
                                {
                                    ProductId = op.Product.Id,
                                    Price = op.Product.Price,
                                    ImageId = op.Product.Images.First().Id,
                                    Name = op.Product.Name,
                                    Quantity = op.Quantity

                                })
                }).ToArrayAsync();


            var model = new AllOrderProcessViewModel
            {
                Orders = orders,
                Title = $"{status.ToString()} Orders"

            };
            
            return model;
        }

		public async Task<IEnumerable<OrderListViewModel>> AllByIdAsync(string userId)
		{
            var orders = await _context
                .Orders
                .Where(o => o.UserId == userId)
                .Select(o => new OrderListViewModel()
                {
                    FirstName = o.FirstName,
                    LastName = o.LastName,
                    StreetAddress = o.StreetAddress,
                    City = o.City,
                    Country = o.Country,
                    ZipCode = o.ZipCode,
                    Status = o.OrderStatus,
                    Date = o.DateTime,
                    PhoneNumber = o.PhoneNumber,
                    Total = o.OrdersProducts.Select(op=> op.Product.Price * op.Quantity).Sum(),
					Products = o.OrdersProducts
								.Select(op => new OrderProductListViewModel()
								{
									ProductId = op.Product.Id,
									Price = op.Product.Price,
									ImageId = op.Product.Images.First().Id,
									Name = op.Product.Name,
                                    Quantity = op.Quantity

								})
				})
                .OrderByDescending(o=> o.Date)
                .ToArrayAsync();

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
        public async Task ChangeStatusAsync(string orderId, OrderStatus status)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id.ToString() == orderId);
            if(order == null)
            {
                throw new InvalidOperationException();
            }

            order.OrderStatus = status;
            await _context.SaveChangesAsync();
        }


        public async Task<OrderProcessViewModel> DetailsAsync(string orderId)
        {
            var order = await _context
                .Orders
                .Where(o => o.Id.ToString() == orderId)
                .Select(o => new OrderProcessViewModel()
                {
                    Id = o.Id.ToString(),
                    Status = o.OrderStatus,
                    Date = o.DateTime,
                    PhoneNumber = o.PhoneNumber,
                    FirstName = o.FirstName,
                    LastName = o.LastName,
                    City = o.City,
                    Country = o.Country,
                    StreetAddress = o.StreetAddress,
                    ZipCode = o.ZipCode,
                    Total = o.OrdersProducts.Select(op => op.Product.Price * op.Quantity).Sum(),
                    Products = o.OrdersProducts
                                .Select(op => new OrderProductListViewModel()
                                {
                                    ProductId = op.Product.Id,
                                    Price = op.Product.Price,
                                    ImageId = op.Product.Images.First().Id,
                                    Name = op.Product.Name,
                                    Quantity = op.Quantity,
                                    Id = op.ProductId,
                                    CategoryId = op.Product.Subcategory.CategoryId,
                                    SubcategoryId = op.Product.SubcategoryId,
                                    ProductSeriesId = op.Product.ProductSeriesId,
                                    Removed = !op.Product.IsActive

                                })


                }).FirstAsync();

            return order;
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
                model.Currency = await _helperService.Currency();
                
            }

            return model;
        }

        public async Task PlaceOrderAsync(CheckoutFormViewModel model, string userId)
        {
            

            var order = new Order
            {
                Country = model.Country,
                City = model.City,
                StreetAddress = model.Address,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                ZipCode = model.ZipCode,
                OrderStatus = OrderStatus.Pending,
                UserId = userId,
                OrdersProducts = model.Items.Select(i => new OrderProduct()
                {
                    ProductId = i.Id,
                    Quantity = i.Quantity
                }).ToArray(),
				DateTime = DateTime.UtcNow
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

       

        
    }
}
