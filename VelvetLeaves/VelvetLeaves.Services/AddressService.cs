

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
			//var options = _context
			//	.Addresses
			//	.Where(a=> a.Us.Id == userId)
			//	.Select(u=> )

			throw new NotImplementedException();
		}
	}
}
