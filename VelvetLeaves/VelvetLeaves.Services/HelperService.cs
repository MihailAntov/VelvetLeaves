

using Microsoft.Extensions.Options;
using MongoDB.Driver;
using VelvetLeaves.Data.ObjectDatabase;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.AppPreferences;
using static VelvetLeaves.Common.ApplicationConstants;

namespace VelvetLeaves.Services
{
    public class HelperService : IHelperService
    {
        private readonly IMongoCollection<AppPreferences> _preferences;
        public HelperService( IOptions<ObjectDatabaseSettings> objectDatabaseSettings)
        {


            var mongoClient = new MongoClient(
            objectDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                objectDatabaseSettings.Value.DatabaseName);

            _preferences = mongoDatabase.GetCollection<AppPreferences>(
                objectDatabaseSettings.Value.AppPreferencesCollectionName);


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

        public async Task<AppPreferencesFormViewModel> GetCurrentPreferences()
        {

            var preferences = await _preferences.FindAsync(i=> i.Id == PreferencesKey);

            return new AppPreferencesFormViewModel();
        }

        public async Task SetCurrentPreferences(AppPreferencesFormViewModel model)
        {

            var preferences = new AppPreferences()
            {
                Id = PreferencesKey,
                BackGroundImageId = model.ImageId!,
                Currency = model.Currency,
                FavoriteColor = model.FavoriteColor,
                FavoriteIcon = model.FavoriteIcon,
                RootNavigationName = model.RootNavigationName
            };

            await _preferences.FindOneAndReplaceAsync(p => p.Id == PreferencesKey, preferences);
        }
    }
}
