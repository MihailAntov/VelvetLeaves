

using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data;
using VelvetLeaves.Data.Models;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Address;

namespace VelvetLeaves.Services
{
	public class AddressService : IAddressService
	{
		private readonly VelvetLeavesDbContext _context;
		public AddressService(VelvetLeavesDbContext context)
		{
			_context = context;
		}

		public async Task AddAsync(AddressFormViewModel model, string userId)
		{
			var address = new Address()
			{
				City = model.City,
				Country = model.Country,
				StreetAddress = model.Address,
				ZipCode = model.ZipCode,
				FirstName = model.FirstName,
				LastName = model.LastName,
				PhoneNumber = model.PhoneNumber,
				UserId = userId,
			};

			await _context.Addresses.AddAsync(address);
			await _context.SaveChangesAsync();
		}

		public async Task<AddressFormViewModel?> GetAddressByIdAsync(string addressId)
		{
			var address = await  _context.Addresses
				.Where(a => a.Id.ToString() == addressId)
				.Select(a => new AddressFormViewModel()
				{
					
					Address = a.StreetAddress,
					City = a.City,
					Country = a.Country,
					ZipCode = a.ZipCode,
					FirstName = a.FirstName,
					PhoneNumber = a.PhoneNumber,
					LastName = a.LastName
				}).FirstOrDefaultAsync();


			return address;
		}

		public async Task<IEnumerable<AddressListViewModel>> GetAddressOptionsAsync(string userId)
		{
			var options = await _context
				.Addresses
				.Where(a => a.UserId == userId)
				.Select(a => new AddressListViewModel()
				{
					Id = a.Id.ToString(),
					City = a.City,
					Country = a.Country,
					StreetAddress = a.StreetAddress,
					ZipCode = a.ZipCode
				}).ToArrayAsync();

			return options;



		}

		public async Task UpdateAsync(string id, AddressFormViewModel model)
		{
			var address = await _context
				.Addresses
				.Where(a => a.Id.ToString() == id)
				.FirstAsync();

			address.FirstName = model.FirstName;
			address.LastName = model.LastName;
			address.PhoneNumber = model.PhoneNumber;
			address.City = model.City;
			address.Country = model.Country;
			address.ZipCode = model.ZipCode;

			await _context.SaveChangesAsync();


		}
	}
}
