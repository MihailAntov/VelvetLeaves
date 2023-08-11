

using Microsoft.EntityFrameworkCore;
using Moq;
using VelvetLeaves.Data;
using VelvetLeaves.Data.Models;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Gallery;

namespace VelvetLeaves.Services.UnitTests
{
    [TestFixture]
    public class GalleryServiceUnitTests
    {
        private IGalleryService _galleryService;
        private VelvetLeavesDbContext _context;

        [SetUp]
        public async Task Setup()
        {
            var options = new DbContextOptionsBuilder<VelvetLeavesDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new VelvetLeavesDbContext(options);
            _galleryService = new GalleryService(_context);
            await _context.Database.EnsureDeletedAsync();

            await AddTestGalleries();
        }


        private async Task AddTestGalleries()
        {
            // Add some test data to the in-memory database for testing
            var galleries = new List<Gallery>
            {
                new Gallery
                {
                    Id = 1,
                    Name = "Gallery 1",
                    Description = "Description 1",
                    IsActive = true,
                    ImageId = "ImageId1",
                    GalleriesProducts = new List<GalleryProduct>
                    {
                        new GalleryProduct { Product = new Product { Id = 1, Name = "Product 1", IsActive = true, Price = 10.99M ,Description = "test", Images = new List<Image>{ { new Image() { Id = "img1" } } }}, Position = 1 },
                        new GalleryProduct { Product = new Product { Id = 2, Name = "Product 2", IsActive = true, Price = 19.99M ,Description = "test", Images = new List<Image>{ { new Image() { Id = "img2" } } }}, Position = 2 }
                    }
                },
                new Gallery
                {
                    Id = 2,
                    Name = "Gallery 2",
                    Description = "Description 2",
                    IsActive = true,
                    ImageId = "ImageId2",
                    GalleriesProducts = new List<GalleryProduct>
                    {
                        new GalleryProduct { Product = new Product { Id = 3, Name = "Product 3", IsActive = true, Price = 5.99M, Description = "test" ,Images = new List<Image>{ { new Image() { Id = "img3" } },{ new Image() { Id = "img4" } } }}, Position = 1 },
                        new GalleryProduct { Product = new Product { Id = 4, Name = "Product 4", IsActive = true, Price = 8.49M, Description = "test" ,Images = new List<Image>{ { new Image() { Id = "img5" } },{ new Image() { Id = "img6" } } }}, Position = 2 }
                    }
                }
            };

            await _context.Galleries.AddRangeAsync(galleries);
            await _context.SaveChangesAsync();
        }
        [Test]
        public async Task AddAsync_ValidModel_ShouldAddGalleryToDatabase()
        {
            // Arrange
            var model = new GalleryFormViewModel
            {
                Name = "Test Gallery",
                Description = "Test Description",
                ImageId = "TestImageId"
            };

            // Act
            await _galleryService.AddAsync(model);

            // Assert
            var addedGallery = await _context.Galleries.FirstOrDefaultAsync(g => g.Name == model.Name);
            Assert.NotNull(addedGallery);
            Assert.AreEqual(model.Name, addedGallery.Name);
            Assert.AreEqual(model.Description, addedGallery.Description);
            Assert.AreEqual(model.ImageId, addedGallery.ImageId);
        }

        [Test]
        public async Task AllGalleriesAsync_ShouldReturnAllActiveGalleriesWithProducts()
        {
            // Act
            var result = await _galleryService.AllGalleriesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(2, result.Count()); // Assuming there are 2 test galleries
            Assert.IsTrue(result.All(g => g.Products.Any())); // All galleries should have at least one product
        }

        // Tests for GetGalleryByIdAsync method
        [Test]
        public async Task GetGalleryByIdAsync_ExistingId_ShouldReturnGalleryWithProducts()
        {
            // Arrange
            int existingGalleryId = 1;

            // Act
            var result = await _galleryService.GetGalleryByIdAsync(existingGalleryId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(existingGalleryId, result.Id);
            Assert.IsTrue(result.Products.Any()); // The gallery should have at least one product
        }

        [Test]
        public void GetGalleryByIdAsync_NonExistingId_ShouldThrowInvalidOperationException()
        {
            // Arrange
            int nonExistingGalleryId = 999;

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _galleryService.GetGalleryByIdAsync(nonExistingGalleryId));
        }

        [Test]
        public async Task DeleteItem_ValidProductIdAndGalleryId_ShouldRemoveProductFromGallery()
        {
            // Arrange
            int productIdToRemove = 1;
            int galleryId = 1;

            // Act
            await _galleryService.DeleteItem(productIdToRemove, galleryId);

            // Assert
            Assert.IsFalse(_context.GalleriesProducts.Any(gp => gp.ProductId == productIdToRemove && gp.GalleryId == galleryId));
        }

        [Test]
        public async Task DeleteItem_LastProductInGallery_ShouldRemoveProduct()
        {
            // Arrange
            int productIdToRemove = 1;
            int galleryId = 1;

            // Remove the first product from the gallery
            await _galleryService.DeleteItem(productIdToRemove, galleryId);

            // Act
            await _galleryService.DeleteItem(2, galleryId); // Remove the last product from the gallery

            // Assert
            Assert.IsFalse(_context.GalleriesProducts.Any(gp => gp.ProductId == productIdToRemove && gp.GalleryId == galleryId));
        }

        // Tests for MoveLeft method
        [Test]
        public async Task MoveLeft_ValidProductIdAndGalleryId_ShouldMoveProductLeft()
        {
            // Arrange
            int productIdToMove = 2;
            int galleryId = 1;

            // Act

            // Assert
            var movedProduct = await _context.GalleriesProducts.FirstOrDefaultAsync(gp => gp.ProductId == productIdToMove && gp.GalleryId == galleryId);
            var previousProduct = await _context.GalleriesProducts.FirstOrDefaultAsync(gp => gp.Position == movedProduct!.Position - 1 && gp.GalleryId == galleryId);
            await _galleryService.MoveLeft(productIdToMove, galleryId);
            Assert.NotNull(movedProduct);
            Assert.NotNull(previousProduct);
            Assert.AreEqual(movedProduct.Position, 1);
            Assert.AreEqual(previousProduct.Position, 2);
        }

        [Test]
        public async Task MoveLeft_FirstProductInGallery_ShouldNotMoveProduct()
        {
            // Arrange
            int productIdToMove = 1;
            int galleryId = 1;

            // Act
            await _galleryService.MoveLeft(productIdToMove, galleryId);

            // Assert
            var movedProduct = await _context.GalleriesProducts.FirstOrDefaultAsync(gp => gp.ProductId == productIdToMove && gp.GalleryId == galleryId);
            Assert.NotNull(movedProduct);
            Assert.AreEqual(movedProduct.Position, 1);
        }

        [Test]
        public async Task MoveRight_ValidProductIdAndGalleryId_ShouldMoveProductRight()
        {
            // Arrange
            int productIdToMove = 1;
            int galleryId = 1;

            // Act

            // Assert
            var movedProduct = await _context.GalleriesProducts.FirstOrDefaultAsync(gp => gp.ProductId == productIdToMove && gp.GalleryId == galleryId);
            var nextProduct = await _context.GalleriesProducts.FirstOrDefaultAsync(gp => gp.Position == movedProduct!.Position + 1 && gp.GalleryId == galleryId);
            await _galleryService.MoveRight(productIdToMove, galleryId);
            Assert.NotNull(movedProduct);
            Assert.NotNull(nextProduct);
            Assert.AreEqual(movedProduct.Position, 2);
            Assert.AreEqual(nextProduct.Position, 1);
        }

        [Test]
        [TestCase(1, 25)]
        [TestCase(25, 1)]
        public void MoveLeft_ThrowsIfProductOrGalleryIdIncorrect(int productId, int galleryId)
        {
            // Arrange
            Assert.ThrowsAsync<InvalidOperationException>(async ()=> await _galleryService.MoveLeft(productId, galleryId));
        }


        [Test]
        [TestCase(1, 25)]
        [TestCase(25, 1)]
        public void MoveRight_ThrowsIfProductOrGalleryIdIncorrect(int productId, int galleryId)
        {
            // Arrange
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _galleryService.MoveRight(productId, galleryId));
        }

        [Test]
        public async Task MoveRight_LastProductInGallery_ShouldNotMoveProduct()
        {
            // Arrange
            int productIdToMove = 2;
            int galleryId = 1;

            // Act
            await _galleryService.MoveRight(productIdToMove, galleryId);

            // Assert
            var movedProduct = await _context.GalleriesProducts.FirstOrDefaultAsync(gp => gp.ProductId == productIdToMove && gp.GalleryId == galleryId);
            Assert.NotNull(movedProduct);
            Assert.AreEqual(movedProduct.Position, 2);
        }

        // Tests for ProductInGallery method
        [Test]
        public async Task ProductInGallery_ExistingProductIdAndGalleryId_ShouldReturnTrue()
        {
            // Arrange
            int existingProductId = 1;
            int existingGalleryId = 1;

            // Act
            var result = await _galleryService.ProductInGallery(existingProductId, existingGalleryId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task ProductInGallery_NonExistingProductIdAndGalleryId_ShouldReturnFalse()
        {
            // Arrange
            int nonExistingProductId = 999;
            int existingGalleryId = 1;

            // Act
            var result = await _galleryService.ProductInGallery(nonExistingProductId, existingGalleryId);

            // Assert
            Assert.IsFalse(result);
        }

        // Tests for GetItemsToAddAsync method
        [Test]
        public async Task GetItemsToAddAsync_ExistingGalleryId_ShouldReturnAddToGalleryViewModel()
        {
            // Arrange
            int existingGalleryId = 1;
            var category = new Category (){ Id = 5, Name = "NewCategory", IsActive = true, ImageId = "test" };
            var subcategory = new Subcategory (){ Id = 5, Name = "NewSubcategory", IsActive = true, ImageId = "test" };
            var series = new ProductSeries (){ Id = 5, Name = "NewProductSeries", IsActive = true , DefaultName = "test", DefaultDescription = "test"};
            var product = new Product (){ IsActive = true, Id = 5, Name = "name", Description = "test" };
            category.Subcategories.Add(subcategory);
            subcategory.ProductSeries.Add(series);
            series.Products.Add(product);

            await  _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            

            // Act
            var result = await _galleryService.GetItemsToAddAsync(existingGalleryId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(existingGalleryId, result.GalleryId);
             // There should be at least one category
        }

        

        [Test]
        public void GetItemsToAddAsync_NonExistingGalleryId_ShouldThrowInvalidOperationException()
        {
            // Arrange
            int nonExistingGalleryId = 999;

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _galleryService.GetItemsToAddAsync(nonExistingGalleryId));
        }

        [Test]
        public async Task AddItemsToGalleryAsync_ExistingGalleryIdAndItems_ShouldAddItemsToGallery()
        {
            // Arrange
            int existingGalleryId = 1;
            var itemsToAdd = new List<int> { 3, 4 };

            // Act
            await _galleryService.AddItemsToGalleryAsync(existingGalleryId, itemsToAdd);

            // Assert
            var addedItems = await _context.GalleriesProducts
                .Where(gp => gp.GalleryId == existingGalleryId && itemsToAdd.Contains(gp.ProductId))
                .ToListAsync();

            Assert.AreEqual(itemsToAdd.Count, addedItems.Count);
            Assert.IsTrue(addedItems.All(gp => gp.GalleryId == existingGalleryId));
        }

        [Test]
        public void AddItemsToGalleryAsync_NonExistingGalleryId_ShouldThrowInvalidOperationException()
        {
            // Arrange
            int nonExistingGalleryId = 999;
            var itemsToAdd = new List<int> { 3, 4 };

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _galleryService.AddItemsToGalleryAsync(nonExistingGalleryId, itemsToAdd));
        }

        // Tests for GetGalleryEditFormAsync method
        [Test]
        public async Task GetGalleryEditFormAsync_ExistingGalleryId_ShouldReturnGalleryEditFormViewModel()
        {
            // Arrange
            int existingGalleryId = 1;

            // Act
            var result = await _galleryService.GetGalleryEditFormAsync(existingGalleryId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(existingGalleryId, result.Id);
        }

        [Test]
        public void GetGalleryEditFormAsync_NonExistingGalleryId_ShouldThrowInvalidOperationException()
        {
            // Arrange
            int nonExistingGalleryId = 999;

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _galleryService.GetGalleryEditFormAsync(nonExistingGalleryId));
        }

        [Test]
        public async Task EditAsync_ExistingGalleryId_ShouldEditGallery()
        {
            // Arrange
            int existingGalleryId = 1;
            var model = new GalleryEditFormViewModel
            {
                Id = existingGalleryId,
                Name = "New Gallery Name",
                Description = "New Gallery Description",
                ImageId = "new-image-id"
            };

            // Act
            await _galleryService.EditAsync(model);

            // Assert
            var editedGallery = await _context.Galleries.FirstOrDefaultAsync(g => g.Id == existingGalleryId);
            Assert.NotNull(editedGallery);
            Assert.AreEqual("New Gallery Name", editedGallery.Name);
            Assert.AreEqual("New Gallery Description", editedGallery.Description);
            Assert.AreEqual("new-image-id", editedGallery.ImageId);
        }

        // Tests for DeleteAsync method
        [Test]
        public async Task DeleteAsync_ExistingGalleryId_ShouldMarkGalleryAsInactive()
        {
            // Arrange
            int existingGalleryId = 1;

            // Act
            await _galleryService.DeleteAsync(existingGalleryId);

            // Assert
            var deletedGallery = await _context.Galleries.FirstOrDefaultAsync(g => g.Id == existingGalleryId);
            Assert.NotNull(deletedGallery);
            Assert.IsFalse(deletedGallery.IsActive);
        }

        [Test]
        public void DeleteAsync_NonExistingGalleryId_ShouldThrowInvalidOperationException()
        {
            // Arrange
            int nonExistingGalleryId = 999;

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _galleryService.DeleteAsync(nonExistingGalleryId));
        }

        // Tests for RemoveItemFromAllGalleries method
        [Test]
        public async Task RemoveItemFromAllGalleries_ExistingProductId_ShouldRemoveProductFromAllGalleries()
        {
            // Arrange
            int existingProductId = 1;

            // Act
            await _galleryService.RemoveItemFromAllGalleries(existingProductId);

            // Assert
            Assert.IsFalse(_context.GalleriesProducts.Any(gp => gp.ProductId == existingProductId));
        }

        // Tests for ExistsByIdAsync method
        [Test]
        public async Task ExistsByIdAsync_ExistingGalleryId_ShouldReturnTrue()
        {
            // Arrange
            int existingGalleryId = 1;

            // Act
            var result = await _galleryService.ExistsByIdAsync(existingGalleryId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistsByIdAsync_NonExistingGalleryId_ShouldReturnFalse()
        {
            // Arrange
            int nonExistingGalleryId = 999;

            // Act
            var result = await _galleryService.ExistsByIdAsync(nonExistingGalleryId);

            // Assert
            Assert.IsFalse(result);
        }





    }
}

