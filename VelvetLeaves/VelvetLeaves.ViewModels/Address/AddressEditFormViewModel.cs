﻿

namespace VelvetLeaves.ViewModels.Address
{
	public class AddressEditFormViewModel
	{
		public string Id { get; set; }
		public string Country { get; set; } = null!;
		public string City { get; set; } = null!;
		public string Address { get; set; } = null!;

		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;

		public string PhoneNumber { get; set; } = null!;

		public string? ZipCode { get; set; }
	}
}
