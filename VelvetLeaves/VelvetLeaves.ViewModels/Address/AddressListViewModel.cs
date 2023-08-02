

namespace VelvetLeaves.ViewModels.Address
{
	public class AddressListViewModel
	{
		public string Id { get; set; } = null!;
		public string Country { get; set; } = null!;
		public string City { get; set; } = null!;
		public string StreetAddress { get; set; } = null!;
		public string? ZipCode { get; set; }
	}
}
