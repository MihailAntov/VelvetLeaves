using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelvetLeaves.Data;
using VelvetLeaves.Data.Models;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Category;
using VelvetLeaves.ViewModels.Colors;
using VelvetLeaves.ViewModels.Material;
using VelvetLeaves.ViewModels.ProductSeries;
using VelvetLeaves.ViewModels.Subcategory;
using VelvetLeaves.ViewModels.Tag;

namespace VelvetLeaves.Services.UnitTests
{
    [TestFixture]
    public class ProductSeriesServiceUnitTests
    {
        private DbContextOptions<VelvetLeavesDbContext> _options;
        private Mock<ICategoryService> _mockCategoryService;
        private Mock<ISubcategoryService> _mockSubcategoryService;
        private Mock<ITagService> _mockTagService;
        private Mock<IMaterialService> _mockMaterialService;
        private Mock<IColorService> _mockColorService;
        private Mock<IGalleryService> _mockGalleryService;
        private ProductSeriesService _productSeriesService;
        private VelvetLeavesDbContext _context;

        [SetUp]
        public async Task Setup()
        {

            var options = new DbContextOptionsBuilder<VelvetLeavesDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new VelvetLeavesDbContext(options);
            await SeedDatabase();


            _mockCategoryService = new Mock<ICategoryService>();
            _mockSubcategoryService = new Mock<ISubcategoryService>();
            _mockTagService = new Mock<ITagService>();
            _mockMaterialService = new Mock<IMaterialService>();
            _mockColorService = new Mock<IColorService>();
            _mockGalleryService = new Mock<IGalleryService>();
            _options = new DbContextOptionsBuilder<VelvetLeavesDbContext>()
                .Options;

            _mockCategoryService = new Mock<ICategoryService>();
            _mockSubcategoryService = new Mock<ISubcategoryService>();
            // Initialize other mocks

            


            _productSeriesService = new ProductSeriesService(
                    _context,
                    _mockCategoryService.Object,
                    _mockSubcategoryService.Object,
                    _mockTagService.Object,
                    _mockMaterialService.Object,
                    _mockColorService.Object,
                    _mockGalleryService.Object
                // Initialize other mock services
                );

            
        }

        private async Task SeedDatabase()
        {
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Category 1", ImageId = "category1img" },
                new Category { Id = 2, Name = "Category 2",  ImageId = "category2img" },
            };
            _context.Categories.AddRange(categories);
            await _context.SaveChangesAsync();

            var subcategories = new List<Subcategory>
            {
                new Subcategory { Id = 1, CategoryId = 1, Name = "Subcategory 1" ,  ImageId = "subcategory1img"},
                new Subcategory { Id = 2, CategoryId = 2, Name = "Subcategory 2",  ImageId = "subcategory1img" },
             };
            _context.Subcategories.AddRange(subcategories);
            await _context.SaveChangesAsync();

            var tags = new List<Tag>
            {
                new Tag {Id = 4, Name = "Tag 4"},
                new Tag {Id = 3, Name = "Tag 3"},
                new Tag {Id = 2, Name = "Tag 2"},
                new Tag {Id = 1, Name = "Tag 1"},

            };
            _context.Tags.AddRange(tags);
            await _context.SaveChangesAsync();

            var materials = new List<Material>
            {
                new Material {Id = 4, Name = "Material 4"},
                new Material {Id = 3, Name = "Material 3"},
                new Material {Id = 2, Name = "Material 2"},
                new Material {Id = 1, Name = "Material 1"},

            };
            _context.Materials.AddRange(materials);
            await _context.SaveChangesAsync();

            var colors = new List<Color>
            {
                new Color {Id = 4,ColorValue ="Value 4", Name = "Color 4"},
                new Color {Id = 3,ColorValue ="Value 3", Name = "Color 3"},
                new Color {Id = 2,ColorValue ="Value 2", Name = "Color 2"},
                new Color {Id = 1,ColorValue ="Value 1", Name = "Color 1"},

            };
            _context.Colors.AddRange(colors);
            await _context.SaveChangesAsync();

            var productSeries = new List<ProductSeries>
            {
            new ProductSeries
            {
                Id = 1,
                Name = "Product Series 1",
                DefaultName = "Default Name 1",
                DefaultDescription = "Default Description 1",
                DefaultPrice = 100,
                SubcategoryId = 1,
                DefaultColors = new List<Color>{_context.Colors.Find(1)!, _context.Colors.Find(2)!},
                DefaultMaterials = new List<Material>{_context.Materials.Find(1)!, _context.Materials.Find(2)!},
                DefaultTags = new List<Tag>{_context.Tags.Find(1)!, _context.Tags.Find(2)!}
            },
            new ProductSeries
            {
                Id = 2,
                Name = "Product Series 2",
                DefaultName = "Default Name 2",
                DefaultDescription = "Default Description 2",
                DefaultPrice = 150,
                SubcategoryId = 2,
                DefaultColors = new List<Color>{_context.Colors.Find(3)!, _context.Colors.Find(4)!},
                DefaultMaterials = new List<Material>{_context.Materials.Find(3)!, _context.Materials.Find(4)!},
                DefaultTags = new List<Tag>{_context.Tags.Find(3)!, _context.Tags.Find(4)!}
            },
            // Add more product series as needed
        };
            _context.ProductSeries.AddRange(productSeries);
            await _context.SaveChangesAsync();
        }

        [Test]
        public async Task AddAsync_ShouldAddProductSeriesToDatabase()
        {
            // Arrange
            var model = new ProductSeriesFormViewModel
            {
                Name = "Test Product Series",
                DefaultName = "Test Default Name",
                DefaultDescription = "Test Default Description",
                DefaultPrice = 200,
                SubcategoryId = 1,
                DefaultColorIds = new List<int> { 1, 3 },
                DefaultMaterialIds = new List<int> { 1, 3 },
                DefaultTagIds = new List<int> { 1, 3 }
            };

            // Act
            await _productSeriesService.AddAsync(model);

            // Assert
            var productSeries = await _context.ProductSeries.SingleOrDefaultAsync(ps => ps.Name == "Test Product Series");
            Assert.NotNull(productSeries);
            Assert.AreEqual(model.Name, productSeries.Name);
            Assert.AreEqual(model.DefaultName, productSeries.DefaultName);
            Assert.AreEqual(model.DefaultDescription, productSeries.DefaultDescription);
            Assert.AreEqual(model.DefaultPrice, productSeries.DefaultPrice);
            Assert.AreEqual(model.SubcategoryId, productSeries.SubcategoryId);

            // Assert Collections
            Assert.AreEqual(2, productSeries.DefaultColors.Count());
            Assert.Contains(_context.Colors.Find(1), productSeries.DefaultColors.ToList());
            Assert.Contains(_context.Colors.Find(3), productSeries.DefaultColors.ToList());
            Assert.Contains(_context.Materials.Find(1), productSeries.DefaultMaterials.ToList());
            Assert.Contains(_context.Materials.Find(3), productSeries.DefaultMaterials.ToList());
            Assert.Contains(_context.Tags.Find(1), productSeries.DefaultTags.ToList());
            Assert.Contains(_context.Tags.Find(3), productSeries.DefaultTags.ToList());

            // Add more assertions for DefaultMaterials and DefaultTags
        }

        [Test]
        public async Task GetDefaultValues_ShouldReturnProductSeriesDefaultValues()
        {
            // Arrange
            // Assume you have a ProductSeries with Id = 1 in the seeded data

            // Act
            var result = await _productSeriesService.GetDefaultValues(2);

            // Assert
            Assert.NotNull(result);
            // Assert properties of the returned ProductSeriesDefaultValues
            Assert.AreEqual(2, result.ColorIds.Count());
            Assert.Contains(3, result.ColorIds.ToList());
            Assert.Contains(4, result.ColorIds.ToList());
            Assert.AreEqual(2, result.MaterialIds.Count());
            Assert.Contains(3, result.MaterialIds.ToList());
            Assert.Contains(4, result.MaterialIds.ToList());
            Assert.AreEqual(2, result.TagIds.Count());
            Assert.Contains(3, result.TagIds.ToList());
            Assert.Contains(4, result.TagIds.ToList());
        }

        [Test]
        public async Task GetDefaultValues_ShouldThrowIfNonExistenId()
        {
            // Arrange
            // Assume you have a ProductSeries with Id = 1 in the seeded data
            

            // Act
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _productSeriesService.GetDefaultValues(999));

        }

        [Test]
        public async Task ProductSeriesBySubcategoryIdAsync_ShouldReturnListOfProductSeries()
        {
            // Arrange
            // Assume you have subcategory with Id = 1 in the seeded data
            _mockSubcategoryService.Setup(sc => sc.ExistsByIdAsync(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var result = await _productSeriesService.ProductSeriesBySubcategoryIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(1, result.Count());
            var productSeries = result.First();
            Assert.AreEqual(1, productSeries.Id);
            Assert.AreEqual("Product Series 1", productSeries.Name);
        }

        [Test]
        public async Task ProductSeriesBySubcategoryIdAsync_ShouldThrowIfNonExistentId()
        {
            // Arrange
            // Assume you have subcategory with Id = 1 in the seeded data
            _mockSubcategoryService.Setup(sc => sc.ExistsByIdAsync(It.IsAny<int>())).ReturnsAsync(false);

            // Act

            // Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _productSeriesService.ProductSeriesBySubcategoryIdAsync(1));

        }

        [Test]
        public async Task GetProductSeriesByIdAsync_ShouldReturnProductSeriesFormViewModel()
        {
            // Arrange
            // Assume you have a ProductSeries with Id = 1 in the seeded data

            // Act
            var result = await _productSeriesService.GetProductSeriesByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            // Assert properties of the returned ProductSeriesFormViewModel
            Assert.AreEqual(1, result.SubcategoryId);
            Assert.AreEqual("Product Series 1", result.Name);
            Assert.AreEqual("Default Name 1", result.DefaultName);
            Assert.AreEqual("Default Description 1", result.DefaultDescription);
            Assert.AreEqual(100, result.DefaultPrice);
            Assert.AreEqual(2, result.DefaultColorIds.Count());
            Assert.Contains(1, result.DefaultColorIds.ToList());
            Assert.Contains(2, result.DefaultColorIds.ToList());

            // Add more assertions for DefaultMaterialIds, DefaultTagIds, and options collections
        }

        [Test]
        public async Task GetProductSeriesByIdAsync_ShouldThrowIfNonExistendId()
        {
           

            // Act
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _productSeriesService.GetProductSeriesByIdAsync(999));
            

        }

        [Test]
        public async Task GetDefaultProductSeriesIdAsync_ShouldReturnDefaultProductSeriesId()
        {
            // Arrange
            // Assume you have a subcategory with Id = 1 in the seeded data
            _mockSubcategoryService.Setup(sc => sc.ExistsByIdAsync(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var result = await _productSeriesService.GetDefaultProductSeriesIdAsync(1);

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public async Task GetDefaultProductSeriesIdAsync_ShouldThrowIfNonExistentId()
        {
            // Arrange
            // Assume you have a subcategory with Id = 1 in the seeded data
            _mockSubcategoryService.Setup(sc => sc.ExistsByIdAsync(It.IsAny<int>())).ReturnsAsync(false);

            // Act

            // Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _productSeriesService.GetDefaultProductSeriesIdAsync(1));
        }

        [Test]
        public async Task EditAsync_ShouldUpdateProductSeries()
        {
            // Arrange
            var model = new ProductSeriesFormViewModel
            {
                Name = "Updated Product Series",
                DefaultPrice = 250,
                DefaultDescription = "Updated Default Description",
                DefaultColorIds = new List<int> { 3, 4 },
                DefaultMaterialIds = new List<int> { 3, 4 },
                DefaultTagIds = new List<int> { 3, 4 }
            };

            // Act
            await _productSeriesService.EditAsync(1, model);

            // Assert
            var updatedProductSeries = await _context.ProductSeries.SingleOrDefaultAsync(ps => ps.Id == 1);
            Assert.NotNull(updatedProductSeries);
            Assert.AreEqual(model.Name, updatedProductSeries.Name);
            Assert.AreEqual(model.DefaultPrice, updatedProductSeries.DefaultPrice);
            Assert.AreEqual(model.DefaultDescription, updatedProductSeries.DefaultDescription);

            // Assert DefaultColors, DefaultMaterials, and DefaultTags
            Assert.AreEqual(2, updatedProductSeries.DefaultColors.Count());
            Assert.Contains(_context.Colors.Find(3), updatedProductSeries.DefaultColors.ToList());
            Assert.Contains(_context.Colors.Find(4), updatedProductSeries.DefaultColors.ToList());

            // Add more assertions for DefaultMaterials and DefaultTags
        }

        [Test]
        public void EditAsync_ShouldThrowIfNonExistentId()
        {
            var model = new ProductSeriesFormViewModel
            {
                Name = "Updated Product Series",
                DefaultPrice = 250,
                DefaultDescription = "Updated Default Description",
                DefaultColorIds = new List<int> { 3, 4 },
                DefaultMaterialIds = new List<int> { 3, 4 },
                DefaultTagIds = new List<int> { 3, 4 }
            };
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _productSeriesService.EditAsync(999, model));
        }

            [Test]
        public async Task DeleteAsync_ShouldDeactivateProductSeriesAndAssociatedProducts()
        {
            // Arrange
            // Assume you have a product series with Id = 1 and associated products in the seeded data
            var products = new[]
            {
                new Product { Id = 1, SubcategoryId = 1, IsActive = true, Name = "Product1 Name", Description = "Product1 Description", Price=10.00M, Images = new List<Image> {new Image {Id = "p1img1" }, new Image {Id = "p1img2"} }, ProductSeriesId = 1,  },
                new Product { Id = 2, SubcategoryId = 1, IsActive = true , Name = "Product2 Name", Description = "Product2 Description",Price=60.00M, Images = new List<Image> {new Image {Id = "p2img1" }, new Image {Id = "p2img2"}, new Image{Id = "p2img3" } }, ProductSeriesId = 1 },
                new Product { Id = 3, SubcategoryId = 2, IsActive = false, Name = "Product3 Name", Description = "Product3 Description",Price=50.00M, Images = new List<Image> {new Image {Id = "p3img1" }, new Image {Id = "p3img2"} }, ProductSeriesId = 2 }, // Inactive product
                new Product { Id = 4, SubcategoryId = 2, IsActive = true, Name = "Product4 Name", Description = "Product4 Description",Price=40.00M, Images = new List<Image> {new Image {Id = "p4img1" }, new Image {Id = "p4img2"} }, ProductSeriesId = 2 , },
                new Product { Id = 5, SubcategoryId = 2, IsActive = true, IsAvailable = false, Name = "Product5 Name", Description = "Product5 Description",Price=20.00M, Images = new List<Image> {new Image {Id = "p5img1" }, new Image {Id = "p5img2"} }, ProductSeriesId = 2  },
                new Product { Id = 6, SubcategoryId = 2, IsActive = true, Name = "Product6 Name", Description = "Product6 Description",Price=30.00M, Images = new List<Image> {new Image {Id = "p6img1" }, new Image {Id = "p6img2"} }, ProductSeriesId = 2 }
            };
            await _context.Products.AddRangeAsync(products);
            await _context.SaveChangesAsync();
            // Act
            await _productSeriesService.DeleteAsync(1);

            // Assert
            var deactivatedProductSeries = await _context.ProductSeries.SingleOrDefaultAsync(ps => ps.Id == 1);
            Assert.NotNull(deactivatedProductSeries);
            Assert.IsFalse(deactivatedProductSeries.IsActive);

            var deactivatedProducts = await _context.Products.Where(p => p.ProductSeriesId == 1).ToListAsync();
            foreach (var product in deactivatedProducts)
            {
                Assert.IsFalse(product.IsActive);
                // Assert gallery service method call if needed
            }
        }

        [Test]
        public  void DeleteAsync_ShouldThrowIfNonExistentId()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async ()=> await _productSeriesService.DeleteAsync(999));
        }

        [Test]
        public async Task PopulateModel_ShouldPopulateProductSeriesFormViewModel()
        {
            // Arrange
            var model = new ProductSeriesFormViewModel
            {
                CategoryId = 1,
                SubcategoryId = 1
            };

            // Mock the return values for the category and subcategory services
            _mockCategoryService.Setup(s => s.AllCategoriesAsync()).ReturnsAsync(new List<CategorySelectViewModel>
    {
        new CategorySelectViewModel { Id = 1, Name = "Category 1" },
        new CategorySelectViewModel { Id = 2, Name = "Category 2" }
    });

            _mockSubcategoryService.Setup(s => s.SubcategoriesByCategoryIdAsync(model.CategoryId)).ReturnsAsync(new List<SubcategorySelectViewModel>
    {
        new SubcategorySelectViewModel { Id = 1, Name = "Subcategory 1" },
        new SubcategorySelectViewModel { Id = 2, Name = "Subcategory 2" }
    });

            // Mock the return values for color, material, and tag services
            _mockColorService.Setup(s => s.GetAllColorsAsync()).ReturnsAsync(new List<ColorSelectViewModel>
    {
        new ColorSelectViewModel { Id = 1, ColorValue = "Value 1" }
        
    });

            _mockMaterialService.Setup(s => s.GetAllMaterialsAsync()).ReturnsAsync(new List<MaterialListViewModel>
    {
        new MaterialListViewModel { Id = 1, Name = "Material 1" },
        new MaterialListViewModel { Id = 2, Name = "Material 2" }
    });

            _mockTagService.Setup(s => s.GetAllTagsAsync()).ReturnsAsync(new List<TagListViewModel>
    {
        new TagListViewModel { Id = 1, Name = "Tag 1" },
        new TagListViewModel { Id = 2, Name = "Tag 2" },
        new TagListViewModel { Id = 3, Name = "Tag 3" },
    });

            // Act
            var populatedModel = await _productSeriesService.PopulateModel(model);

            // Assert
            Assert.NotNull(populatedModel);
            Assert.AreEqual(1, populatedModel.CategoryId);
            Assert.AreEqual(1, populatedModel.SubcategoryId);

            // Assert CategoryOptions, SubcategoryOptions, ColorOptions, MaterialOptions, and TagOptions
            Assert.AreEqual(2, populatedModel.CategoryOptions.Count());
            Assert.AreEqual(2, populatedModel.SubcategoryOptions.Count());
            Assert.AreEqual(1, populatedModel.ColorOptions.Count());
            Assert.AreEqual(2, populatedModel.MaterialOptions.Count());
            Assert.AreEqual(3, populatedModel.TagOptions.Count());
        }



        [TearDown]
        public async Task Teardown()
        {
            await DisposeDatabase();
        }

        private async Task DisposeDatabase()
        {
            await _context.Database.EnsureDeletedAsync();
            await _context.DisposeAsync();
        }
    }
}
