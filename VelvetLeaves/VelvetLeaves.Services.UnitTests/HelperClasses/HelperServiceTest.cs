

using VelvetLeaves.Data.ObjectDatabase;
using VelvetLeaves.Data.ObjectDatabase.Contracts;
using static VelvetLeaves.Common.ApplicationConstants;

namespace VelvetLeaves.Services.UnitTests.HelperClasses
{
	public class HelperServiceTest : HelperService
	{
		private AppPreferences _appPreferences;
		public HelperServiceTest(IObjectDbContext context) : base(context)
		{
			_appPreferences = new AppPreferences
			{
				Id = PreferencesKey,
				BackGroundImageId = "bgImageId",
				Currency = "USD",
				FavoriteColor = "Blue",
				FavoriteIcon = "star",
				RootNavigationName = "Main"
			};
		}

		protected override Task<AppPreferences> FindAsyncInCollectionFirstOrDefault()
		{
			//var preferences = new AppPreferences
			//{
			//	Id = PreferencesKey,
			//	BackGroundImageId = "bgImageId",
			//	Currency = "USD",
			//	FavoriteColor = "Blue",
			//	FavoriteIcon = "star",
			//	RootNavigationName = "Main"
			//};

			return Task.FromResult(_appPreferences);
		}

		protected override Task FindOneAndreplaceInCollection(AppPreferences preferences)
		{
			_appPreferences = preferences;
			return Task.CompletedTask;
		}
	}
}
