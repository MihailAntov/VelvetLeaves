﻿

using System.ComponentModel.DataAnnotations;
using VelvetLeaves.Common.Validation;
using VelvetLeaves.ViewModels.Address;
using static VelvetLeaves.Common.ValidationConstants.Address;

namespace VelvetLeaves.ViewModels.Checkout
{
	public class CheckoutFormViewModel
	{
		[Required]
		public IList<CheckoutItemViewModel> Items { get; set; } = null!;

		[Required]
		[StringLength(CountryMaxLength, MinimumLength = CountryMinLength, ErrorMessage = "Must be between {2} and {1} symbols.")]
		[DataType(DataType.Text)]
		[SanitizeStringInput]
		public string Country { get; set; } = null!;

		[Required]
		[StringLength(CityMaxLength, MinimumLength = CityMinLength, ErrorMessage = "Must be between {2} and {1} symbols.")]
		[DataType(DataType.Text)]
		[SanitizeStringInput]
		public string City { get; set; } = null!;

		[Required]
		[StringLength(StreetAddressMaxLength, MinimumLength = StreetAddressMinLength, ErrorMessage = "Must be between {2} and {1} symbols.")]
		[DataType(DataType.Text)]
		[SanitizeStringInput]
		public string Address { get; set; } = null!;

		[Required]
		[StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength, ErrorMessage = "Must be between {2} and {1} symbols.")]
		[DataType(DataType.Text)]
		[SanitizeStringInput]
		public string FirstName { get; set; } = null!;

		[Required]
		[StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength, ErrorMessage = "Must be between {2} and {1} symbols.")]
		[DataType(DataType.Text)]
		[SanitizeStringInput]
		public string LastName { get; set; } = null!;

		[Required]
        [Phone]
		[SanitizeStringInput]
		[DataType(DataType.PhoneNumber)]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength, ErrorMessage = "Must be between {2} and {1} symbols.")]
		public string PhoneNumber { get; set; } = null!;

		[StringLength(ZipCodeMaxLength, MinimumLength = ZipCodeMinLength, ErrorMessage = "Must be between {2} and {1} symbols.")]
		[DataType(DataType.Text)]
		[SanitizeStringInput]
		public string? ZipCode { get; set; }


        [DataType(DataType.EmailAddress)]
        [EmailAddress]
		[SanitizeStringInput]
		public string? Email { get; set; } = null!;
	}
}
