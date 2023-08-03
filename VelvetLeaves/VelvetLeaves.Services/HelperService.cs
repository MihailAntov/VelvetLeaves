

using MongoDB.Driver;
using VelvetLeaves.Data.Models;
using VelvetLeaves.Services.Contracts;

namespace VelvetLeaves.Services
{
    public class HelperService : IHelperService
    {
        private readonly IMongoCollection<AppPreferences> _preferences;
        public HelperService( IOptions<ImageDatabaseSettings> imageDatabaseSettings)
        {


            var mongoClient = new MongoClient(
            imageDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                imageDatabaseSettings.Value.DatabaseName);

            _imagesCollection = mongoDatabase.GetCollection<Image>(
                imageDatabaseSettings.Value.ImagesCollectionName);


        }

        public async Task<string> Currency()
        {
            return "лв.";
        }

        public async Task<string> FavoriteColor()
        {
            return "gold";
        }

        public async Task<string> FavoriteIcon()
        {
            return "star";
        }
    }
}
