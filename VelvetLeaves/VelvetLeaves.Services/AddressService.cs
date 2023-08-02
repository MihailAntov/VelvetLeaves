

using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data;
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
	}
}
