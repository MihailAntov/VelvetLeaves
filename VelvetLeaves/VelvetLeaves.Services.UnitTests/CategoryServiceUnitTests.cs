
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using VelvetLeaves.Data;
using VelvetLeaves.Data.Models;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Category;

namespace VelvetLeaves.Services.UnitTests
{
    [TestFixture]
    public class CategoryServiceUnitTests
    {
        public VelvetLeavesDbContext _dbContext;
        public CategoryService _categoryService;

        public IImageService imageService;
        public IGalleryService galleryService;
        public ILogger<CategoryService> logger;
        public Mock<IImageService> _mockImageService;
        public Mock<IGalleryService> _mockGalleryService;
        public Mock<ILogger<CategoryService>> _mockLogger;


        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<VelvetLeavesDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _dbContext = new VelvetLeavesDbContext(options);
            _mockGalleryService = new Mock<IGalleryService>();
            _mockImageService = new Mock<IImageService>();
            _mockLogger = new Mock<ILogger<CategoryService>>();

            imageService = _mockImageService.Object;
            galleryService = _mockGalleryService.Object;
            logger = _mockLogger.Object;


            _categoryService = new CategoryService(_dbContext, imageService, galleryService, logger);
        }



        [Test]
        public async Task AddCategoryAsync_Should_Add_Category_To_Context()
        {
            // Arrange
            var categoryName = "TestCategory";
            var imageId = "testImageId";

            // Act
            await _categoryService.AddCategoryAsync(categoryName, imageId);

            // Assert
            var addedCategory = _dbContext.Categories.FirstOrDefault(c => c.Name == categoryName);
            Assert.IsNotNull(addedCategory);
            Assert.AreEqual(categoryName, addedCategory.Name);
            Assert.AreEqual(imageId, addedCategory.ImageId);
        }
        [TearDown]
        public void TearDown()
        {
            // Clear the in-memory database after each test
            _dbContext.Database.EnsureDeleted();
        }

        [Test]
        public async Task AllCategoriesAsync_ShouldReturnEmptyList_WhenNoCategoriesExist()
        {
            // Arrange
            // Ensure that the database is empty
            _dbContext.Categories.RemoveRange(_dbContext.Categories);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _categoryService.AllCategoriesAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }

        [Test]
        public async Task AllCategoriesAsync_ShouldNotReturnInactiveCategories()
        {
            // Arrange
            // Ensure that the database is empty
            _dbContext.Categories.RemoveRange(_dbContext.Categories);
            await _dbContext.SaveChangesAsync();
            var categoriesData = new List<Category>
            {
                new Category { Id = 1, Name = "Category 1", ImageId = "Image1", IsActive = true },
                new Category { Id = 2, Name = "Category 2",  ImageId = "Image1" , IsActive = true},
                new Category { Id = 3, Name = "Category 3",  ImageId = "Image1", IsActive = false }
            };
            _dbContext.Categories.AddRange(categoriesData);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _categoryService.AllCategoriesAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public async Task AllCategoriesAsync_ShouldReturnCorrectCategories_WhenCategoriesExist()
        {
            // Arrange
            var categoriesData = new List<Category>
            {
                new Category { Id = 1, Name = "Category 1", ImageId = "Image1" },
                new Category { Id = 2, Name = "Category 2",  ImageId = "Image1" },
                new Category { Id = 3, Name = "Category 3",  ImageId = "Image1" }
            };

            _dbContext.Categories.AddRange(categoriesData);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _categoryService.AllCategoriesAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(categoriesData.Count, result.Count());

            // Make sure the properties are mapped correctly
            var firstCategory = categoriesData.First();
            var firstResultCategory = result.First();
            Assert.AreEqual(firstCategory.Id, firstResultCategory.Id);
            Assert.AreEqual(firstCategory.Name, firstResultCategory.Name);
        }
        [Test]
        public async Task GetDefaultCategoryIdAsync_ShouldReturnZero_WhenNoCategoriesExist()
        {
            // Arrange
            _dbContext.Categories.RemoveRange(_dbContext.Categories);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _categoryService.GetDefaultCategoryIdAsync();

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public async Task GetDefaultCategoryIdAsync_ShouldReturnZero_WhenNoActiveCategoriesExist()
        {
            // Arrange
            var categoriesData = new List<Category>
        {
            new Category { Id = 1, Name = "Category 1", IsActive = false, ImageId = "Image1id" },
            new Category { Id = 2, Name = "Category 2", IsActive = false, ImageId = "Image2id" }
        };
            _dbContext.Categories.AddRange(categoriesData);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _categoryService.GetDefaultCategoryIdAsync();

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public async Task GetDefaultCategoryIdAsync_ShouldReturnDefaultCategoryId_WhenActiveCategoriesExist()
        {
            // Arrange
            var categoriesData = new List<Category>
        {
            new Category { Id = 1, Name = "Category 1", IsActive = false, ImageId = "Image1id" },
            new Category { Id = 2, Name = "Category 2", IsActive = true, ImageId = "Image2id" },
            new Category { Id = 3, Name = "Category 3", IsActive = true, ImageId = "Image1id" }
        };
            _dbContext.Categories.AddRange(categoriesData);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _categoryService.GetDefaultCategoryIdAsync();

            // Assert
            Assert.AreEqual(2, result); // Category 2 is the first active category in the database
        }



        [Test]
        public async Task CategoryExistsByIdAsync_ShouldReturnFalse_WhenNoCategoriesExist()
        {
            // Arrange
            // Ensure that the database is empty
            _dbContext.Categories.RemoveRange(_dbContext.Categories);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _categoryService.CategoryExistsByIdAsync(1);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task CategoryExistsByIdAsync_ShouldReturnFalse_WhenCategoryDoesNotExist()
        {
            // Arrange
            var categoriesData = new List<Category>
        {
            new Category { Id = 1, Name = "Category 1",ImageId="image1id", IsActive = false },
            new Category { Id = 2, Name = "Category 2",ImageId="image1id", IsActive = true }
        };
            _dbContext.Categories.AddRange(categoriesData);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _categoryService.CategoryExistsByIdAsync(3);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task CategoryExistsByIdAsync_ShouldReturnTrue_WhenCategoryExists()
        {
            // Arrange
            var categoriesData = new List<Category>
        {
            new Category { Id = 1, Name = "Category 1",ImageId="image1id", IsActive = false },
            new Category { Id = 2, Name = "Category 2",ImageId="image2id", IsActive = true }
        };
            _dbContext.Categories.AddRange(categoriesData);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _categoryService.CategoryExistsByIdAsync(2);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task GetForEditAsync_ShouldThrowArgumentException_WhenCategoryDoesNotExist()
        {
            // Arrange
            // Ensure that the database is empty
            _dbContext.Categories.RemoveRange(_dbContext.Categories);
            await _dbContext.SaveChangesAsync();

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _categoryService.GetForEditAsync(1));
        }

        [Test]
        public async Task GetForEditAsync_ShouldThrowArgumentException_WhenCategoryExistsButIsNotActive()
        {
            // Arrange
            var categoriesData = new List<Category>
        {
            new Category { Id = 1, Name = "Category 1", IsActive = false, ImageId="imageId2", },
            new Category { Id = 2, Name = "Category 2", IsActive = true, ImageId = "imageId2" }
        };
            _dbContext.Categories.AddRange(categoriesData);
            await _dbContext.SaveChangesAsync();

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _categoryService.GetForEditAsync(1));
        }

        [Test]
        public async Task GetForEditAsync_ShouldReturnCategoryEditFormViewModel_WhenActiveCategoryWithGivenIdExists()
        {
            // Arrange
            var categoriesData = new List<Category>
        {
            new Category { Id = 1, Name = "Category 1", IsActive = false , ImageId="imageIid1",},
            new Category { Id = 2, Name = "Category 2", IsActive = true, ImageId = "imageId2" }
        };
            _dbContext.Categories.AddRange(categoriesData);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _categoryService.GetForEditAsync(2);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Id);
            Assert.AreEqual("Category 2", result.Name);
            Assert.AreEqual("imageId2", result.ImageId);
        }
        [Test]
        public async Task EditAsync_ShouldThrowIfCategoryIdInvalid()
        {
            var categoriesData = new List<Category>
        {
            new Category { Id = 1, Name = "Category 1", IsActive = true, ImageId = "image1id" },
            new Category { Id = 2, Name = "Category 2", IsActive = true, ImageId = "image2id" }
        };
            _dbContext.Categories.AddRange(categoriesData);
            await _dbContext.SaveChangesAsync();

            var model = new CategoryEditFormViewModel
            {
                Id = 25,
                Name = "Updated Category",
                ImageId = "imageId1",
                Image = null // Not updating the image in this test
            };

            // Act
            Assert.ThrowsAsync<InvalidOperationException>(async ()=> await _categoryService.EditAsync(model));
        }


        [Test]
        public async Task EditAsync_ShouldUpdateCategoryName_WhenValidModelIsProvided()
        {
            // Arrange
            var categoriesData = new List<Category>
        {
            new Category { Id = 1, Name = "Category 1", IsActive = true, ImageId = "image1id" },
            new Category { Id = 2, Name = "Category 2", IsActive = true, ImageId = "image2id" }
        };
            _dbContext.Categories.AddRange(categoriesData);
            await _dbContext.SaveChangesAsync();

            var model = new CategoryEditFormViewModel
            {
                Id = 1,
                Name = "Updated Category",
                ImageId = "imageId1",
                Image = null // Not updating the image in this test
            };

            // Act
            await _categoryService.EditAsync(model);

            // Assert
            var updatedCategory = _dbContext.Categories.Find(1);
            Assert.IsNotNull(updatedCategory);
            Assert.AreEqual("Updated Category", updatedCategory.Name);
        }

        [Test]
        public async Task EditAsync_ShouldCallImageServiceUpdateAsync_WhenImageIsProvidedInModel()
        {
            // Arrange


            var categoriesData = new List<Category>
        {
            new Category { Id = 1, Name = "Category 1", IsActive = true, ImageId = "imageId1" },
            new Category { Id = 2, Name = "Category 2", IsActive = true, ImageId = "imageId2" }
        };
            _dbContext.Categories.AddRange(categoriesData);
            await _dbContext.SaveChangesAsync();
            using var stream = new MemoryStream();
            var model = new CategoryEditFormViewModel
            {
                Id = 1,
                Name = "Updated Category",
                ImageId = "imageId1",
                Image = new FormFile(stream, 0, 100, "imgfile", "file-name") // Updating the image in this test
            };

            // Act
            await _categoryService.EditAsync(model);

            // Assert
            _mockImageService.Verify(mock => mock.UpdateAsync("imageId1", model.Image), Times.Once);
        }

        [Test]
        public async Task EditAsync_ShouldNotCallImageServiceUpdateAsync_WhenImageIsNullInModel()
        {
            // Arrange
            var categoriesData = new List<Category>
        {
            new Category { Id = 1, Name = "Category 1", IsActive = true, ImageId = "imageId1" },
            new Category { Id = 2, Name = "Category 2", IsActive = true, ImageId = "imageId2" }
        };
            _dbContext.Categories.AddRange(categoriesData);
            await _dbContext.SaveChangesAsync();

            var model = new CategoryEditFormViewModel
            {
                Id = 1,
                Name = "Updated Category",
                ImageId = "imageId1",
                Image = null // Not updating the image in this test
            };

            // Act
            await _categoryService.EditAsync(model);

            // Assert
            _mockImageService.Verify(mock => mock.UpdateAsync(It.IsAny<string>(), It.IsAny<IFormFile>()), Times.Never);
        }

        [Test]
        public async Task DeleteAsync_ShouldThrowArgumentException_WhenCategoryDoesNotExist()
        {
            // Arrange
            // Ensure that the database is empty
            _dbContext.Categories.RemoveRange(_dbContext.Categories);
            await _dbContext.SaveChangesAsync();

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _categoryService.DeleteAsync(1));
        }

        [Test]
        public async Task DeleteAsync_ShouldDeactivateCategoryAndRelatedEntities_WhenCategoryExists()
        {
            // Arrange
            var category = new Category
            {
                Id = 1,
                Name = "Category 1",
                IsActive = true,
                ImageId = "Image1Id",
                Subcategories = new List<Subcategory>
            {
                new Subcategory
                {
                    Id = 11,
                    Name = "Subcategory 1",
                    IsActive = true,
                    ImageId = "Image1Id",
                    ProductSeries = new List<ProductSeries>
                    {
                        new ProductSeries
                        {
                            Id = 111,
                            Name = "Series 1",
                            DefaultDescription = "test description",
                            DefaultName = "test name",

                            IsActive = true,
                            Products = new List<Product>
                            {
                                new Product { Id = 1111, Name = "Product 1", IsActive = true, Description = "test description", Images = new List<Image> ()
                                {
                                    new Image() { Id = "image1guid"},
                                    new Image() { Id = "image2guid"}
                                } },
                                new Product { Id = 1112, Name = "Product 2", IsActive = true ,Description = "test description", Images = new List<Image>(){
                                    new Image() { Id = "image3guid"},
                                    new Image() { Id = "image4guid"}
                                } }

                            }
                        }
                    }
                }
            }
            };
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();

            // Act
            await _categoryService.DeleteAsync(1);

            // Assert
            var deletedCategory = _dbContext.Categories.Find(1);
            var deletedSubcategory = _dbContext.Subcategories.Find(11);
            var deletedSeries = _dbContext.ProductSeries.Find(111);
            var deletedProduct1 = _dbContext.Products.Find(1111);
            var deletedProduct2 = _dbContext.Products.Find(1112);

            Assert.IsNotNull(deletedCategory);
            Assert.IsFalse(deletedCategory.IsActive);

            Assert.IsNotNull(deletedSubcategory);
            Assert.IsFalse(deletedSubcategory.IsActive);

            Assert.IsNotNull(deletedSeries);
            Assert.IsFalse(deletedSeries.IsActive);

            Assert.IsNotNull(deletedProduct1);
            Assert.IsFalse(deletedProduct1.IsActive);

            Assert.IsNotNull(deletedProduct2);
            Assert.IsFalse(deletedProduct2.IsActive);
        }


    }
}
