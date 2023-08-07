using System.ComponentModel.DataAnnotations;
using VelvetLeaves.Common.Validation;
using static VelvetLeaves.Common.ValidationConstants.Address;
using static VelvetLeaves.Common.ValidationConstants.Common;

namespace VelvetLeaves.ViewModels.Address
{
	public class AddressFormViewModel
	{
        [Required]
        [StringLength(CountryMaxLength, MinimumLength = CountryMinLength, ErrorMessage = "Must be between {1} and {1} symbols.")]
		[SanitizeStringInput]
		public string Country { get; set; } = null!;

		[Required]
		[StringLength(CityMaxLength, MinimumLength = CityMinLength, ErrorMessage = "Must be between {1} and {1} symbols.")]
		[SanitizeStringInput]
		public string City { get; set; } = null!;

		[Required]
		[StringLength(StreetAddressMaxLength, MinimumLength = StreetAddressMinLength, ErrorMessage = "Must be between {1} and {1} symbols.")]
		[SanitizeStringInput]
		public string Address { get; set; } = null!;

		[Required]
		[StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength, ErrorMessage = "Must be between {1} and {1} symbols.")]
		[SanitizeStringInput]
		public string FirstName { get; set; } = null!;

		[Required]
		[StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength, ErrorMessage = "Must be between {1} and {1} symbols.")]
		[SanitizeStringInput]
		public string LastName { get; set; } = null!;

		[Required]
        [Phone]
        [RegularExpression(PhoneRegex)]
		[StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength, ErrorMessage = "Must be between {1} and {1} symbols.")]
		public string PhoneNumber { get; set; } = null!;

		[StringLength(ZipCodeMaxLength, MinimumLength = ZipCodeMinLength, ErrorMessage = "Must be between {1} and {1} symbols.")]
		[SanitizeStringInput]

		public string? ZipCode { get; set; }


	}
}
