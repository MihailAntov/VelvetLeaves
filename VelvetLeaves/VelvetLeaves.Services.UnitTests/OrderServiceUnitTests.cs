using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelvetLeaves.Common.Enums;
using VelvetLeaves.Data;
using VelvetLeaves.Data.Models;
using VelvetLeaves.Service.Models.ShoppingCart;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Checkout;

namespace VelvetLeaves.Services.UnitTests
{
    [TestFixture]
    public class OrderServiceUnitTests
    {
        private OrderService _orderService;
        private VelvetLeavesDbContext _dbContext;
        private Mock<IProductService> _productServiceMock;
        private Mock<IHelperService> _helperServiceMock;
        private IProductService _productService;
        private IHelperService _helperService;

        [SetUp]
        public async Task Setup()
        {
            var options = new DbContextOptionsBuilder<VelvetLeavesDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _dbContext = new VelvetLeavesDbContext(options);

            _productServiceMock = new Mock<IProductService>();
            _helperServiceMock = new Mock<IHelperService>();
            _productService = _productServiceMock.Object;
            _helperService = _helperServiceMock.Object;
            _helperServiceMock = new Mock<IHelperService>();
            _orderService = new OrderService(_dbContext, _productServiceMock.Object, _helperServiceMock.Object);
            _dbContext.Database.EnsureDeleted();

            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Category 1", IsActive = true, ImageId = "c1mg" },
                new Category { Id = 2, Name = "Category 2", IsActive = true, ImageId = "c2mg" },
                new Category { Id = 3, Name = "Category 3", IsActive = true, ImageId = "c3img" }
            };

            var subcategories = new List<Subcategory>
            {
                new Subcategory { Id = 1, Name = "Subcategory 1", CategoryId = 1, IsActive = true, ImageId = "sc1img" },
                new Subcategory { Id = 2, Name = "Subcategory 2", CategoryId = 2, IsActive = true, ImageId = "sc2img" },
                new Subcategory { Id = 3, Name = "Subcategory 3", CategoryId = 3, IsActive = true, ImageId = "sc3img" }
            };

            var tags = new List<Tag>
            {
                new Tag { Id = 1, Name = "Tag 1" },
                new Tag { Id = 2, Name = "Tag 2" },
                new Tag { Id = 3, Name = "Tag 3" }
            };

            var productSeries = new List<ProductSeries>
            {
                new ProductSeries { Id = 1, Name = "Series 1", SubcategoryId = 1, IsActive = true, DefaultName = "Series1Name", DefaultDescription = "Series1Description", DefaultTags = new List<Tag> { tags[0] }, DefaultColors = new List<Color>(), DefaultMaterials = new List<Material>() },
                new ProductSeries { Id = 2, Name = "Series 2", SubcategoryId = 2, IsActive = true, DefaultName = "Series2Name", DefaultDescription = "Series2Description", DefaultTags = new List<Tag> {  }, DefaultColors = new List<Color>(), DefaultMaterials = new List<Material>() },
                new ProductSeries { Id = 3, Name = "Series 3", SubcategoryId = 3, IsActive = true, DefaultName = "Series3Name", DefaultDescription = "Series3Description", DefaultTags = new List<Tag> {  }, DefaultColors = new List<Color>(), DefaultMaterials = new List<Material>() }
            };




            var materials = new List<Material>
            {
                new Material { Id = 1, Name = "Material 1" },
                new Material { Id = 2, Name = "Material 2" },
                new Material { Id = 3, Name = "Material 3" }
            };

            var colors = new List<Color>
            {
                new Color {Id = 1, Name = "Color 1", ColorValue = "Value1"},
                new Color {Id = 2, Name = "Color 2", ColorValue = "Value2"},
                new Color {Id = 3, Name = "Color 3", ColorValue = "Value3"}
            };

            var products = new[]
            {
                new Product { Id = 1, SubcategoryId = 1, IsActive = true, Name = "Product1 Name", Description = "Product1 Description", Price=10.00M, Images = new List<Image> {new Image {Id = "p1img1" }, new Image {Id = "p1img2"} }, ProductSeriesId = 1, Colors = new List<Color> {colors[0], colors[1] } },
                new Product { Id = 2, SubcategoryId = 1, IsActive = true , Name = "Product2 Name", Description = "Product2 Description",Price=60.00M, Images = new List<Image> {new Image {Id = "p2img1" }, new Image {Id = "p2img2"}, new Image{Id = "p2img3" } }, ProductSeriesId = 1 , Colors = new List<Color> {colors[0], colors[1] } },
                new Product { Id = 3, SubcategoryId = 2, IsActive = false, Name = "Product3 Name", Description = "Product3 Description",Price=50.00M, Images = new List<Image> {new Image {Id = "p3img1" }, new Image {Id = "p3img2"} }, ProductSeriesId = 2 }, // Inactive product
                new Product { Id = 4, SubcategoryId = 2, IsActive = true, Name = "Product4 Name", Description = "Product4 Description",Price=40.00M, Images = new List<Image> {new Image {Id = "p4img1" }, new Image {Id = "p4img2"} }, ProductSeriesId = 2 , Colors = new List<Color> {colors[2] }},
                new Product { Id = 5, SubcategoryId = 2, IsActive = true, Name = "Product5 Name", Description = "Product5 Description",Price=20.00M, Images = new List<Image> {new Image {Id = "p5img1" }, new Image {Id = "p5img2"} }, ProductSeriesId = 2 , Tags = new List<Tag> { new Tag { Id = 4, Name = "Tag 4" } }, Materials = new List<Material> { new Material { Id = 4, Name = "Material 4" } } },
                new Product { Id = 6, SubcategoryId = 2, IsActive = true, Name = "Product6 Name", Description = "Product6 Description",Price=30.00M, Images = new List<Image> {new Image {Id = "p6img1" }, new Image {Id = "p6img2"} }, ProductSeriesId = 2 }
            };

            var orders = new List<Order>
            {
                new Order { Id = Guid.NewGuid(), UserId = "user1", OrderStatus = OrderStatus.Pending, City = "test1", Country = "test", StreetAddress = "test", FirstName = "test", LastName = "test", PhoneNumber = "test123", OrdersProducts = new List<OrderProduct>{ new OrderProduct {ProductId = 1 } } },
                new Order { Id = Guid.NewGuid(), UserId = "user1", OrderStatus = OrderStatus.Processing, City = "test2", Country = "test", StreetAddress = "test", FirstName = "test", LastName = "test", PhoneNumber = "test123", OrdersProducts = new List<OrderProduct>{ new OrderProduct {ProductId = 2 } } },
                new Order { Id = Guid.NewGuid(), UserId = "user2", OrderStatus = OrderStatus.Pending, City = "test3", Country = "test", StreetAddress = "test", FirstName = "test", LastName = "test", PhoneNumber = "test123", OrdersProducts = new List<OrderProduct>{ new OrderProduct {ProductId = 4 }, new OrderProduct { ProductId = 5 } } }
            };

            
            _dbContext.Orders.AddRange(orders);
            _dbContext.Categories.AddRange(categories);
            _dbContext.Subcategories.AddRange(subcategories);
            _dbContext.ProductSeries.AddRange(productSeries);
            _dbContext.Tags.AddRange(tags);
            _dbContext.Materials.AddRange(materials);
            _dbContext.Colors.AddRange(colors);
            _dbContext.Products.AddRange(products);
            
            await _dbContext.SaveChangesAsync();

        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted();
        }

        // Test for AddAdminNoteAsync method
        [Test]
        public async Task AddAdminNoteAsync_ExistingOrder_ShouldAddNote()
        {
            // Arrange
            await _dbContext.Database.EnsureDeletedAsync();

            Guid orderId = Guid.NewGuid();
            Order order = new Order
            {
                Id = orderId,
                UserId = "user2",
                OrderStatus = OrderStatus.Pending,
                City = "test3",
                Country = "test",
                StreetAddress = "test",
                FirstName = "test",
                LastName = "test",
                PhoneNumber = "test123",
                OrdersProducts = new List<OrderProduct> { new OrderProduct { ProductId = 4 }, new OrderProduct { ProductId = 5 } }
            };
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();

           
            var note = "Admin note";

            // Act
            var result = await _orderService.AddAdminNoteAsync(note, orderId.ToString());

            // Assert
            Assert.AreEqual(note, result);
            Assert.AreEqual(note, order.AdminNote);
        }

        [Test]
        public void AddAdminNoteAsync_NonExistingOrder_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var orderId = Guid.NewGuid().ToString();
            var note = "Admin note";

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _orderService.AddAdminNoteAsync(note, orderId));
        }

        // Test for AllAsync method
        [Test]
        public async Task AllAsync_ShouldReturnCorrectOrders()
        {
            // Arrange
            

            var orderStatus = OrderStatus.Processing;

            // Act
            var result = await _orderService.AllAsync(orderStatus);

            // Assert
            Assert.AreEqual(1, result.Orders.Count());
            Assert.AreEqual(orderStatus.ToString() + " Orders", result.Title);
        }

        [Test]
        public async Task AllAsync_NoOrders_ShouldReturnEmptyResult()
        {
            // Arrange
            var orderStatus = OrderStatus.Complete;

            // Act
            var result = await _orderService.AllAsync(orderStatus);

            // Assert
            Assert.IsEmpty(result.Orders);
            Assert.AreEqual(orderStatus.ToString() + " Orders", result.Title);
        }

        // Test for AllByIdAsync method
        [Test]
        public async Task AllByIdAsync_ShouldReturnCorrectOrders()
        {
            // Arrange
            var userId = "user1";
            

            // Act
            var result = await _orderService.AllByIdAsync(userId);

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public async Task AllByIdAsync_NoOrders_ShouldReturnEmptyResult()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();

            // Act
            var result = await _orderService.AllByIdAsync(userId);

            // Assert
            Assert.IsEmpty(result);
        }

        [Test]
        public async Task DetailsAsync_ExistingOrderId_ShouldReturnOrderProcessViewModel()
        {
            // Arrange
            var orderId = Guid.NewGuid().ToString();

            var order = new Order
            {
                Id = new Guid(orderId),
                OrderStatus = OrderStatus.Pending,
                DateTime = DateTime.Now,
                PhoneNumber = "test123",
                FirstName = "test",
                LastName = "test",
                City = "test1",
                Country = "test",
                StreetAddress = "test",
                ZipCode = "12345",
                AdminNote = "admin note",
                OrdersProducts = new List<OrderProduct> { new OrderProduct { ProductId = 1, Quantity = 2 } }
            };

            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();

            var orderService = new OrderService(_dbContext, _productService, _helperService);

            // Act
            var result = await orderService.DetailsAsync(orderId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(order.Id.ToString(), result.Id);
            Assert.AreEqual(order.OrderStatus, result.Status);
            Assert.AreEqual(order.DateTime, result.Date);
            Assert.AreEqual(order.PhoneNumber, result.PhoneNumber);
            Assert.AreEqual(order.FirstName, result.FirstName);
            Assert.AreEqual(order.LastName, result.LastName);
            Assert.AreEqual(order.City, result.City);
            Assert.AreEqual(order.Country, result.Country);
            Assert.AreEqual(order.StreetAddress, result.StreetAddress);
            Assert.AreEqual(order.ZipCode, result.ZipCode);
            Assert.AreEqual(order.OrdersProducts.Sum(op => op.Product.Price * op.Quantity), result.Total);
            Assert.AreEqual(order.AdminNote, result.AdminNote);
            Assert.AreEqual(order.OrdersProducts.Count, result.Products.Count());
            // Add more assertions for products if needed
        }

        [Test]
        public async Task DetailsAsync_NonExistingOrderId_ShouldThrow()
        {
            // Arrange
            var orderId = Guid.NewGuid().ToString();
            var orderService = new OrderService(_dbContext, _productService, _helperService);

            // Act


            // Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _orderService.DetailsAsync(orderId));
        }

        [Test]
        public async Task CartValidAsync_AllItemsExist_ShouldReturnTrue()
        {
            // Arrange
            var cart = new ShoppingCartViewModel
            {
                Items = new List<ShoppingCartItemViewModel>
                {
                    new ShoppingCartItemViewModel { Id = 1, Quantity = 2 },
                    new ShoppingCartItemViewModel { Id = 2, Quantity = 1 },
                }
            };

            _productServiceMock.Setup(p => p.ExistsByIdAsync(It.IsAny<int>())).ReturnsAsync(true);
            var orderService = new OrderService(_dbContext, _productServiceMock.Object, _helperServiceMock.Object);

            // Act
            var result = await orderService.CartValidAsync(cart);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task CartValidAsync_AtLeastOneItemDoesNotExist_ShouldReturnFalse()
        {
            // Arrange
            var cart = new ShoppingCartViewModel
            {
                Items = new List<ShoppingCartItemViewModel>
                {
                    new ShoppingCartItemViewModel { Id = 1, Quantity = 2 },
                    new ShoppingCartItemViewModel { Id = 3, Quantity = 1 },
                }
            };

            _productServiceMock.Setup(p => p.ExistsByIdAsync(1)).ReturnsAsync(true);
            _productServiceMock.Setup(p => p.ExistsByIdAsync(3)).ReturnsAsync(false);
            var orderService = new OrderService(_dbContext, _productServiceMock.Object, _helperServiceMock.Object);

            // Act
            var result = await orderService.CartValidAsync(cart);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task ChangeStatusAsync_ExistingOrderId_ShouldChangeStatus()
        {
            // Arrange


            var order = await _dbContext.Orders.FirstAsync();
            string orderId = order.Id.ToString();

            var orderService = new OrderService(_dbContext, _productServiceMock.Object, _helperServiceMock.Object);

            // Act
            await orderService.ChangeStatusAsync(orderId, OrderStatus.Processing);
            

            // Assert
            Assert.AreEqual(OrderStatus.Processing, order.OrderStatus);
        }

        [Test]
        public void ChangeStatusAsync_NonExistingOrderId_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var orderId = Guid.NewGuid().ToString();
            var orderService = new OrderService(_dbContext, _productServiceMock.Object, _helperServiceMock.Object);

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => await orderService.ChangeStatusAsync(orderId, OrderStatus.Processing));
        }


        [Test]
        public void GetCheckoutInfo_ShouldMapToCheckoutFormViewModel()
        {
            // Arrange
            var cart = new ShoppingCartViewModel
            {
                Items = new List<ShoppingCartItemViewModel>
                {
                    new ShoppingCartItemViewModel { Id = 1, Quantity = 2 },
                    new ShoppingCartItemViewModel { Id = 2, Quantity = 1 },
                }
            };
            var orderService = new OrderService(_dbContext, _productServiceMock.Object, _helperServiceMock.Object);

            // Act
            var checkoutInfo = orderService.GetCheckoutInfo(cart);

            // Assert
            Assert.IsInstanceOf<CheckoutFormViewModel>(checkoutInfo);
            Assert.AreEqual(cart.Items.Count, checkoutInfo.Items.Count);
            Assert.AreEqual(cart.Items[0].Id, checkoutInfo.Items[0].Id);
            Assert.AreEqual(cart.Items[0].Quantity, checkoutInfo.Items[0].Quantity);
            Assert.AreEqual(cart.Items[1].Id, checkoutInfo.Items[1].Id);
            Assert.AreEqual(cart.Items[1].Quantity, checkoutInfo.Items[1].Quantity);
        }

        [Test]
        public async Task GetShoppingCartForCheckoutAsync_ShouldReturnShoppingCartViewModel()
        {
            // Arrange
            var cart = new ShoppingCart
            {
                Items = new List<ShoppingCartItem>
                {
                    new ShoppingCartItem { Id = 10, Quantity = 2 },
                    new ShoppingCartItem { Id = 11, Quantity = 1 },
                }
            };

            var products = new List<Product>
            {
                new Product { Id = 10, Name = "Product 10", Price = 10.00M, Images = new List<Image> {new Image{Id = "p10img1" } },  Description = "test"},
                new Product { Id = 11, Name = "Product 11", Price = 15.00M, Images = new List<Image> {new Image{Id = "p11img1" } }  ,Description = "test"}
            };
            _dbContext.Products.AddRange(products);
            await _dbContext.SaveChangesAsync();

            var productDtos = new List<ProductForCartDto>
            {
                new ProductForCartDto { Id = 10, Name = "Product 10", Price = 10.00M, ImageId = "p10img1"},
                new ProductForCartDto {Id =  11, Name = "Product 11", Price = 15.00M, ImageId = "p11img1"}
            };
            
            _productServiceMock.Setup(p => p.GetProductsForCart(It.IsAny<IEnumerable<int>>())).ReturnsAsync(productDtos);
            _helperServiceMock.Setup(h => h.Currency()).ReturnsAsync("USD");
            var orderService = new OrderService(_dbContext, _productServiceMock.Object, _helperServiceMock.Object);

            // Act
            var shoppingCartForCheckout = await orderService.GetShoppingCartForCheckoutAsync(cart);

            // Assert
            Assert.IsInstanceOf<ShoppingCartViewModel>(shoppingCartForCheckout);
            Assert.AreEqual(2, shoppingCartForCheckout.Items.Count);
            Assert.AreEqual(products[0].Name, shoppingCartForCheckout.Items[0].Name);
            Assert.AreEqual(products[0].Price, shoppingCartForCheckout.Items[0].Price);
            Assert.AreEqual(cart.Items[0].Quantity, shoppingCartForCheckout.Items[0].Quantity);
            Assert.AreEqual(products[1].Name, shoppingCartForCheckout.Items[1].Name);
            Assert.AreEqual(products[1].Price, shoppingCartForCheckout.Items[1].Price);
            Assert.AreEqual(cart.Items[1].Quantity, shoppingCartForCheckout.Items[1].Quantity);
            Assert.AreEqual(2 * 10.00M + 1 * 15.00M, shoppingCartForCheckout.Total);
            Assert.AreEqual(2 + 1, shoppingCartForCheckout.TotalItems);
            Assert.AreEqual("USD", shoppingCartForCheckout.Currency);
        }

        [Test]
        public async Task PlaceOrderAsync_ShouldAddNewOrderToDatabase()
        {
            // Arrange
            await _dbContext.Database.EnsureDeletedAsync();

            var model = new CheckoutFormViewModel
            {
                Country = "Country",
                City = "City",
                Address = "Address",
                FirstName = "First Name",
                LastName = "Last Name",
                PhoneNumber = "1234567890",
                ZipCode = "12345",
                Email = "test@example.com",
                Items = new List<CheckoutItemViewModel>
                {
                    new CheckoutItemViewModel { Id = 1, Quantity = 2 },
                    new CheckoutItemViewModel { Id = 2, Quantity = 1 }
                }
            };
            var userId = "user123";
            var orderService = new OrderService(_dbContext, _productServiceMock.Object, _helperServiceMock.Object);

            // Act
            await orderService.PlaceOrderAsync(model, userId);

            // Assert
            var ordersInDb = await _dbContext.Orders.ToListAsync();
            Assert.AreEqual(1, ordersInDb.Count);
            var orderInDb = ordersInDb.First();
            Assert.AreEqual(model.Country, orderInDb.Country);
            Assert.AreEqual(model.City, orderInDb.City);
            Assert.AreEqual(model.Address, orderInDb.StreetAddress);
            Assert.AreEqual(model.FirstName, orderInDb.FirstName);
            Assert.AreEqual(model.LastName, orderInDb.LastName);
            Assert.AreEqual(model.PhoneNumber, orderInDb.PhoneNumber);
            Assert.AreEqual(model.ZipCode, orderInDb.ZipCode);
            Assert.AreEqual(OrderStatus.Pending, orderInDb.OrderStatus);
            Assert.AreEqual(userId, orderInDb.UserId);
            Assert.AreEqual(model.Items.Count, orderInDb.OrdersProducts.Count);
            Assert.AreEqual(DateTime.UtcNow.Date, orderInDb.DateTime.Date);
            Assert.AreEqual(model.Email, orderInDb.Email);
        }


    }
}
