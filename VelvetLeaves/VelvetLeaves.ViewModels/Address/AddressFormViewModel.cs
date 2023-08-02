﻿namespace VelvetLeaves.ViewModels.Address
{
	public class AddressFormViewModel
	{
		public string Country { get; set; } = null!;
		public string City { get; set; } = null!;
		public string Address { get; set; } = null!;

		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;

		public string PhoneNumber { get; set; } = null!;

		public string? ZipCode { get; set; }


	}
}