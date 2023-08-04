
using Microsoft.EntityFrameworkCore;
using Moq;
using VelvetLeaves.Data;
using VelvetLeaves.Services.Contracts;

namespace VelvetLeaves.Services.UnitTests
{
    public class Tests
    {
        private VelvetLeavesDbContext dbContext;
        private CategoryService categoryService;

        private IImageService _imageService;
        private IGalleryService _galleryService;    


        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<VelvetLeavesDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            dbContext = new VelvetLeavesDbContext(options);
            IImageService imageService = new Mock<IImageService>().Object;
            IGalleryService galleryService = new Mock<IGalleryService>().Object;

            categoryService = new CategoryService(dbContext, imageService, galleryService);
        }



        [Test]
        public async Task AddCategoryAsync_Should_Add_Category_To_Context()
        {
            // Arrange
            var categoryName = "TestCategory";
            var imageId = "testImageId";

            // Act
            await categoryService.AddCategoryAsync(categoryName, imageId);

            // Assert
            var addedCategory = dbContext.Categories.FirstOrDefault(c => c.Name == categoryName);
            Assert.IsNotNull(addedCategory);
            Assert.AreEqual(categoryName, addedCategory.Name);
            Assert.AreEqual(imageId, addedCategory.ImageId);
        }
    }
}
