using Microsoft.Extensions.Options;
using MongoDB.Driver;
using VelvetLeaves.Data.ObjectDatabase.Contracts;

namespace VelvetLeaves.Data.ObjectDatabase
{
	public class ObjectDbContext : IObjectDbContext
	{
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }

        public ObjectDbContext(IOptions<ObjectDatabaseSettings> configuration)
        {
            _mongoClient = new MongoClient(configuration.Value.ConnectionString);
            
            _db = _mongoClient.GetDatabase(configuration.Value.DatabaseName);

            Images = _db.GetCollection<Image>(configuration.Value.ImagesCollectionName);
            AppPreferences = _db.GetCollection<AppPreferences>(configuration.Value.AppPreferencesCollectionName);
            
        }

        public IMongoCollection<Image> Images { get; set; }
        public IMongoCollection<AppPreferences> AppPreferences { get; set; }

        
    }
}
