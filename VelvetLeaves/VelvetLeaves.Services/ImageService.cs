
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using VelvetLeaves.Data.Configuration;
using VelvetLeaves.Data.ObjectDatabase;
using VelvetLeaves.Services.Contracts;

namespace VelvetLeaves.Services
{
    public class ImageService : IImageService
    {
        
        private readonly IMongoCollection<Image> _imagesCollection;
        private readonly IMongoCollection<AppPreferences> _appPreferences;
        public ImageService(IOptions<ObjectDatabaseSettings> objectDatabaseSettings)
        {
            

            var mongoClient = new MongoClient(
            objectDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                objectDatabaseSettings.Value.DatabaseName);

            _imagesCollection = mongoDatabase.GetCollection<Image>(
                objectDatabaseSettings.Value.ImagesCollectionName);

            _appPreferences = mongoDatabase.GetCollection<AppPreferences>(
                objectDatabaseSettings.Value.AppPreferencesCollectionName);


        }

		public async Task<string?> CreateAsync(IFormFile content)
		{
            
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

		public async Task CreateFromStringAsync(string id, string content)
		{


            await _imagesCollection.FindOneAndDeleteAsync(i => i.Id == id);

            await _imagesCollection.InsertOneAsync(new Image { Id = id, Content = content });
            
		}

        public async Task<IEnumerable<string?>> CreateRangeAsync(IEnumerable<IFormFile> files)
        {
            var results = new List<string?>();
            
            foreach(var file in files)
            {
                string? id = null;
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);

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

                results.Add(id);
            }

            return results;
        }



		public async Task<string?> GetAsync(string id)
		{
            var result = await ((await _imagesCollection.FindAsync(i=>i.Id == id)).ToListAsync());
            var image = result.FirstOrDefault();
            if(image != null)
			{
                return image.Content;
			}
            return null;
		}

		public async Task RemoveAsync(string id)
		{
            await _imagesCollection.FindOneAndDeleteAsync(i=> i.Id == id);
		}

		public async Task UpdateAsync(string id, IFormFile content)
		{
            using (var memoryStream = new MemoryStream())
            {
                await content.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    Image image = new Image()
                    {
                        Id = id,
                        Content = Convert.ToBase64String(memoryStream.ToArray())
                    };
                    

                    var result =  await _imagesCollection.ReplaceOneAsync(i=> i.Id == id, image);
                    if(result.ModifiedCount == 0)
					{
                        await _imagesCollection.InsertOneAsync(image);
					}
                }

            }
        }
	}
}
