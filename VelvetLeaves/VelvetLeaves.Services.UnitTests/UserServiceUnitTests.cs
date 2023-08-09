

using Microsoft.AspNetCore.Identity;
using Moq;
using VelvetLeaves.Data.Models;
using VelvetLeaves.Services.Contracts;

namespace VelvetLeaves.Services.UnitTests
{
    [TestFixture]
    public class UserServiceUnitTests
    {
        private IUserService _userService;
        private Mock<UserManager<ApplicationUser>> _mockUserManager;
        private Mock<RoleManager<IdentityRole>> _mockRoleManager;

        [SetUp]
        public void Setup()
        {
            // Create an in-memory database context (if applicable)
            var store = new Mock<IUserStore<ApplicationUser>>();
            var roleValidator = new Mock<IRoleValidator<IdentityRole>>();
            _mockUserManager = new Mock<UserManager<ApplicationUser>>(store.Object, null, null, null, null, null, null, null, null); // ?!?!
            _mockRoleManager = new Mock<RoleManager<IdentityRole>>(Mock.Of<IRoleStore<IdentityRole>>(), null, null, null, null); // ?!?!
            _userService = new UserService(_mockUserManager.Object, _mockRoleManager.Object);
        }
        
        [Test]
        public async Task TestMakeAdminAsync()
        {
            // Create a test user
            var userId = "testUserId";
            var user = new ApplicationUser { Id = userId };

            // Setup mocks
            _mockUserManager.Setup(u => u.FindByIdAsync(userId)).ReturnsAsync(user);

            // Call the service method
            await _userService.MakeAdminAsync(userId);

            // Assert that the user is added to the admin role
            _mockUserManager.Verify(u => u.AddToRoleAsync(user, "Admin"), Times.Once);
        }

        [Test]
        public async Task TestMakeModeratorAsync()
        {
            // Arrange
            var userId = "testUserId";
            var user = new ApplicationUser { Id = userId };

            _mockUserManager.Setup(u => u.FindByIdAsync(userId)).ReturnsAsync(user);

            // Set up UserManager to call the actual implementation of AddToRoleAsync
            

            _mockRoleManager.CallBase = true; // Enable calling the base class methods

            _userService = new UserService(_mockUserManager.Object, _mockRoleManager.Object);

            // Act
            await _userService.MakeModeratorAsync(userId);

            // Assert
            _mockRoleManager.Verify(r => r.CreateAsync(It.IsAny<IdentityRole>()), Times.Once);
        }

        [Test]
        public async Task TestGetFormForPromoteAsync()
        {
            // Arrange
            var currentUserId = "currentUserId";
            var mockUserList = new List<ApplicationUser>
    {
        new ApplicationUser { Id = "currentUserId", Email = "user1@example.com", UserName = "user1" },
        new ApplicationUser { Id = "user2", Email = "user2@example.com", UserName = "user2" }
    };

            _mockUserManager.Setup(u => u.Users).Returns(mockUserList.AsQueryable());

            _mockUserManager.Setup(u => u.FindByIdAsync(It.IsAny<string>()))
                           .ReturnsAsync((string userId) => mockUserList.FirstOrDefault(u => u.Id == userId));
            _mockUserManager.Setup(u => u.IsInRoleAsync(It.IsAny<ApplicationUser>(), "Moderator"))
                           .ReturnsAsync(false);
            _mockUserManager.Setup(u => u.IsInRoleAsync(It.IsAny<ApplicationUser>(), "Admin"))
                           .ReturnsAsync(false);

            var userService = new UserService(_mockUserManager.Object, _mockRoleManager.Object);

            // Act
            var result = await userService.GetFormForPromoteAsync(currentUserId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count()); // Only user2 should be in the list
            var userPromoteViewModel = result.First();
            Assert.AreEqual("user2@example.com", userPromoteViewModel.Email);
            Assert.AreEqual("user2", userPromoteViewModel.Username);
            Assert.AreEqual("user2", userPromoteViewModel.UserId);
            Assert.IsFalse(userPromoteViewModel.IsModerator);
            Assert.IsFalse(userPromoteViewModel.IsAdmin);
        }

        [Test]
        public async Task TestRemoveModeratorAsync()
        {
            // Arrange
            var userId = "testUserId";
            var user = new ApplicationUser { Id = userId };

            _mockUserManager.Setup(u => u.FindByIdAsync(userId)).ReturnsAsync(user);

            var userService = new UserService(_mockUserManager.Object, _mockRoleManager.Object);

            // Act
            await userService.RemoveModeratorAsync(userId);

            // Assert
            _mockUserManager.Verify(u => u.RemoveFromRoleAsync(user, "Moderator"), Times.Once);
        }

        [TearDown]
        public void Teardown()
        {
            // Clean up any resources if needed
        }
    }
}
