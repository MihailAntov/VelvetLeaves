using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using VelvetLeaves.Data;
using VelvetLeaves.Data.Models;
using VelvetLeaves.Service.Models.ShoppingCart;
using VelvetLeaves.Services;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Category;
using VelvetLeaves.ViewModels.Product;
using VelvetLeaves.ViewModels.ProductSeries;
using VelvetLeaves.ViewModels.Subcategory;

namespace VelvetLeaves.Services.UnitTests
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


            _imageServiceMock.Setup(i => i.RemoveAsync(It.IsAny<string>())).Verifiable();
            _imageServiceMock.Setup(i => i.CreateAsync(It.IsAny<IFormFile>())).ReturnsAsync("newImgId");
            _imageServiceMock.Setup(i => i.CreateRangeAsync(It.IsAny<ICollection<IFormFile>>())).ReturnsAsync(new List<string> {"newImgId" });
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
        public void DetailsByIdAsync_InactiveProductId_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var productId = 3; // Inactive product ID in the seed data

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _productService.DetailsByIdAsync(productId));
        }

        [Test]
        public void DetailsByIdAsync_InvalidProductId_ShouldThrowInvalidOperationException()
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
            Assert.AreEqual(3, result.TotalProductCount); 
            Assert.AreEqual(3, result.Products.Count()); // The filtered product should be returned
            Assert.AreEqual("Product4 Name", result.Products.First().Name); // Verify the product name
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

        [Test]
        public async Task ProductsFilteredAndPagedAsync_Paging_ReturnsCorrectItemsWithSubcategory()
        {
            // Arrange

            var model = new ProductsQueryModel
            {
                SubCategoryId = 2,

            };

            // Act
            var result = await _productService.ProductsFilteredAndPagedAsync(model);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.TotalProductCount); 
            Assert.AreEqual(3, result.Products.Count()); 
            Assert.AreEqual("Product4 Name", result.Products.First().Name); // Verify the first product on the second page
        }

        [Test]
        public async Task ProductsFilteredAndPagedAsync_Paging_ReturnsNoItemsWithMaterialsWhenNoProductInDbHasThem()
        {
            // Arrange

            var model = new ProductsQueryModel
            {
                Materials = new List<int> { 1 } 

            };

            // Act
            var result = await _productService.ProductsFilteredAndPagedAsync(model);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.TotalProductCount); 
            Assert.AreEqual(0, result.Products.Count()); 
        }

        [Test]
        public async Task ProductsFilteredAndPagedAsync_Paging_ReturnsCorrectItemsWithMaterial()
        {
            // Arrange

            var model = new ProductsQueryModel
            {
                Materials = new List<int> { 4 }

            };

            // Act
            var result = await _productService.ProductsFilteredAndPagedAsync(model);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.TotalProductCount); // There are 5 active products in the seed data
            Assert.AreEqual(1, result.Products.Count()); // The second page should have 2 products
            Assert.AreEqual("Product5 Name", result.Products.First().Name); // Verify the first product on the second page
        }

        [Test]
        public async Task ProductsFilteredAndPagedAsync_Paging_ReturnsNoItemsWithTagWhenNoProductInDbHasThem()
        {
            // Arrange

            var model = new ProductsQueryModel
            {
                Tags = new List<string> { "Tag 1" }

            };

            // Act
            var result = await _productService.ProductsFilteredAndPagedAsync(model);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.TotalProductCount);
            Assert.AreEqual(0, result.Products.Count());
        }

        [Test]
        public async Task ProductsFilteredAndPagedAsync_Paging_ReturnsCorrectItemsWithTag()
        {
            // Arrange

            var model = new ProductsQueryModel
            {
                Tags = new List<string> { "Tag 4" }

            };

            // Act
            var result = await _productService.ProductsFilteredAndPagedAsync(model);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.TotalProductCount); // There are 5 active products in the seed data
            Assert.AreEqual(1, result.Products.Count()); // The second page should have 2 products
            Assert.AreEqual("Product5 Name", result.Products.First().Name); // Verify the first product on the second page
        }

        [Test]
        public async Task ProductsFilteredAndPagedAsync_Paging_ReturnsNoItemsWithColorWhenNoProductInDbHasThem()
        {
            // Arrange

            var model = new ProductsQueryModel
            {
                ColorIds = new List<int> { 5 }

            };

            // Act
            var result = await _productService.ProductsFilteredAndPagedAsync(model);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.TotalProductCount);
            Assert.AreEqual(0, result.Products.Count());
        }

        [Test]
        public async Task ProductsFilteredAndPagedAsync_Paging_ReturnsCorrectItemsWithColor()
        {
            // Arrange

            var model = new ProductsQueryModel
            {
                ColorIds= new List<int> { 1,2 }

            };

            // Act
            var result = await _productService.ProductsFilteredAndPagedAsync(model);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.TotalProductCount); // There are 5 active products in the seed data
            Assert.AreEqual(2, result.Products.Count()); // The second page should have 2 products
            Assert.AreEqual("Product1 Name", result.Products.First().Name); // Verify the first product on the second page
        }


        [Test]
        public async Task GetProductTreeAsync_Should_Return_ProductTreeViewModel()
        {
            // Arrange
            var categoryId = 2; // Set your desired categoryId here for testing
            var subcategoryId = 2; // Set your desired subcategoryId here for testing
            var productSeriesId = 2; // Set your desired productSeriesId here for testing

            // Act
            var result = await _productService.GetProductTreeAsync(categoryId, subcategoryId, productSeriesId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(categoryId, result.CategoryId);
            Assert.AreEqual(subcategoryId, result.SubcategoryId);
            Assert.AreEqual(productSeriesId, result.ProductSeriesId);

            // Assert that Categories and Subcategories are not null and contain items
            Assert.IsNotNull(result.Products);
            Assert.IsNotEmpty(result.Products);
            Assert.IsNotNull(result.Products.First().Subcategories);
            Assert.IsNotEmpty(result.Products.First().Subcategories);
            Assert.IsNotEmpty(result.Products.First().Subcategories.First().ProductSeries);
            Assert.IsNotEmpty(result.Products.First().Subcategories.First().ProductSeries.First().Products);
            Assert.IsNotNull(result.Products.First().Subcategories.First().ProductSeries.First().Products.First());

            // Add more assertions to validate the structure and data of the ProductTreeViewModel
        }

        [Test]
        public async Task GetProductTreeAsync_Should_Return_AllProductsEvenWithoutMatch()
        {
            // Arrange
            var categoryId = 999; // Use a categoryId that does not exist in the test data
            var subcategoryId = 999; // Use a subcategoryId that does not exist in the test data
            var productSeriesId = 999; // Use a productSeriesId that does not exist in the test data

            // Act
            var result = await _productService.GetProductTreeAsync(categoryId, subcategoryId, productSeriesId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(categoryId, result.CategoryId); // CategoryId should match the input even if no match is found
            Assert.AreEqual(subcategoryId, result.SubcategoryId); // SubcategoryId should match the input even if no match is found
            Assert.AreEqual(productSeriesId, result.ProductSeriesId); // ProductSeriesId should match the input even if no match is found

            // Assert that Categories and Subcategories are empty
            Assert.IsNotNull(result.Products);
            Assert.AreEqual(result.Products.Count(), _dbContext.Categories.Count());
        }

        [Test]
        public async Task GetProductTreeAsync_Should_Return_AllProductsAndNotSetNavigationMarkers()
        {
            // Arrange
            int? categoryId = null; // Use a categoryId that does not exist in the test data
            int? subcategoryId = null; // Use a subcategoryId that does not exist in the test data
            int? productSeriesId = null; // Use a productSeriesId that does not exist in the test data

            // Act
            var result = await _productService.GetProductTreeAsync(categoryId, subcategoryId, productSeriesId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.CategoryId); // CategoryId should match the input even if no match is found
            Assert.IsNull(result.SubcategoryId); // SubcategoryId should match the input even if no match is found
            Assert.IsNull( result.ProductSeriesId); // ProductSeriesId should match the input even if no match is found

            // Assert that Categories and Subcategories are empty
            Assert.IsNotNull(result.Products);
            Assert.AreEqual(result.Products.Count(), _dbContext.Categories.Count());
        }

        [Test]
        public async Task AddAsync_Should_Add_Product_To_DbContext()
        {
            // Arrange
            var model = new ProductFormViewModel
            {
                Name = "Test Product",
                CategoryId = 1,
                SubcategoryId = 1,
                ProductSeriesId = 1,
                Description = "Test Description",
                Price = 99.99m,
                ImageIds = new List<string> { "img1", "img2" },
                ColorIds = new List<int> { 3 },
                MaterialIds = new List<int> { 1, 2, 3 },
                TagIds = new List<int> { 1, 2 }
            };

            // Act
            await _productService.AddAsync(model);

            // Assert
            var result = _dbContext.Products.First(p => p.Name == "Test Product");
            
            Assert.AreEqual(result.Description, model.Description);
            Assert.AreEqual(result.Price, model.Price);
            Assert.AreEqual(result.ProductSeriesId, model.ProductSeriesId);
            Assert.IsTrue(result.Images.Count == 2);
            Assert.AreEqual(result.Images.First().Id, "img1");
            Assert.IsTrue(result.Tags.Count == 2);
            Assert.AreEqual(result.Tags.First().Id, 1);
            Assert.IsTrue(result.Materials.Count == 3);
            Assert.AreEqual(result.Materials.First().Id, 1);
            Assert.IsTrue(result.Colors.Count == 1);
            Assert.AreEqual(result.Colors.First().Id, 3);
            

            
        }

        [Test]
        public async Task AddAsync_Should_Add_Product_With_No_Images_Colors_Materials_Tags()
        {
            // Arrange
            var model = new ProductFormViewModel
            {
                Name = "Test Product",
                SubcategoryId = 1,
                CategoryId = 1,
                ProductSeriesId = 1,
                Description = "Test Description",
                Price = 99.99m,
                ImageIds = new List<string> { "img2" }
                // Leave ImageIds, ColorIds, MaterialIds, and TagIds empty
            };

            // Act
            await _productService.AddAsync(model);

            // Assert

            var result = _dbContext.Products.First(p => p.Name == "Test Product");

            Assert.AreEqual(result.Description, model.Description);
            Assert.AreEqual(result.Price, model.Price);
            Assert.AreEqual(result.ProductSeriesId, model.ProductSeriesId);
            Assert.IsTrue(result.Images.Count == 1);
            Assert.AreEqual(result.Images.First().Id, "img2");
            Assert.IsTrue(result.Tags.Count == 0);
            Assert.IsTrue(result.Materials.Count == 0);
            Assert.IsTrue(result.Colors.Count == 0);
        }

        [Test]
        [TestCase(1,1,999)]
        [TestCase(1,999,1)]
        [TestCase(999,1,1)]
        public void AddAsync_Should_Throw_Exception_When_Subcategory_Or_ProductSeries_Does_Not_Exist(int category, int subcategory, int series)
        {
            // Arrange
            var model = new ProductFormViewModel
            {
                Name = "Test Product",
                SubcategoryId = subcategory, // Use a subcategoryId that does not exist in the test data
                CategoryId = category,
                ProductSeriesId = series, // Use a productSeriesId that does not exist in the test data
                Description = "Test Description",
                Price = 99.99m,
                ImageIds = new List<string> { "img1", "img2" },
                ColorIds = new List<int> { 3 },
                MaterialIds = new List<int> { 1, 2, 3 },
                TagIds = new List<int> { 1, 2 }
            };

            // Act and Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _productService.AddAsync(model));
            // Add more assertions if needed to verify that no product was added in the database.
        }


        [Test]
        [TestCase(null, null, null)]
        [TestCase("Series1Name", "Series1Description", 9.99)]
        public async Task GetFormForAddAsync_Should_Initialize_ProductFormViewModel_With_Default_Values(string defaultName, string defaultDescription, decimal? defaultPrice)
        {
            // Arrange
            int categoryId = 1; // Sample categoryId
            int subcategoryId = 1; // Sample subcategoryId
            int productSeriesId = 1; // Sample productSeriesId

            // Setup the mock CategoryService to return some categories
            var categories = await _dbContext.Categories
                .Select(c => new CategorySelectViewModel { Id = c.Id, Name = c.Name })
                .ToListAsync();
            _categoryServiceMock.Setup(s => s.AllCategoriesAsync()).ReturnsAsync(categories);

            // Setup the mock SubcategoryService to return subcategories for the given categoryId
            var subcategories = await _dbContext.Subcategories
                .Where(sc => sc.CategoryId == categoryId)
                .Select(sc => new SubcategorySelectViewModel { Id = sc.Id, Name = sc.Name })
                .ToListAsync();
            _subcategoryServiceMock.Setup(s => s.SubcategoriesByCategoryIdAsync(categoryId)).ReturnsAsync(subcategories);

            // Setup the mock ProductSeriesService to return product series for the given subcategoryId
            var productSeries = await _dbContext.ProductSeries
                .Where(ps => ps.SubcategoryId == subcategoryId)
                .Select(ps => new ProductSeriesSelectViewModel { Id = ps.Id, Name = ps.Name })
                .ToListAsync();
            _productSeriesServiceMock.Setup(s => s.ProductSeriesBySubcategoryIdAsync(subcategoryId)).ReturnsAsync(productSeries);
            _productSeriesServiceMock.Setup(s => s.GetDefaultValues(productSeriesId)).ReturnsAsync(new ProductSeriesDefaultValues()
            {
                Name = defaultName,
                Description = defaultDescription,
                Price = defaultPrice,
                
                TagIds = new List<int> { 1 },
                ColorIds = new List<int>(),
                MaterialIds = new List<int>()
            });




            // Act
            var result = await _productService.GetFormForAddAsync(categoryId, subcategoryId, productSeriesId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(categoryId, result.CategoryId);
            Assert.AreEqual(subcategoryId, result.SubcategoryId);
            Assert.AreEqual(productSeriesId, result.ProductSeriesId);

            // Add more assertions to validate the content of the ProductFormViewModel with the default values.
            Assert.IsNotNull(result.ProductSeriesOptions);
            Assert.IsNotNull(result.DefaultTagIds);
            Assert.IsNotNull(result.DefaultColorIds);
            Assert.IsNotNull(result.DefaultMaterialIds);
            Assert.IsNotNull(result.Name);
            Assert.AreEqual(defaultName ?? string.Empty, result.Name);
            //Assert.AreEqual(defaultValues?.Price ?? 0.00M, result.Price);
            Assert.AreEqual(defaultDescription ?? string.Empty, result.Description);
            Assert.AreEqual(defaultPrice ?? 0.00m, result.Price);
        }


        [Test]
        public async Task GetFormForEditAsync_Should_Return_ProductEditFormViewModel_When_Product_Exists_And_IsActive()
        {
            // Arrange
            int productId = 1; // Sample productId

            //new Product { Id = 1, SubcategoryId = 1, IsActive = true, Name = "Product1 Name", Description = "Product1 Description", Images = new List<Image> { new Image { Id = "p1img1" }, new Image { Id = "p1img2" } }, ProductSeriesId = 1, Colors = new List<Color> { colors[0], colors[1] } },


            // Act
            var result = await _productService.GetFormForEditAsync(productId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(productId, result.Id);
            Assert.AreEqual(1, result.SubcategoryId);
            Assert.AreEqual(1, result.ProductSeriesId);
            Assert.AreEqual("Product1 Name", result.Name);
            CollectionAssert.AreEqual(new List<int> {1,2 }, result.ColorIds);
            CollectionAssert.AreEqual(new List<int>(), result.TagIds);
            CollectionAssert.AreEqual(new List<int>(), result.MaterialIds);
            Assert.AreEqual("Product1 Description", result.Description);
            CollectionAssert.AreEqual(new List<string> {"p1img1","p1img2" }, result.ImageIds);
            Assert.AreEqual(10.00M, result.Price);
        }

        [Test]
        public void GetFormForEditAsync_Should_Throw_ArgumentException_When_Product_Does_Not_Exist()
        {
            // Arrange
            int nonExistentProductId = 999; // Non-existent productId

            // Setup the mock ProductService to return an empty list (no products)

            // Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await _productService.GetFormForEditAsync(nonExistentProductId));
        }

        [Test]
        public async Task UpdateAsync_Should_Update_Product_In_Database_With_Given_Model()
        {
            // Arrange
            int productId = 2; // Sample productId
            var model = new ProductEditFormViewModel
            {
                Id = productId,
                Name = "Updated Product Name",
                SubcategoryId = 2,
                ProductSeriesId = 1,
                Description = "Updated Product Description",
                Price = 150.00M,
                ColorIds = new List<int> { 1 },
                TagIds = new List<int> { 1, 2 },
                MaterialIds = new List<int> { 2 },
                StartingImageIds = new List<string> { "p2img1", "p2img2", "p2img3" },
                Images = new List<IFormFile> { new Mock<IFormFile>().Object },
                KeptImageIds = new List<string> { "p2img1" },

            };

            //new Product { Id = 2, SubcategoryId = 1, IsActive = true, Name = "Product2 Name", Description = "Product2 Description", Images = new List<Image> { new Image { Id = "p2img1" }, new Image { Id = "p2img2" }, new Image { Id = "p2img3" } }, ProductSeriesId = 1, Colors = new List<Color> { colors[0], colors[1] }, Price = 10.00M },
            
            // Act
            await _productService.UpdateAsync(model);

            var product = await _dbContext.Products.FirstAsync(p => p.Id == productId);

            // Assert
            // Verify that the product in the database has been updated with the values from the model
            Assert.AreEqual(product.Name, "Updated Product Name");
            Assert.AreEqual(product.SubcategoryId, 1);
            Assert.That(1, Is.EqualTo(product.ProductSeriesId));
            Assert.That("Updated Product Description", Is.EqualTo(product.Description));
            Assert.AreEqual(product.Price, 150.00M);
            Assert.AreEqual(product.Colors.First().Id, 1);
            Assert.AreEqual(product.Colors.Count, 1);
            Assert.AreEqual(product.Tags.First().Id, 1);
            Assert.AreEqual(product.Tags.Count, 2);
            Assert.AreEqual(product.Materials.First().Id, 2);
            Assert.AreEqual(product.Materials.Count, 1);
            Assert.AreEqual(product.Images.First().Id, "p2img1");
            Assert.AreEqual(product.Images.Count, 2);



        }

        [Test]
        public async Task UpdateAsync_Should_Update_Images_In_Database_With_Given_Model()
        {
            // Arrange
            int productId = 2; // Sample productId
            var model = new ProductEditFormViewModel
            {
                Id = productId,
                Name = "Updated Product Name",
                SubcategoryId = 2,
                ProductSeriesId = 1,
                Description = "Updated Product Description",
                Price = 150.00M,
                ColorIds = new List<int> { 1 },
                TagIds = new List<int> { 1, 2 },
                MaterialIds = new List<int> { 2 },
                StartingImageIds = new List<string> { "p2img1", "p2img2", "p2img3" },
                Images = new List<IFormFile> { new Mock<IFormFile>().Object },
                

            };

            //new Product { Id = 2, SubcategoryId = 1, IsActive = true, Name = "Product2 Name", Description = "Product2 Description", Images = new List<Image> { new Image { Id = "p2img1" }, new Image { Id = "p2img2" }, new Image { Id = "p2img3" } }, ProductSeriesId = 1, Colors = new List<Color> { colors[0], colors[1] }, Price = 10.00M },

            // Act
            await _productService.UpdateAsync(model);

            var product = await _dbContext.Products.FirstAsync(p => p.Id == productId);

            // Assert
            // Verify that the product in the database has been updated with the values from the model
            Assert.AreEqual(product.Name, "Updated Product Name");
            Assert.AreEqual(product.SubcategoryId, 1);
            Assert.That(1, Is.EqualTo(product.ProductSeriesId));
            Assert.That("Updated Product Description", Is.EqualTo(product.Description));
            Assert.AreEqual(product.Price, 150.00M);
            Assert.AreEqual(product.Colors.First().Id, 1);
            Assert.AreEqual(product.Colors.Count, 1);
            Assert.AreEqual(product.Tags.First().Id, 1);
            Assert.AreEqual(product.Tags.Count, 2);
            Assert.AreEqual(product.Materials.First().Id, 2);
            Assert.AreEqual(product.Materials.Count, 1);
            Assert.AreEqual(product.Images.First().Id, "newImgId");
            Assert.AreEqual(product.Images.Count, 1);



        }

        [Test]
        public void UpdateAsync_Should_Throw_ArgumentException_When_Product_Does_Not_Exist()
        {
            // Arrange
            int nonExistentProductId = 999; // Non-existent productId
            var model = new ProductEditFormViewModel { Id = nonExistentProductId, /* other properties */ };

            

            // Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _productService.UpdateAsync(model));
        }

        [Test]
        public async Task DeleteAsync_Should_Set_Product_IsActive_To_False_And_Remove_From_Gallery()
        {
            // Arrange

            // Setup the mock ProductService to return a product for the given productId

            int productId = 1;

            // Act
            await _productService.DeleteAsync(productId);

            // Assert
            // Verify that the product's IsActive property has been set to false
            var product = _dbContext.Products.First(p => p.Id == productId);
            Assert.IsFalse(product.IsActive);

            // Verify that the product has been removed from the gallery
            _galleryServiceMock.Verify(gs => gs.RemoveItemFromAllGalleries(productId), Times.Once());
        }

        [Test]
        public void DeleteAsync_Should_Throw_ArgumentException_When_Product_Does_Not_Exist()
        {
            // Arrange
            int nonExistentProductId = 999; // Non-existent productId

            // Setup the mock ProductService to return an empty list (no products)
            

            // Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await _productService.DeleteAsync(nonExistentProductId));
        }

        [Test]
        public async Task GetProductsForCart_Should_Return_Products_With_Correct_Dtos()
        {
            // Arrange
            var productIds = new[] { 1, 2, 3 }; // Sample productIds

            // Setup the mock ProductService to return some products for the given productIds
            

            // Act
            var result = await _productService.GetProductsForCart(productIds);

            // Assert
            // Verify that the correct DTOs are returned, only for active products
            Assert.AreEqual(result.Count(), 2);
            Assert.AreEqual(result.First().Name, "Product1 Name");
            Assert.AreEqual(result.First().ImageId, "p1img1");
            Assert.AreEqual(result.First().Price, 10.00M);

        }

        
    }
}









