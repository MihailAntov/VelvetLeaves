using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using VelvetLeaves.Data;
using VelvetLeaves.Data.Models;
using VelvetLeaves.Services;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Product;

namespace VelvetLeaves.Tests
{
    [TestFixture]
    public class ProductServiceUnitTests
    {
        private VelvetLeavesDbContext _dbContext;
        private ProductService _productService;
        private Mock<ICategoryService> _categoryServiceMock;
        private Mock<ISubcategoryService> _subcategoryServiceMock;
        private Mock<IProductSeriesService> _productSeriesServiceMock;
        private Mock<ITagService> _tagServiceMock;
        private Mock<IMaterialService> _materialServiceMock;
        private Mock<IColorService> _colorServiceMock;
        private Mock<IImageService> _imageServiceMock;
        private Mock<IGalleryService> _galleryServiceMock;
        private Mock<ILogger<ProductService>> _loggerMock;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<VelvetLeavesDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _dbContext = new VelvetLeavesDbContext(options);
            SeedDatabase();
            

            _categoryServiceMock = new Mock<ICategoryService>();
            _subcategoryServiceMock = new Mock<ISubcategoryService>();
            _productSeriesServiceMock = new Mock<IProductSeriesService>();
            _tagServiceMock = new Mock<ITagService>();
            _materialServiceMock = new Mock<IMaterialService>();
            _colorServiceMock = new Mock<IColorService>();
            _imageServiceMock = new Mock<IImageService>();
            _galleryServiceMock = new Mock<IGalleryService>();
            _loggerMock = new Mock<ILogger<ProductService>>();

            _productService = new ProductService(
                _dbContext,
                _categoryServiceMock.Object,
                _subcategoryServiceMock.Object,
                _productSeriesServiceMock.Object,
                _tagServiceMock.Object,
                _materialServiceMock.Object,
                _colorServiceMock.Object,
                _imageServiceMock.Object,
                _galleryServiceMock.Object,
                _loggerMock.Object
            );
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Dispose();
            
        }

        // Helper method to seed the in-memory database with test data
        private void SeedDatabase()
        {
            // Add test data to the in-memory database
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

            var productSeries = new List<ProductSeries>
            {
                new ProductSeries { Id = 1, Name = "Series 1", SubcategoryId = 1, IsActive = true, DefaultName = "Series1Name", DefaultDescription = "Series1Description" },
                new ProductSeries { Id = 2, Name = "Series 2", SubcategoryId = 2, IsActive = true, DefaultName = "Series2Name", DefaultDescription = "Series2Description" },
                new ProductSeries { Id = 3, Name = "Series 3", SubcategoryId = 3, IsActive = true, DefaultName = "Series3Name", DefaultDescription = "Series3Description" }
            };

            var tags = new List<Tag>
            {
                new Tag { Id = 1, Name = "Tag 1" },
                new Tag { Id = 2, Name = "Tag 2" },
                new Tag { Id = 3, Name = "Tag 3" }
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
                new Product { Id = 1, SubcategoryId = 1, IsActive = true, Name = "Product1 Name", Description = "Product1 Description", Images = new List<Image> {new Image {Id = "p1img1" }, new Image {Id = "p1img2"} }, ProductSeriesId = 1 },
                new Product { Id = 2, SubcategoryId = 2, IsActive = true , Name = "Product2 Name", Description = "Product2 Description", Images = new List<Image> {new Image {Id = "p2img1" }, new Image {Id = "p2img2"}, new Image{Id = "p2img3" } }, ProductSeriesId = 1  },
                new Product { Id = 3, SubcategoryId = 2, IsActive = false, Name = "Product3 Name", Description = "Product3 Description", Images = new List<Image> {new Image {Id = "p3img1" }, new Image {Id = "p3img2"} }, ProductSeriesId = 2 }, // Inactive product
                new Product { Id = 4, SubcategoryId = 2, IsActive = true, Name = "Product4 Name", Description = "Product4 Description", Images = new List<Image> {new Image {Id = "p4img1" }, new Image {Id = "p4img2"} }, ProductSeriesId = 2 }, 
                new Product { Id = 5, SubcategoryId = 2, IsActive = true, Name = "Product5 Name", Description = "Product5 Description", Images = new List<Image> {new Image {Id = "p5img1" }, new Image {Id = "p5img2"} }, ProductSeriesId = 2 , Tags = new List<Tag> { new Tag { Id = 4, Name = "Tag 4" } }, Materials = new List<Material> { new Material { Id = 4, Name = "Material 4" } } },
                new Product { Id = 6, SubcategoryId = 2, IsActive = true, Name = "Product6 Name", Description = "Product6 Description", Images = new List<Image> {new Image {Id = "p6img1" }, new Image {Id = "p6img2"} }, ProductSeriesId = 2  }
            };


            _dbContext.Database.EnsureDeleted();
            _dbContext.SaveChanges();


            _dbContext.Categories.AddRange(categories);
            _dbContext.Subcategories.AddRange(subcategories);
            _dbContext.ProductSeries.AddRange(productSeries);
            _dbContext.Tags.AddRange(tags);
            _dbContext.Materials.AddRange(materials);
            _dbContext.Colors.AddRange(colors);
            _dbContext.Products.AddRange(products);
            _dbContext.SaveChanges();
        }

        [Test]
        public async Task ExistsByIdAsync_ProductExistsAndIsActive_ShouldReturnTrue()
        {
            // Arrange
            var productId = 1;

            // Act
            var result = await _productService.ExistsByIdAsync(productId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistsByIdAsync_ProductExistsButIsInactive_ShouldReturnFalse()
        {
            // Arrange
            var productId = 3; // Inactive product ID

            // Act
            var result = await _productService.ExistsByIdAsync(productId);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task ExistsByIdAsync_ProductDoesNotExist_ShouldReturnFalse()
        {
            // Arrange
            var productId = 99; // Non-existing product ID

            // Act
            var result = await _productService.ExistsByIdAsync(productId);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task DetailsByIdAsync_ValidProductId_ShouldReturnProductDetailsViewModel()
        {
            // Arrange
            var productId = 1;

            // Act
            var result = await _productService.DetailsByIdAsync(productId);

            

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(productId, result.Id);
            Assert.AreEqual("Product1 Name", result.Name);
            Assert.AreEqual("Product1 Description", result.Description);

            // Images
            Assert.NotNull(result.Images);
            Assert.AreEqual(2, result.Images.Count());
            Assert.Contains("p1img1", result.Images.ToList());
            Assert.Contains("p1img2", result.Images.ToList());

            // Materials
            Assert.NotNull(result.Materials);
            Assert.AreEqual(0, result.Materials.Count()); // No materials associated with Product 1 in the seed data.

            // Tags
            Assert.NotNull(result.Tags);
            Assert.AreEqual(0, result.Tags.Count()); // No tags associated with Product 1 in the seed data.

            // ProductSeries
            Assert.NotNull(result.ProductSeries);
            Assert.AreEqual(1, result.ProductSeries.Count()); 
        }

        [Test]
        public async Task DetailsByIdAsync_ValidProductId_ShouldReturnCorrectProductSeriesTagsAndmaterials()
        {
            // Arrange
            var productId = 5;

            // Act
            var result = await _productService.DetailsByIdAsync(productId);



            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(productId, result.Id);
            Assert.AreEqual("Product5 Name", result.Name);
            Assert.AreEqual("Product5 Description", result.Description);

            // Images
            Assert.NotNull(result.Images);
            Assert.AreEqual(2, result.Images.Count());
            Assert.Contains("p5img1", result.Images.ToList());
            Assert.Contains("p5img2", result.Images.ToList());

            // Materials
            Assert.NotNull(result.Materials);
            Assert.AreEqual(1, result.Materials.Count()); 

            // Tags
            Assert.NotNull(result.Tags);
            Assert.AreEqual(1, result.Tags.Count()); 

            // ProductSeries
            Assert.NotNull(result.ProductSeries);
            Assert.AreEqual(2, result.ProductSeries.Count());
        }

        [Test]
        public async Task DetailsByIdAsync_InactiveProductId_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var productId = 3; // Inactive product ID in the seed data

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _productService.DetailsByIdAsync(productId));
        }

        [Test]
        public async Task DetailsByIdAsync_InvalidProductId_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var productId = 99; // Non-existing product ID

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _productService.DetailsByIdAsync(productId));
        }

        [Test]
        public async Task ProductsFilteredAndPagedAsync_NoFilters_ShouldReturnAllActiveProducts()
        {
            // Arrange

            var model = new ProductsQueryModel
            {
                CurrentPage = 1,
                ProductsPerPage = 10 // Assuming 10 products per page for testing purposes
            };

            // Act
            var result = await _productService.ProductsFilteredAndPagedAsync(model);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.TotalProductCount); // There are 5 active products in the seed data
            Assert.AreEqual(5, result.Products.Count()); // All active products should be returned
        }

        [Test]
        public async Task ProductsFilteredAndPagedAsync_FilterByCategory_ShouldReturnFilteredProducts()
        {
            // Arrange

            var model = new ProductsQueryModel
            {
                CurrentPage = 1,
                ProductsPerPage = 10, // Assuming 10 products per page for testing purposes
                CategoryId = 2 // Filter by Category ID 2 (Category 2)
            };

            // Act
            var result = await _productService.ProductsFilteredAndPagedAsync(model);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.TotalProductCount); // Only 1 product belongs to Category 2
            Assert.AreEqual(4, result.Products.Count()); // The filtered product should be returned
            Assert.AreEqual("Product2 Name", result.Products.First().Name); // Verify the product name
        }

        [Test]
        public async Task ProductsFilteredAndPagedAsync_SearchByName_ShouldReturnFilteredProducts()
        {
            // Arrange

            var model = new ProductsQueryModel
            {
                CurrentPage = 1,
                ProductsPerPage = 10, // Assuming 10 products per page for testing purposes
                SearchString = "Product4" // Search for products containing "Product4" in their name
            };

            // Act
            var result = await _productService.ProductsFilteredAndPagedAsync(model);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.TotalProductCount); // Only 1 product matches the search criteria
            Assert.AreEqual(1, result.Products.Count()); // The filtered product should be returned
            Assert.AreEqual("Product4 Name", result.Products.First().Name); // Verify the product name
        }

        [Test]
        public async Task ProductsFilteredAndPagedAsync_Paging_ShouldReturnCorrectPage()
        {
            // Arrange

            var model = new ProductsQueryModel
            {
                CurrentPage = 2, // Get the second page
                ProductsPerPage = 2 // Assuming 2 products per page for testing purposes
            };

            // Act
            var result = await _productService.ProductsFilteredAndPagedAsync(model);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.TotalProductCount); // There are 5 active products in the seed data
            Assert.AreEqual(2, result.Products.Count()); // The second page should have 2 products
            Assert.AreEqual("Product4 Name", result.Products.First().Name); // Verify the first product on the second page
        }
    }
}