
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using VelvetLeaves.Data.Configuration;
using VelvetLeaves.Data.Images;
using VelvetLeaves.Services.Contracts;

namespace VelvetLeaves.Services
{
    public class ImageService : IImageService
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IMongoCollection<Image> _imagesCollection;
        public ImageService(IHostingEnvironment hostingEnvironment, IOptions<ImageDatabaseSettings> imageDatabaseSettings)
        {
            _hostingEnvironment = hostingEnvironment;

            var mongoClient = new MongoClient(
            imageDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                imageDatabaseSettings.Value.DatabaseName);

            _imagesCollection = mongoDatabase.GetCollection<Image>(
                imageDatabaseSettings.Value.ImagesCollectionName);
        }

		public async Task<string?> CreateAsync(IFormFile content)
		{
            //string imgContent = content.
            //await _imagesCollection.InsertOneAsync(newBook);
            string? id = null;
            using (var memoryStream = new MemoryStream())
            {
                await content.CopyToAsync(memoryStream);
                
                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    var image = new Image()
                    {
                        
                        Content = Convert.ToBase64String(memoryStream.ToArray())
                    };

                    
                    

                    var result = _imagesCollection.InsertOneAsync(image);

                    id = image.Id;
                    
                }
                
            }
            
            return id;
            
        }

		public Task<List<string>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task<string?> GetAsync(string id)
		{
			throw new NotImplementedException();
		}

		public Task RemoveAsync(string id)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(string id, IFormFile content)
		{
			throw new NotImplementedException();
		}
	}
}
