using System.ComponentModel.DataAnnotations;
using static VelvetLeaves.Common.ValidationConstants.Address;

namespace VelvetLeaves.ViewModels.Address
{
	public class AddressFormViewModel
	{
        [Required]
        [StringLength(CountryMaxLength, MinimumLength = CountryMinLength, ErrorMessage = "Must be between {1} and {1} symbols.")]
		[RegularExpression(@"[\w\-]+", ErrorMessage = "Invalid symbol in name.")]
		public string Country { get; set; } = null!;

		[Required]
		[StringLength(CityMaxLength, MinimumLength = CityMinLength, ErrorMessage = "Must be between {1} and {1} symbols.")]
		[RegularExpression(@"[\w\-]+", ErrorMessage = "Invalid symbol in name.")]
		public string City { get; set; } = null!;

		[Required]
		[StringLength(StreetAddressMaxLength, MinimumLength = StreetAddressMinLength, ErrorMessage = "Must be between {1} and {1} symbols.")]
		[RegularExpression(@"[\w\-]+", ErrorMessage = "Invalid symbol in name.")]
		public string Address { get; set; } = null!;

		[Required]
		[StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength, ErrorMessage = "Must be between {1} and {1} symbols.")]
		[RegularExpression(@"[\w\-]+", ErrorMessage = "Invalid symbol in name.")]
		public string FirstName { get; set; } = null!;

		[Required]
		[StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength, ErrorMessage = "Must be between {1} and {1} symbols.")]
		[RegularExpression(@"[\w\-]+", ErrorMessage = "Invalid symbol in name.")]
		public string LastName { get; set; } = null!;

		[Required]
        [Phone]
		[StringLength(PhoneNumberMinLength, MinimumLength = PhoneNumberMaxLength, ErrorMessage = "Must be between {1} and {1} symbols.")]
		public string PhoneNumber { get; set; } = null!;

		[StringLength(ZipCodeMaxLength, MinimumLength = ZipCodeMinLength, ErrorMessage = "Must be between {1} and {1} symbols.")]
		[RegularExpression(@"[\w\-]+", ErrorMessage = "Invalid symbol in name.")]

		public string? ZipCode { get; set; }


	}
}
