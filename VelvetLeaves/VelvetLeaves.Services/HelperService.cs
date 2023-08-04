

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
            var references = await (await _preferences.FindAsync(p => p.Id == PreferencesKey)).FirstOrDefaultAsync();
            string currency = references.Currency;
            return currency;
        }

        public async Task<string> FavoriteColor()
        {
            var references = await (await _preferences.FindAsync(p => p.Id == PreferencesKey)).FirstOrDefaultAsync();
            string color = references.FavoriteColor;
            return color;
        }

        public async Task<string> Background()
        {
            var references = await (await _preferences.FindAsync(p => p.Id == PreferencesKey)).FirstOrDefaultAsync();
            string background = references.BackGroundImageId;
            return background;
        }

        public async Task<string> FavoriteIcon()
        {
            var references = await (await _preferences.FindAsync(p => p.Id == PreferencesKey)).FirstOrDefaultAsync();
            string icon = references.FavoriteIcon;
            return icon;
        }

        public async Task<string> RootNavigationName()
        {
            var references = await(await _preferences.FindAsync(p => p.Id == PreferencesKey)).FirstOrDefaultAsync();
            string name = references.RootNavigationName;
            return name;
        }

        public async Task<AppPreferencesFormViewModel> GetCurrentPreferences()
        {

            var preferences = await (await _preferences.FindAsync(i => i.Id == PreferencesKey)).FirstOrDefaultAsync();

            return new AppPreferencesFormViewModel()
            {
                ImageId = preferences.BackGroundImageId,
                Currency = preferences.Currency,
                FavoriteColor = preferences.FavoriteColor,
                FavoriteIcon = preferences.FavoriteIcon,
                RootNavigationName = preferences.RootNavigationName
            };

        }

        public async Task SetCurrentPreferences(AppPreferencesFormViewModel model)
        {

            var preferences = new AppPreferences()
            {
                Id = PreferencesKey,
                Currency = model.Currency,
                FavoriteColor = model.FavoriteColor,
                FavoriteIcon = model.FavoriteIcon,
                RootNavigationName = model.RootNavigationName
            };

            if(model.ImageId != null)
            {
                preferences.BackGroundImageId = model.ImageId;
            }

            await _preferences.FindOneAndReplaceAsync(p => p.Id == PreferencesKey, preferences);
        }

        
    }
}
