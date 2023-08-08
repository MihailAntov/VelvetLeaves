

using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data;
using VelvetLeaves.Data.Models;

namespace VelvetLeaves.Services.UnitTests
{
	public class FavoriteServiceUnitTests
	{
        private DbContextOptions<VelvetLeavesDbContext> _dbContextOptions;
        private FavoriteService _favoriteService;
        private VelvetLeavesDbContext _context;

        [SetUp]
        public void Setup()
        {
            _dbContextOptions = new DbContextOptionsBuilder<VelvetLeavesDbContext>()
                .UseInMemoryDatabase(databaseName: "test_db")
                .Options;

             _context = new VelvetLeavesDbContext(_dbContextOptions);
            _favoriteService = new FavoriteService(_context);
        }

		[TearDown]
        public async Task TearDown()
		{
            await _context.Database.EnsureDeletedAsync();
            await _context.DisposeAsync();
		}

        [Test]
        public async Task GetFavoritesByUserIdAsync_ExistingUserId_ReturnsFavorites()
        {
            // Arrange
            var userId = "user1";
            var products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Description = "Description 1", IsActive = true, Images = new List<Image> { new Image { Id = "image1" } , new Image {Id = "image2" }  } },
            new Product { Id = 2, Name = "Product 2", Description = "Description 2", IsActive = true ,Images = new List<Image> { new Image { Id = "image3" } , new Image {Id = "image4" }  } }
        };
            var user = new ApplicationUser { Id = userId, Favorites = products };


            _context.Users.Add(user);
            _context.Products.AddRange(products);
                await _context.SaveChangesAsync();
            

            // Act
            var result = await _favoriteService.GetFavoritesByUserIdAsync(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(products.Count, result.Count);
            Assert.AreEqual("Product 1", result.First().Name);
        }

        [Test]
        public async Task AddToFavorites_ValidData_AddsProductToUserFavorites()
        {
            // Arrange
            var userId = "user1";
            var productId = 1;
            var user = new ApplicationUser { Id = userId };
            var product = new Product { Id = 1, Name = "Product 1", Description = "Description 1", IsActive = true, Images = new List<Image> { new Image { Id = "image1" }, new Image { Id = "image2" } } };



            _context.Users.Add(user);
            _context.Products.Add(product);
                await _context.SaveChangesAsync();
            

            // Act
            await _favoriteService.AddToFavorites(userId, productId);

            // Assert
            
                var updatedUser = _context.Users.Include(u => u.Favorites).Single(u => u.Id == userId);
                Assert.AreEqual(1, updatedUser.Favorites.Count);
                Assert.AreEqual(productId, updatedUser.Favorites.Single().Id);
            
        }

		[Test]
        public async Task AddToFavorites_InValidData_UserIncorrect()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var productId = 1;
            var product = new Product { Id = 1, Name = "Product 1", Description = "Description 1", IsActive = true, Images = new List<Image> { new Image { Id = "image1" }, new Image { Id = "image2" } } };



            
            _context.Products.Add(product);
            await _context.SaveChangesAsync();


            // Act
            await _favoriteService.AddToFavorites(userId, productId);

            // Assert

            var usersWithThisProduct = await _context.Users
                .Where(u => u.Favorites.Contains(product)).ToArrayAsync();
            Assert.AreEqual(0, usersWithThisProduct.Count());
            

        }

        [Test]
        public async Task AddToFavorites_InValidData_ProductIncorrect()
        {
            // Arrange
            var userId = "user1";
            var productId = 999;
            var user = new ApplicationUser { Id = userId };
            var product = new Product { Id = 1, Name = "Product 1", Description = "Description 1", IsActive = true, Images = new List<Image> { new Image { Id = "image1" }, new Image { Id = "image2" } } };



            _context.Users.Add(user);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();


            // Act
            await _favoriteService.AddToFavorites(userId, productId);

            // Assert

            var updatedUser = _context.Users.Include(u => u.Favorites).Single(u => u.Id == userId);
            Assert.AreEqual(0, updatedUser.Favorites.Count);


        }


        [Test]
        public async Task RemoveFromFavorites_ValidData_RemovesProductFromUserFavorites()
        {
            // Arrange
            var userId = "user1";
            var productId = 1;
            var product = new Product { Id = 1, Name = "Product 1", Description = "Description 1", IsActive = true, Images = new List<Image> { new Image { Id = "image1" }, new Image { Id = "image2" } } };
            var user = new ApplicationUser { Id = userId, Favorites = new List<Product> { product } };


            _context.Users.Add(user);
            _context.Products.Add(product);
                await _context.SaveChangesAsync();
            

            // Act
            await _favoriteService.RemoveFromFavorites(userId, productId);

            // Assert
           
                var updatedUser = _context.Users.Include(u => u.Favorites).Single(u => u.Id == userId);
                Assert.IsEmpty(updatedUser.Favorites);
            
        }

        [Test]
        public async Task RemoveFromFavorites_InValidData_IncorrectProduct()
        {
            // Arrange
            var userId = "user1";
            var productId = 1;
            var user = new ApplicationUser { Id = userId };


            _context.Users.Add(user);
            await _context.SaveChangesAsync();


            // Act
            await _favoriteService.RemoveFromFavorites(userId, productId);

            // Assert

            var updatedUser = _context.Users.Include(u => u.Favorites).Single(u => u.Id == userId);
            Assert.IsEmpty(updatedUser.Favorites);

        }

        [Test]
        public async Task RemoveFromFavorites_InValidData_IncorrectUser()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var productId = 1;
            var product = new Product { Id = 1, Name = "Product 1", Description = "Description 1", IsActive = true, Images = new List<Image> { new Image { Id = "image1" }, new Image { Id = "image2" } } };
            var user = new ApplicationUser { Id = "testId", Favorites = new List<Product> { product } };

            _context.Users.Add(user);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();


            // Act
            await _favoriteService.RemoveFromFavorites(userId, productId);

            // Assert

            var userAfterChange = await _context.Users.Include(u => u.Favorites).Where(u => u.Id == "testId").FirstAsync();
            Assert.AreEqual(1, userAfterChange.Favorites.Count());

        }

        [Test]
        public async Task IsFavorited_ProductIsFavorited_ReturnsTrue()
        {
            // Arrange
            var userId = "user1";
            var productId = 1;
            var product = new Product { Id = 1, Name = "Product 1", Description = "Description 1", IsActive = true, Images = new List<Image> { new Image { Id = "image1" }, new Image { Id = "image2" } } };
            var user = new ApplicationUser { Id = userId, Favorites = new List<Product> { product } };


            _context.Users.Add(user);
            _context.Products.Add(product);
                await _context.SaveChangesAsync();
            

            // Act
            var result = await _favoriteService.IsFavorited(userId, productId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsFavorited_ProductIsNotFavorited_ReturnsFalse()
        {
            // Arrange
            var userId = "user1";
            var productId = 1;
            var user = new ApplicationUser { Id = userId };
            var product = new Product { Id = 1, Name = "Product 1", Description = "Description 1", IsActive = true, Images = new List<Image> { new Image { Id = "image1" }, new Image { Id = "image2" } } };


            _context.Users.Add(user);
            _context.Products.Add(product);
                await _context.SaveChangesAsync();
            

            // Act
            var result = await _favoriteService.IsFavorited(userId, productId);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task IsFavorited_ProductIsNotFavorited_IncorrectUser_ReturnsFalse()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var productId = 1;
            var product = new Product { Id = 1, Name = "Product 1", Description = "Description 1", IsActive = true, Images = new List<Image> { new Image { Id = "image1" }, new Image { Id = "image2" } } };


            _context.Products.Add(product);
            await _context.SaveChangesAsync();


            // Act
            var result = await _favoriteService.IsFavorited(userId, productId);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task IsFavorited_ProductIsNotFavorited_IncorrectProduct_ReturnsFalse()
        {
            // Arrange
            var userId = "user1";
            var productId = 9999;
            var user = new ApplicationUser { Id = userId };


            _context.Users.Add(user);
            await _context.SaveChangesAsync();


            // Act
            var result = await _favoriteService.IsFavorited(userId, productId);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
