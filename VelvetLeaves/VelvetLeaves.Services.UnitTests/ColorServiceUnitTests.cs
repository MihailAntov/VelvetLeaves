using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelvetLeaves.Data;
using VelvetLeaves.Data.Models;
using VelvetLeaves.ViewModels.Colors;

namespace VelvetLeaves.Services.UnitTests
{
    [TestFixture]
    public class ColorServiceUnitTests
    {
        private DbContextOptions<VelvetLeavesDbContext> _dbContextOptions;
        private VelvetLeavesDbContext _dbContext;
        private ColorService _colorService;

        [SetUp]
        public void Setup()
        {
            _dbContextOptions = new DbContextOptionsBuilder<VelvetLeavesDbContext>()
                .UseInMemoryDatabase(databaseName: "test_db")
                .Options;

            _dbContext = new VelvetLeavesDbContext(_dbContextOptions);

            _colorService = new ColorService(_dbContext);
        }

		[TearDown]
        public async Task TearDown()
		{
            await _dbContext.Database.EnsureDeletedAsync();
            _dbContext.Dispose();
		}

        [Test]
        public async Task AddAsync_AddsColorToDatabase()
        {
            // Arrange
            var model = new ColorFormViewModel
            {
                Name = "Red",
                Color = "#FF0000"
            };

            // Act
            await _colorService.AddAsync(model);

            // Assert
            var color = await _dbContext.Colors.FirstOrDefaultAsync(c => c.Name == model.Name);
            Assert.NotNull(color);
            Assert.AreEqual(model.Name, color.Name);
            Assert.AreEqual(model.Color, color.ColorValue);
        }

        [Test]
        public async Task DeleteAsync_SetsColorAsInactive()
        {
            // Arrange
            var color = new Color { Id = 1, Name = "Red", ColorValue = "#FF0000", IsActive = true };
            _dbContext.Colors.Add(color);
            await _dbContext.SaveChangesAsync();

            // Act
            await _colorService.DeleteAsync(color.Id);

            // Assert
            color = await _dbContext.Colors.FirstOrDefaultAsync(c => c.Id == color.Id);
            Assert.NotNull(color);
            Assert.IsFalse(color.IsActive);
        }

        [Test]
        public async Task GetAllColorsAsync_ReturnsAllActiveColors()
        {
            // Arrange
            _dbContext.Colors.AddRange(new List<Color>
            {
                new Color { Id = 1, Name = "Red", ColorValue = "#FF0000", IsActive = true },
                new Color { Id = 2, Name = "Blue", ColorValue = "#0000FF", IsActive = true }
            });
            await _dbContext.SaveChangesAsync();

            // Act
            var colors = await _colorService.GetAllColorsAsync();

            // Assert
            Assert.NotNull(colors);
            Assert.AreEqual(2, colors.Count());
        }

		[Test]
		[TestCase(0, 0)]
		[TestCase(null, 0)]
		[TestCase(0, null)]
        public async Task GetColorOptionsAsync_ReturnsAllOptionsIfCategoryAndSubcategoryMissing(int? categoryId, int? subcategoryId)
		{
            

            SeedDatabase();


            // Act
            var colorOptions = await _colorService.GetColorOptionsAsync(categoryId, subcategoryId);

            // Assert
            Assert.NotNull(colorOptions);
            Assert.IsTrue(colorOptions.Any(c => c.Id == 1));
            Assert.IsTrue(colorOptions.Any(c => c.Id == 2));
            Assert.IsTrue(colorOptions.Any(c => c.Id == 3));
        }

        [Test]
        public async Task GetColorOptionsAsync_ReturnsColorOptions()
        {
            // Arrange
            var categoryId = 1;
            var subcategoryId = 1;

            SeedDatabase();


            // Act
            var colorOptions = await _colorService.GetColorOptionsAsync(categoryId, subcategoryId);

            // Assert
            Assert.NotNull(colorOptions);
            Assert.IsTrue(colorOptions.Any(c => c.Id == 1));
            Assert.IsTrue(colorOptions.Any(c => c.Id == 2));
            // Add your assertions here based on the expected behavior
        }


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
                new Product { Id = 5, SubcategoryId = 2, IsActive = true, IsAvailable = false, Name = "Product5 Name", Description = "Product5 Description",Price=20.00M, Images = new List<Image> {new Image {Id = "p5img1" }, new Image {Id = "p5img2"} }, ProductSeriesId = 2 , Tags = new List<Tag> { new Tag { Id = 4, Name = "Tag 4" } }, Materials = new List<Material> { new Material { Id = 4, Name = "Material 4" } } },
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
    }
}
