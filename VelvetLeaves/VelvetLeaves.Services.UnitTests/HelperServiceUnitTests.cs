

using MongoDB.Driver;
using Moq;
using VelvetLeaves.Data.ObjectDatabase;
using VelvetLeaves.Data.ObjectDatabase.Contracts;
using VelvetLeaves.Services.UnitTests.HelperClasses;
using VelvetLeaves.ViewModels.AppPreferences;
using static VelvetLeaves.Common.ApplicationConstants;

namespace VelvetLeaves.Services.UnitTests
{
	public class HelperServiceUnitTests
	{
        private Mock<IObjectDbContext> _mockContext;
        private HelperService _helperService;
        private Mock<IMongoCollection<AppPreferences>> _mockCollection;

		public HelperServiceUnitTests()
		{
            _mockContext = new Mock<IObjectDbContext>();
            _mockCollection = new Mock<IMongoCollection<AppPreferences>>();
            _mockContext.Setup(context => context.AppPreferences).Returns(_mockCollection.Object);
            _helperService = new HelperServiceTest(_mockContext.Object);
           
		}

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task GetCurrentPreferences_PreferencesExist_ReturnsViewModel()
        {
            // Arrange
            var preferences = new AppPreferences
            {
                Id = PreferencesKey,
                BackGroundImageId = "bgImageId",
                Currency = "USD",
                FavoriteColor = "Blue",
                FavoriteIcon = "star",
                RootNavigationName = "Main"
            };

            // Act
            var result = await _helperService.GetCurrentPreferences();

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(preferences.BackGroundImageId, result.ImageId);
            Assert.AreEqual(preferences.Currency, result.Currency);
            Assert.AreEqual(preferences.FavoriteColor, result.FavoriteColor);
            Assert.AreEqual(preferences.FavoriteIcon, result.FavoriteIcon);
            Assert.AreEqual(preferences.RootNavigationName, result.RootNavigationName);
        }

        [Test]
        public async Task SetCurrentPreferences_ModelWithImageId_CallsFindOneAndReplace()
        {
            // Arrange
            var model = new AppPreferencesFormViewModel
            {
                ImageId = "bgImageId",
                Currency = "USD",
                FavoriteColor = "Blue",
                FavoriteIcon = "star",
                RootNavigationName = "Main"
            };

            var preferences = new AppPreferences
            {
                Id = PreferencesKey,
                Currency = model.Currency,
                FavoriteColor = model.FavoriteColor,
                FavoriteIcon = model.FavoriteIcon,
                RootNavigationName = model.RootNavigationName,
                BackGroundImageId = model.ImageId
            };

            _mockContext.Setup(context => context.AppPreferences)
                .Returns(_mockCollection.Object);

            

            // Act
            await _helperService.SetCurrentPreferences(model);

            await _helperService.SetCurrentPreferences(model);

            var currentPreferences = await _helperService.GetCurrentPreferences();

            Assert.AreEqual(currentPreferences.FavoriteIcon, model.FavoriteIcon);
            Assert.AreEqual(currentPreferences.FavoriteColor, model.FavoriteColor);
            Assert.AreEqual(currentPreferences.RootNavigationName, model.RootNavigationName);
            Assert.AreEqual(currentPreferences.ImageId, model.ImageId);
            Assert.AreEqual(currentPreferences.Currency, model.Currency);

        }

        [Test]
        public async Task SetCurrentPreferences_ModelWithoutImageId_CallsFindOneAndReplace()
        {
            // Arrange
            var model = new AppPreferencesFormViewModel
            {
                ImageId = null, // No image ID
                Currency = "USD",
                FavoriteColor = "Blue",
                FavoriteIcon = "star",
                RootNavigationName = "Main"
            };

            var preferences = new AppPreferences
            {
                Id = PreferencesKey,
                Currency = model.Currency,
                FavoriteColor = model.FavoriteColor,
                FavoriteIcon = model.FavoriteIcon,
                RootNavigationName = model.RootNavigationName,
                BackGroundImageId = null // No image ID
            };



            

            // Act
            await _helperService.SetCurrentPreferences(model);

            var currentPreferences = await _helperService.GetCurrentPreferences();

            Assert.AreEqual(currentPreferences.FavoriteIcon, model.FavoriteIcon);
            Assert.AreEqual(currentPreferences.FavoriteColor, model.FavoriteColor);
            Assert.AreEqual(currentPreferences.RootNavigationName, model.RootNavigationName);
            Assert.AreEqual(currentPreferences.ImageId, model.ImageId);
            Assert.AreEqual(currentPreferences.Currency, model.Currency);
            
        }

        [Test]
        public async Task GetBackGround_ReturnsCorrectValue()
		{
            string background = "bgImageId";
            string currency = "USD";
            string favoriteColor = "Blue";
            string favoriteIcon = "star";
            string rootNavigationName = "Main";
            var result = await _helperService.Background();
            Assert.AreEqual(result, background);

        }

        [Test]
        public async Task GetCurrency_ReturnsCorrectValue()
        {
            string currency = "USD";
            var result = await _helperService.Currency();
            Assert.AreEqual(result, currency);

        }

        [Test]
        public async Task GetFavoriteColor_ReturnsCorrectValue()
        {
            string favoriteColor = "Blue";
            var result = await _helperService.FavoriteColor();
            Assert.AreEqual(result, favoriteColor);

        }

        [Test]
        public async Task GetFavoriteIcon_ReturnsCorrectValue()
        {
            string favoriteIcon = "star";
            var result = await _helperService.FavoriteIcon();
            Assert.AreEqual(result, favoriteIcon);

        }

        [Test]
        public async Task GetRootNavigationName_ReturnsCorrectValue()
        {
            
            string rootNavigationName = "Main";
            var result = await _helperService.RootNavigationName();
            Assert.AreEqual(result, rootNavigationName);

        }




    }
}
