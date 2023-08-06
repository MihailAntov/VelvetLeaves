

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using VelvetLeaves.Data;
using VelvetLeaves.Data.Models;
using VelvetLeaves.ViewModels.Address;

namespace VelvetLeaves.Services.UnitTests
{
    [TestFixture]
    public class AddressServiceUnitTests
    {
        private VelvetLeavesDbContext _dbContext;
        private Mock<ILogger<AddressService>> _mockLogger;
        private ILogger<AddressService> _logger;
        private AddressService _addressService;


        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<VelvetLeavesDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _dbContext = new VelvetLeavesDbContext(options);
            _mockLogger = new Mock<ILogger<AddressService>>();
            _logger = _mockLogger.Object;
            _addressService = new AddressService(_dbContext, _logger);
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Dispose();
        }

        [Test]
        public async Task AddAsync_ShouldAddAddressToDatabase()
        {
            // Arrange
            var model = new AddressFormViewModel
            {
                City = "Test City",
                Country = "Test Country",
                Address = "Test Address",
                FirstName = "Test First Name",
                LastName = "Test Last Name",
                PhoneNumber = "Test Phone",
                ZipCode = "Test ZipCode"
            };
            var userId = "test-user-id";

            // Act
            await _addressService.AddAsync(model, userId);

            // Assert
            var address = await _dbContext.Addresses.FirstOrDefaultAsync(a => a.UserId == userId);
            Assert.NotNull(address);
            Assert.AreEqual(model.City, address.City);
            Assert.AreEqual(model.Country, address.Country);
            Assert.AreEqual(model.Address, address.StreetAddress);
            Assert.AreEqual(model.FirstName, address.FirstName);
            Assert.AreEqual(model.LastName, address.LastName);
            Assert.AreEqual(model.PhoneNumber, address.PhoneNumber);
            Assert.AreEqual(model.ZipCode, address.ZipCode);
        }

        [Test]
        public async Task GetAddressByIdAsync_ShouldReturnCorrectAddress()
        {
            // Arrange
            var addressId = Guid.NewGuid().ToString();
            var address = new Address
            {
                Id = Guid.Parse(addressId),
                City = "Test City",
                Country = "Test Country",
                StreetAddress = "Test Address",
                FirstName = "Test First Name",
                LastName = "Test Last Name",
                PhoneNumber = "Test Phone",
                ZipCode = "Test ZipCode",
                UserId = "test-user-id"
            };
            _dbContext.Addresses.Add(address);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _addressService.GetAddressByIdAsync(addressId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(address.City, result.City);
            Assert.AreEqual(address.Country, result.Country);
            Assert.AreEqual(address.StreetAddress, result.Address);
            Assert.AreEqual(address.FirstName, result.FirstName);
            Assert.AreEqual(address.LastName, result.LastName);
            Assert.AreEqual(address.PhoneNumber, result.PhoneNumber);
            Assert.AreEqual(address.ZipCode, result.ZipCode);
        }

        [Test]
        public async Task GetAddressByIdAsync_ShouldThrowExceptionIfAddressNotFound()
        {
            // Arrange
            var addressId = Guid.NewGuid().ToString();

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _addressService.GetAddressByIdAsync(addressId));
        }

        [Test]
        public async Task GetAddressOptionsAsync_ShouldReturnAddressesForUser()
        {
            // Arrange
            var userId = "test-user-id";
            var address1 = new Address
            {
                Id = Guid.NewGuid(),
                City = "Test City 1",
                Country = "Test Country 1",
                StreetAddress = "Test Address 1",
                ZipCode = "Test ZipCode 1",
                FirstName = "Test",
                LastName = "Testovich",
                PhoneNumber = "12345678",
                UserId = userId
            };
            var address2 = new Address
            {
                Id = Guid.NewGuid(),
                City = "Test City 2",
                Country = "Test Country 2",
                StreetAddress = "Test Address 2",
                ZipCode = "Test ZipCode 2",
                FirstName = "Test the 2nd",
                LastName = "Of the Tests",
                PhoneNumber = "999999999",
                UserId = userId
            };
            _dbContext.Addresses.RemoveRange(_dbContext.Addresses);
            _dbContext.Addresses.AddRange(address1, address2);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _addressService.GetAddressOptionsAsync(userId);

            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.Any(a => a.Id == address1.Id.ToString()));
            Assert.IsTrue(result.Any(a => a.Id == address2.Id.ToString()));
        }

        [Test]
        public async Task UpdateAsync_ShouldUpdateAddressInDatabase()
        {
            // Arrange
            var addressId = Guid.NewGuid().ToString();
            var address = new Address
            {
                Id = Guid.Parse(addressId),
                City = "Old City",
                Country = "Old Country",
                StreetAddress = "Old Address",
                FirstName = "Old First Name",
                LastName = "Old Last Name",
                PhoneNumber = "Old Phone",
                ZipCode = "Old ZipCode",
                UserId = "test-user-id"
            };
            _dbContext.Addresses.Add(address);
            await _dbContext.SaveChangesAsync();

            var model = new AddressFormViewModel
            {
                City = "New City",
                Country = "New Country",
                Address = "New Address",
                FirstName = "New First Name",
                LastName = "New Last Name",
                PhoneNumber = "New Phone",
                ZipCode = "New ZipCode"
            };

            // Act
            await _addressService.UpdateAsync(addressId, model);

            // Assert
            var updatedAddress = await _dbContext.Addresses.FirstOrDefaultAsync(a => a.Id.ToString() == addressId);
            Assert.NotNull(updatedAddress);
            Assert.AreEqual(model.City, updatedAddress.City);
            Assert.AreEqual(model.Country, updatedAddress.Country);
            Assert.AreEqual(model.Address, updatedAddress.StreetAddress);
            Assert.AreEqual(model.FirstName, updatedAddress.FirstName);
            Assert.AreEqual(model.LastName, updatedAddress.LastName);
            Assert.AreEqual(model.PhoneNumber, updatedAddress.PhoneNumber);
            Assert.AreEqual(model.ZipCode, updatedAddress.ZipCode);
        }

        [Test]
        public async Task UpdateAsync_ShouldThrowExceptionIfAddressNotFound()
        {
            // Arrange
            var addressId = Guid.NewGuid().ToString();
            var model = new AddressFormViewModel
            {
                City = "New City",
                Country = "New Country",
                Address = "New Address",
                FirstName = "New First Name",
                LastName = "New Last Name",
                PhoneNumber = "New Phone",
                ZipCode = "New ZipCode"
            };

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _addressService.UpdateAsync(addressId, model));
        }
    }
}
