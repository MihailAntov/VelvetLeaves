using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Moq;
using System.Text;
using VelvetLeaves.Data.ObjectDatabase;
using VelvetLeaves.Data.ObjectDatabase.Contracts;
using VelvetLeaves.Services.UnitTests.HelperClasses;

namespace VelvetLeaves.Services.UnitTests
{
    [TestFixture]
    public class ImageServiceUnitTests
    {
        private Mock<IObjectDbContext> _mockContext;
        private ImageService _imageService;
        


        public ImageServiceUnitTests()
        {
            _mockContext = new Mock<IObjectDbContext>();
            _imageService = new ImageService(_mockContext.Object);
        }

        [SetUp]
        public void Setup()
        {
           

            


        }

        [Test]
        public async Task CreateAsync_ValidFile_ReturnsId()
        {
            // Arrange
            var _mockCollection = new Mock<IMongoCollection<Image>>();
            _mockContext.Setup(context => context.Images).Returns(_mockCollection.Object);
            _mockCollection.Setup(collection => collection.InsertOneAsync(It.IsAny<Image>(),null,default)).Returns(Task.CompletedTask);
            _imageService = new ImageService(_mockContext.Object);

            var mockFormFile = new Mock<IFormFile>();
            var contentBytes = Encoding.UTF8.GetBytes("This is the content.");
            var memoryStream = new MemoryStream(contentBytes);

            mockFormFile.Setup(f => f.CopyToAsync(It.IsAny<Stream>(), default(CancellationToken)))
                        .Callback<Stream, CancellationToken>((stream, cancellationToken) =>
                        {
                            memoryStream.Seek(0, SeekOrigin.Begin);
                            memoryStream.CopyTo(stream);
                        })
                        .Returns(Task.CompletedTask);

            // Act
            var result = await _imageService.CreateAsync(mockFormFile.Object);

            // Assert
            
            _mockCollection.Verify(collection => collection.InsertOneAsync(It.IsAny<Image>(), null, default), Times.Once);
        }

        [Test]
        public async Task CreateFromStringAsync_CallsFindOneAndDeleteAndInsertOneAsync()
        {
            // Arrange
            string id = "sampleId";
            string content = "sampleContent";

            var _mockCollection = new Mock<IMongoCollection<Image>>();
            _mockContext.Setup(context => context.Images).Returns(_mockCollection.Object);
            //_mockCollection.Setup(collection => collection.InsertOneAsync(It.IsAny<Image>(), null, default)).Returns(Task.CompletedTask);
            //_mockCollection.Setup(collection => collection.FindOneAndDeleteAsync(It.IsAny<FilterDefinition<Image>>(), null, default)).ReturnsAsync(new Image() { });
            _imageService = new ImageService(_mockContext.Object);


            // Act
            var image = await _imageService.CreateFromStringAsync(id, content);

            Assert.AreEqual(image.Id, id);
            Assert.AreEqual(image.Content, content);
        }

        [Test]
        public async Task CreateRangeAsync_UploadsImagesAndReturnsIds()
        {
            // Arrange
            var files = new List<IFormFile>
            {
                CreateFormFile("image1.jpg"),
                CreateFormFile("image2.jpg"),
                CreateFormFile("image3.jpg")
            };
            var _mockCollection = new Mock<IMongoCollection<Image>>();
            foreach (var file in files)
            {
                _mockCollection
                    .Setup(c => c.InsertOneAsync(It.IsAny<Image>(), null, default))
                    .Returns(Task.CompletedTask)
                    .Callback((Image image ,InsertOneOptions options, CancellationToken token) => image.Id = Guid.NewGuid().ToString());

            }
            _mockContext.Setup(context => context.Images).Returns(_mockCollection.Object);
            _imageService = new ImageService(_mockContext.Object);
            // Act
            var result = await _imageService.CreateRangeAsync(files);

            // Assert
            Assert.AreEqual(files.Count, result.Count());
            foreach (var id in result)
            {
                Assert.IsNotNull(id);
                Assert.IsNotEmpty(id);
            }
        }

        private IFormFile CreateFormFile(string fileName)
        {
            var content = new MemoryStream(new byte[] { 1, 2, 3 }); // Example content
            return new FormFile(content, 0, content.Length, "file", fileName);
        }

        [Test]
        public async Task GetAsync_ReturnsImageContent()
        {
            // Arrange
            var id = "imageId";
            var content = "randomContent";
            var image = new Image { Id = id, Content = content };
            var _mockCollection = new Mock<IMongoCollection<Image>>();
            _mockContext.Setup(context => context.Images).Returns(_mockCollection.Object);
            _imageService = new ImageServiceTest(_mockContext.Object);


            // Act
            var result = await _imageService.GetAsync(id);

            // Assert
            Assert.AreEqual(content, result);
        }

        [Test]
        public async Task GetAsync_ReturnsNullForNonExistentImage()
        {
            // Arrange
            var id = "nonExistentId";

            var _mockCollection = new Mock<IMongoCollection<Image>>();
            
            _mockContext.Setup(context => context.Images).Returns(_mockCollection.Object);
            _imageService = new ImageServiceTest(_mockContext.Object);

            

            // Act
            var result = await _imageService.GetAsync(id);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task RemoveAsync_DeletesImageById()
        {
            // Arrange
            var id = "imageId";
            var _mockCollection = new Mock<IMongoCollection<Image>>();
            _mockContext.Setup(context => context.Images).Returns(_mockCollection.Object);
            _imageService = new ImageServiceTest(_mockContext.Object);


            // Act
            var result =  await _imageService.RemoveAsync(id);

            // Assert
            Assert.IsTrue(result);
            
        }

        [Test]
        public async Task RemoveAsync_ReturnsFalseIfNoImageFound()
        {
            // Arrange
            var id = Guid.NewGuid().ToString();
            var _mockCollection = new Mock<IMongoCollection<Image>>();
            _mockContext.Setup(context => context.Images).Returns(_mockCollection.Object);
            _imageService = new ImageServiceTest(_mockContext.Object);


            // Act
            var result = await _imageService.RemoveAsync(id);

            // Assert
            Assert.IsFalse(result);

        }


        [Test]
        public async Task UpdateAsync_ExistingImage_ModifiesContent()
        {
            // Arrange
            var id = "imageId";
            var content = "newImageContent";
            var _mockCollection = new Mock<IMongoCollection<Image>>();
            _mockContext.Setup(context => context.Images).Returns(_mockCollection.Object);
            _imageService = new ImageService(_mockContext.Object);
            var mockReplaceOneResult = new ReplaceOneResult.Acknowledged(1, 1, id);
            _mockCollection
                .Setup(c => c.ReplaceOneAsync(
                    It.IsAny<FilterDefinition<Image>>(),
                    It.IsAny<Image>(),
                    It.IsAny<ReplaceOptions>(),
                    default))
                .ReturnsAsync(mockReplaceOneResult);

            // Act
            var formFile = new Mock<IFormFile>();
            formFile.Setup(f => f.CopyToAsync(It.IsAny<Stream>(), default))
                .Callback<Stream, CancellationToken>((stream, token) =>
                {
                    var bytes = Encoding.UTF8.GetBytes(content);
                    stream.Write(bytes, 0, bytes.Length);
                })
                .Returns(Task.CompletedTask);

            await _imageService.UpdateAsync(id, formFile.Object);

            // Assert
            _mockCollection.Verify(
                c => c.ReplaceOneAsync(
                    It.IsAny<FilterDefinition<Image>>(),
                    It.IsAny<Image>(),
                    It.IsAny<ReplaceOptions>(),
                    default),
                Times.Once);

            _mockCollection.Verify(
                c => c.InsertOneAsync(
                    It.IsAny<Image>(),
                    It.IsAny<InsertOneOptions>(),
                    default),
                Times.Never);
        }

        [Test]
        public async Task UpdateAsync_NonExistingImage_InsertsNewImage()
        {
            // Arrange
            var id = "newImageId";
            var content = "newImageContent";

            var _mockCollection = new Mock<IMongoCollection<Image>>();
            _mockContext.Setup(context => context.Images).Returns(_mockCollection.Object);
            _imageService = new ImageService(_mockContext.Object);

            var mockReplaceOneResult = new ReplaceOneResult.Acknowledged(0, 0, id);
            _mockCollection
                .Setup(c => c.ReplaceOneAsync(
                    It.IsAny<FilterDefinition<Image>>(),
                    It.IsAny<Image>(),
                    It.IsAny<ReplaceOptions>(),
                    default))
                .ReturnsAsync(mockReplaceOneResult);

            // Act
            var formFile = new Mock<IFormFile>();
            formFile.Setup(f => f.CopyToAsync(It.IsAny<Stream>(), default))
                .Callback<Stream, CancellationToken>((stream, token) =>
                {
                    var bytes = Encoding.UTF8.GetBytes(content);
                    stream.Write(bytes, 0, bytes.Length);
                })
                .Returns(Task.CompletedTask);

            await _imageService.UpdateAsync(id, formFile.Object);

            // Assert
            _mockCollection.Verify(
                c => c.ReplaceOneAsync(
                    It.IsAny<FilterDefinition<Image>>(),
                    It.IsAny<Image>(),
                    It.IsAny<ReplaceOptions>(),
                    default),
                Times.Once);

            _mockCollection.Verify(
                c => c.InsertOneAsync(
                    It.IsAny<Image>(),
                    It.IsAny<InsertOneOptions>(),
                    default),
                Times.Once);
        }




    }
}