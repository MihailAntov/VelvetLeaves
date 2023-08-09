

using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data;
using VelvetLeaves.Data.Models;
using VelvetLeaves.ViewModels.Material;

namespace VelvetLeaves.Services.UnitTests
{
	public class MaterialServiceUnitTests
	{

        private DbContextOptions<VelvetLeavesDbContext> _dbContextOptions;
        private MaterialService _materialService;
        private VelvetLeavesDbContext _dbContext;

        [SetUp]
        public void Setup()
        {
            _dbContextOptions = new DbContextOptionsBuilder<VelvetLeavesDbContext>()
                .UseInMemoryDatabase(databaseName: "test_db")
                .Options;

            _dbContext = new VelvetLeavesDbContext(_dbContextOptions);
            _materialService = new MaterialService(_dbContext);
        }

		[TearDown]
        public async Task TearDown()
		{
            await _dbContext.Database.EnsureDeletedAsync();
            await _dbContext.DisposeAsync();

        }
        [Test]
        public async Task AddAsync_ValidModel_AddsMaterial()
        {
            // Arrange
            var model = new MaterialFormViewModel { Name = "Material Name" };

            // Act
            await _materialService.AddAsync(model);

            // Assert

            {
                var material = _dbContext.Materials.SingleOrDefault();
                Assert.NotNull(material);
                Assert.AreEqual("Material Name", material.Name);
            }
        }

        [Test]
        public async Task DeleteAsync_ThrowsifMaterialIdNotFound()
        {
            var materialId = 1;
            var material = new Material { Name = "Material Name", Id = materialId, IsActive = true };


            _dbContext.Materials.Add(material);
            await _dbContext.SaveChangesAsync();
            var wrongMaterialId = 555;

            // Act
            Assert.ThrowsAsync<InvalidOperationException>(async ()=> await _materialService.DeleteAsync(wrongMaterialId));
        }



        [Test]
        public async Task DeleteAsync_ExistingMaterialId_SetsMaterialInactive()
        {
            // Arrange
            var materialId = 1;
            var material = new Material { Name = "Material Name", Id = materialId, IsActive = true };


                _dbContext.Materials.Add(material);
                await _dbContext.SaveChangesAsync();
            

            // Act
            await _materialService.DeleteAsync(materialId);

            // Assert
            
                var deletedMaterial = _dbContext.Materials.Find(materialId);
                Assert.NotNull(deletedMaterial);
                Assert.IsFalse(deletedMaterial.IsActive);
            
        }

        [Test]
        public async Task GetAllMaterialsAsync_ReturnsActiveMaterials()
        {
            // Arrange
            var materials = new List<Material>
        {
            new Material { Id = 1, Name = "Material 1", IsActive = true },
            new Material { Id = 2, Name = "Material 2", IsActive = false },
        };


                _dbContext.Materials.AddRange(materials);
                await _dbContext.SaveChangesAsync();
            

            // Act
            var result = await _materialService.GetAllMaterialsAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("Material 1", result.First().Name);
        }

        [Test]
        
        public async Task GetMaterialOptionsAsync_ReturnsAllOptionsIfCategoryAndSubcategoryMissing()
        {


            SeedDatabase();


            // Act
            var materialOptions = await _materialService.GetMaterialOptionsAsync(1, 1);

            // Assert
            Assert.NotNull(materialOptions);
            Assert.AreEqual(materialOptions.Count(), 2);
            Assert.IsTrue(materialOptions.Any(c => c.Id == 1));
            Assert.IsTrue(materialOptions.Any(c => c.Id == 2));

        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(null, 0)]
        [TestCase(0, null)]
        public async Task GetMaterialOptionsAsync_ReturnsAllOptionsIfCategoryAndSubcategoryMissing(int? categoryId, int? subcategoryId)
        {


            SeedDatabase();


            // Act
            var materialOptions = await _materialService.GetMaterialOptionsAsync(categoryId, subcategoryId);

            // Assert
            Assert.NotNull(materialOptions);
            Assert.AreEqual(materialOptions.Count(), 3);
            Assert.IsTrue(materialOptions.Any(c => c.Id == 1));
            Assert.IsTrue(materialOptions.Any(c => c.Id == 2));
            Assert.IsTrue(materialOptions.Any(c => c.Id == 4));

        }

        [Test]
        [TestCase(1, 0, 2)]
        [TestCase(0, 2, 1)]
        public async Task GetMaterialOptionsAsync_ReturnsCorrectOptionsIfOneOfParametersIsMissin(int? categoryId, int? subcategoryId, int count)
        {


            SeedDatabase();


            // Act
            var materialOptions = await _materialService.GetMaterialOptionsAsync(categoryId, subcategoryId);

            // Assert
            Assert.NotNull(materialOptions);
            Assert.AreEqual(materialOptions.Count(), count);

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
                new Product { Id = 1, SubcategoryId = 1, IsActive = true, Name = "Product1 Name", Description = "Product1 Description", Price=10.00M, Images = new List<Image> {new Image {Id = "p1img1" }, new Image {Id = "p1img2"} }, ProductSeriesId = 1, Colors = new List<Color> {colors[0], colors[1] }, Tags = new List<Tag> {tags[0] } , Materials = new List<Material>{materials[0],materials[1]} },
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
