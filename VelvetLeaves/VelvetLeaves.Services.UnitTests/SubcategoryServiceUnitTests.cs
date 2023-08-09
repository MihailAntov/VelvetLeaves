

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using VelvetLeaves.Data;
using VelvetLeaves.Data.Models;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Category;
using VelvetLeaves.ViewModels.Subcategory;

namespace VelvetLeaves.Services.UnitTests
{
    [TestFixture]
    public class SubcategoryServiceUnitTests
    {
        private DbContextOptions<VelvetLeavesDbContext> _dbContextOptions;
        private VelvetLeavesDbContext _dbContext;
        private SubcategoryService _subcategoryService;

        private Mock<ICategoryService> _mockCategoryService;    
        private Mock<IImageService> _mockImageService;    
        private Mock<IGalleryService> _mockGalleryService;    


        [SetUp]
        public void Setup()
        {
            _dbContextOptions = new DbContextOptionsBuilder<VelvetLeavesDbContext>()
                .UseInMemoryDatabase(databaseName: "test_db")
                .Options;

            _dbContext = new VelvetLeavesDbContext(_dbContextOptions);
            _mockCategoryService = new Mock<ICategoryService>();
            _mockImageService = new Mock<IImageService>();
            _mockGalleryService = new Mock<IGalleryService>();

            _subcategoryService = new SubcategoryService(
                _dbContext,
                _mockCategoryService.Object,
                _mockImageService.Object,
                _mockGalleryService.Object
            );
        }

        [TearDown]
        public async Task Teardown()
        {
            await _dbContext.Database.EnsureDeletedAsync();
            _dbContext.Dispose();
        }

        [Test]
        public async Task AddAsync_ValidData_SavesToDatabase()
        {
            // Arrange
            var name = "TestCategory";
            var categoryId = 1;
            var imageId = "imageId";

            _dbContext.Subcategories.RemoveRange(_dbContext.Subcategories);
            await _dbContext.SaveChangesAsync();
            // Act
            await _subcategoryService.AddAsync(name, categoryId, imageId);
            await _dbContext.SaveChangesAsync();

            // Assert
            var savedSubcategory = await _dbContext.Subcategories.FirstOrDefaultAsync();
            Assert.AreEqual(_dbContext.Subcategories.Count(), 1);
            Assert.NotNull(savedSubcategory);
            Assert.AreEqual(name, savedSubcategory.Name);
            Assert.AreEqual(categoryId, savedSubcategory.CategoryId);
            Assert.AreEqual(imageId, savedSubcategory.ImageId);
        }

        [Test]
        public async Task AllSubcategoriesAsync_ReturnsSubcategories()
        {
            // Arrange
            _dbContext.Subcategories.AddRange(new List<Subcategory>
            {
                new Subcategory { Id = 1, Name = "Subcategory 1", ImageId = "img1id", IsActive = true },
                new Subcategory { Id = 2, Name = "Subcategory 2", ImageId = "img2id", IsActive = true }
            });
            await _dbContext.SaveChangesAsync();

            // Act
            var subcategories = await _subcategoryService.AllSubcategoriesAsync();

            // Assert
            Assert.NotNull(subcategories);
            Assert.AreEqual(2, subcategories.Count());
        }

        [Test]
        public async Task DeleteAsync_ThrowsIfSubcategoryIdNotValid()
        {
            var subcategory = new Subcategory
            {
                Id = 1,
                IsActive = true,
                Name = "Test Subcategory",
                ImageId = "img1id",
                ProductSeries = new List<ProductSeries>
                {
                    new ProductSeries
                    {
                        Id = 1,
                        IsActive = true,
                        Name = "testName",
                        DefaultName = "test",
                        DefaultDescription = "test",
                        Products = new List<Product>
                        {
                            new Product { Id = 1, IsActive = true, Name = "Product Name", Description = "Product Description" }
                        }
                    }
                }
            };
            _dbContext.Subcategories.Add(subcategory);
            await _dbContext.SaveChangesAsync();
            var incorrectId = 555;
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _subcategoryService.DeleteAsync(incorrectId));
        }


        [Test]
        public async Task DeleteAsync_DeactivatesSubcategoryAndRelatedData()
        {
            // Arrange
            var subcategory = new Subcategory
            {
                Id = 1,
                IsActive = true,
                Name = "Test Subcategory",
                ImageId = "img1id",
                ProductSeries = new List<ProductSeries>
                {
                    new ProductSeries
                    {
                        Id = 1,
                        IsActive = true,
                        Name = "testName",
                        DefaultName = "test",
                        DefaultDescription = "test",
                        Products = new List<Product>
                        {
                            new Product { Id = 1, IsActive = true, Name = "Product Name", Description = "Product Description" }
                        }
                    }
                }
            };
            _dbContext.Subcategories.Add(subcategory);
            await _dbContext.SaveChangesAsync();

            _mockGalleryService.Setup(service => service.RemoveItemFromAllGalleries(It.IsAny<int>()))
                              .Returns(Task.CompletedTask);

            // Act
            await _subcategoryService.DeleteAsync(subcategory.Id);

            // Assert
            Assert.IsFalse(subcategory.IsActive);
            Assert.IsFalse(subcategory.ProductSeries.First().IsActive);
            Assert.IsFalse(subcategory.ProductSeries.First().Products.First().IsActive);
            _mockGalleryService.Verify(service => service.RemoveItemFromAllGalleries(It.IsAny<int>()), Times.Once);
            
        }


        [Test]
        public async Task EditAsync_ThrowsIfSubcategoryIdNotValid()
        {

            var subcategory = new Subcategory
            {
                Id = 1,
                IsActive = true,
                Name = "Old Name",
                CategoryId = 1,
                ImageId = "Old Image"

            };
            _dbContext.Subcategories.Add(subcategory);
            await _dbContext.SaveChangesAsync();

            var editModel = new SubcategoryEditFormViewModel
            {
                Id = 555,
                Name = "New Name",
                CategoryId = 2,
                Image = new Mock<IFormFile>().Object,
                ImageId = "Old Image"

            };
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _subcategoryService.EditAsync(editModel));
        }
        [Test]
        public async Task EditAsync_UpdatesSubcategory()
        {
            // Arrange
            var subcategory = new Subcategory
            {
                Id = 1,
                IsActive = true,
                Name = "Old Name",
                CategoryId = 1,
                ImageId = "Old Image"

            };
            _dbContext.Subcategories.Add(subcategory);
            await _dbContext.SaveChangesAsync();

            var editModel = new SubcategoryEditFormViewModel
            {
                Id = 1,
                Name = "New Name",
                CategoryId = 2,
                Image = new Mock<IFormFile>().Object,
                ImageId = "Old Image"
                
            };

            _mockImageService.Setup(service => service.UpdateAsync(editModel.ImageId, editModel.Image))
                             .Returns(Task.CompletedTask);

            // Act
            await _subcategoryService.EditAsync(editModel);

            // Assert
            subcategory = await _dbContext.Subcategories.FirstOrDefaultAsync();
            Assert.NotNull(subcategory);
            Assert.AreEqual(editModel.Name, subcategory.Name);
            Assert.AreEqual(editModel.CategoryId, subcategory.CategoryId);
            
        }

        [Test]
        public async Task ExistsByIdAsync_Exists_ReturnsTrue()
        {
            // Arrange
            var subcategory = new Subcategory
            {
                Id = 1,
                IsActive = true,
                ImageId = "imgid",
                Name = "Category Name"
            };
            _dbContext.Subcategories.Add(subcategory);
            await _dbContext.SaveChangesAsync();

            // Act
            var exists = await _subcategoryService.ExistsByIdAsync(subcategory.Id);

            // Assert
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task ExistsByIdAsync_NotExists_ReturnsFalse()
        {
            // Arrange
            var subcategoryId = 1; // A subcategory that does not exist in the database

            // Act
            var exists = await _subcategoryService.ExistsByIdAsync(subcategoryId);

            // Assert
            Assert.IsFalse(exists);
        }

        [Test]
        public async Task GetDefaultSubcategoryIdAsync_ReturnsDefaultSubcategoryId()
        {
            // Arrange
            _dbContext.Subcategories.AddRange(new Subcategory
            {
                Id = 1,
                IsActive = true,
                CategoryId = 1,
                Name = "Category Name",
                ImageId = "ImgId"
            });
            await _dbContext.SaveChangesAsync();

            // Act
            var defaultSubcategoryId = await _subcategoryService.GetDefaultSubcategoryIdAsync(1);

            // Assert
            Assert.AreEqual(1, defaultSubcategoryId);
        }

        [Test]
        public async Task GetForEditAsync_ReturnsSubcategoryEditFormViewModel()
        {
            // Arrange
            var categoryId = 1;
            var subcategory = new Subcategory
            {
                Id = 1,
                Name = "Subcategory 1",
                CategoryId = categoryId,
                ImageId = "imageId",
                IsActive = true
            };
            _dbContext.Subcategories.Add(subcategory);
            await _dbContext.SaveChangesAsync();

            _mockCategoryService.Setup(service => service.AllCategoriesAsync())
                               .ReturnsAsync(new List<CategorySelectViewModel>
                               {
                                   new CategorySelectViewModel { Id = categoryId, Name = "Category 1" }
                               });

            // Act
            var editModel = await _subcategoryService.GetForEditAsync(subcategory.Id);

            // Assert
            Assert.NotNull(editModel);
            Assert.AreEqual(subcategory.Id, editModel.Id);
            Assert.AreEqual(subcategory.Name, editModel.Name);
            Assert.AreEqual(subcategory.CategoryId, editModel.CategoryId);
            Assert.AreEqual(subcategory.ImageId, editModel.ImageId);
            Assert.NotNull(editModel.CategoryOptions);
            Assert.AreEqual(1, editModel.CategoryOptions.Count());
        }

        [Test]
        public async Task SubcategoriesByCategoryIdAsync_ReturnsSubcategories()
        {
            // Arrange
            var categoryId = 1;
            _dbContext.Subcategories.AddRange(new List<Subcategory>
            {
                new Subcategory { Id = 1, Name = "Subcategory 1", CategoryId = categoryId, IsActive = true, ImageId = "img1id" },
                new Subcategory { Id = 2, Name = "Subcategory 2", CategoryId = categoryId, IsActive = true, ImageId = "img2id" }
            });
            await _dbContext.SaveChangesAsync();

            // Act
            var subcategories = await _subcategoryService.SubcategoriesByCategoryIdAsync(categoryId);

            // Assert
            Assert.NotNull(subcategories);
            Assert.AreEqual(2, subcategories.Count());
        }

        //public async Task<SubcategoryFormViewModel> PopulateModel(SubcategoryFormViewModel model)
        //{
        //    var categories = await _categoryService.AllCategoriesAsync();
        //    model.CategoryId = !categories.Select(c => c.Id).Contains(model.CategoryId) ? await _categoryService.GetDefaultCategoryIdAsync() : model.CategoryId;
        //    model.CategoryOptions = categories;

        //    return model;
        //}

        [Test]
        public async Task PopulateModel_ValidCategoryId_ReturnsCorrectOptions()
        {
            var categoryId = 1;
            

            _mockCategoryService.Setup(service => service.AllCategoriesAsync()).ReturnsAsync(new List<CategorySelectViewModel>
            {
                new CategorySelectViewModel { Id = 1, Name = "c1"},
                new CategorySelectViewModel { Id = 2, Name = "c2"}
            });
            

            var model = new SubcategoryFormViewModel()
            {
                CategoryId = categoryId
            };

            _subcategoryService = new SubcategoryService(
                _dbContext,
                _mockCategoryService.Object,
                _mockImageService.Object,
                _mockGalleryService.Object
            );

            model = await _subcategoryService.PopulateModel(model);

            Assert.AreEqual(model.CategoryOptions.Count(), 2);
            Assert.IsTrue(model.CategoryOptions.Any(o => o.Name == "c1"));
            Assert.IsTrue(model.CategoryOptions.Any(o => o.Name == "c2"));
        }

        [Test]
        public async Task PopulateModel_InValidCategoryId_ReturnsDefaultOptions()
        {

        }

    }
}
