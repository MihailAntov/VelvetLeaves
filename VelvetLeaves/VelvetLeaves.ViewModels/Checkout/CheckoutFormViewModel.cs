

using System.ComponentModel.DataAnnotations;
using VelvetLeaves.Common.Validation;
using VelvetLeaves.ViewModels.Address;

namespace VelvetLeaves.ViewModels.Checkout
{
	public class CheckoutFormViewModel
	{
		[Required]
		public IList<CheckoutItemViewModel> Items { get; set; } = null!;

		[Required]
		[SanitizeStringInput]
		public string Country { get; set; } = null!;

		[Required]
		[SanitizeStringInput]
		public string City { get; set; } = null!;

		[Required]
		[SanitizeStringInput]
		public string Address { get; set; } = null!;

		[Required]
		[SanitizeStringInput]
		public string FirstName { get; set; } = null!;

		[Required]
		[SanitizeStringInput]
		public string LastName { get; set; } = null!;

		[Required]
        [Phone]
		[SanitizeStringInput]
		[DataType(DataType.PhoneNumber)]
		public string PhoneNumber { get; set; } = null!;

        [DataType(DataType.PostalCode)]
		[SanitizeStringInput]
		public string? ZipCode { get; set; }


        [DataType(DataType.EmailAddress)]
		[SanitizeStringInput]
		public string? Email { get; set; } = null!;
	}
}
