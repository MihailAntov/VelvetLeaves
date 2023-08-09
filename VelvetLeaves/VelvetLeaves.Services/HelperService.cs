

using Microsoft.Extensions.Options;
using MongoDB.Driver;
using VelvetLeaves.Data.ObjectDatabase;
using VelvetLeaves.Data.ObjectDatabase.Contracts;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.AppPreferences;
using static VelvetLeaves.Common.ApplicationConstants;

namespace VelvetLeaves.Services
{
    public class HelperService : IHelperService
    {
        protected readonly IMongoCollection<AppPreferences> _preferences;
        public HelperService( IObjectDbContext context)
        {
            _preferences = context.AppPreferences;
        }

        public async Task<string> Currency()
        {
            AppPreferences preferences = await FindAsyncInCollectionFirstOrDefault();
            string currency = preferences.Currency;
            return currency;
        }

        public async Task<string> FavoriteColor()
        {
            AppPreferences preferences = await FindAsyncInCollectionFirstOrDefault();
            string color = preferences.FavoriteColor;
            return color;
        }

        public async Task<string> Description()
        {
            AppPreferences preferences = await FindAsyncInCollectionFirstOrDefault();
            string description = preferences.Description;
            return description;
        }

        public async Task<string> Background()
        {
            AppPreferences preferences = await FindAsyncInCollectionFirstOrDefault();
            string background = preferences.BackGroundImageId;
            return background;
        }

        public async Task<string> FavoriteIcon()
        {
            AppPreferences preferences = await FindAsyncInCollectionFirstOrDefault();
            string icon = preferences.FavoriteIcon;
            return icon;
        }

        public async Task<string> RootNavigationName()
        {
            AppPreferences preferences = await FindAsyncInCollectionFirstOrDefault();
            string name = preferences.RootNavigationName;
            return name;
        }

        public async Task<AppPreferencesFormViewModel> GetCurrentPreferences()
		{
			AppPreferences preferences = await FindAsyncInCollectionFirstOrDefault();
            

			return new AppPreferencesFormViewModel()
			{
				ImageId = preferences.BackGroundImageId,
				Currency = preferences.Currency,
				FavoriteColor = preferences.FavoriteColor,
				FavoriteIcon = preferences.FavoriteIcon,
				RootNavigationName = preferences.RootNavigationName,
                Description = preferences.Description
			};

		}

		protected virtual async Task<AppPreferences> FindAsyncInCollectionFirstOrDefault()=> await (await _preferences.FindAsync(i => i.Id == PreferencesKey)).FirstOrDefaultAsync();
		

		public async Task SetCurrentPreferences(AppPreferencesFormViewModel model)
		{

			var preferences = new AppPreferences()
			{
				Id = PreferencesKey,
				Currency = model.Currency,
				FavoriteColor = model.FavoriteColor,
				FavoriteIcon = model.FavoriteIcon,
				RootNavigationName = model.RootNavigationName,
                Description = model.Description
			};

			if (model.ImageId != null)
			{
				preferences.BackGroundImageId = model.ImageId;
			}

			await FindOneAndreplaceInCollection(preferences);
		}

		protected virtual async Task FindOneAndreplaceInCollection(AppPreferences preferences) => await _preferences.FindOneAndReplaceAsync(p => p.Id == PreferencesKey, preferences);

        
    }
}
