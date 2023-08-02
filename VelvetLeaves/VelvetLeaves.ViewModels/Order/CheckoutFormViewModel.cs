

using System.ComponentModel.DataAnnotations;
using VelvetLeaves.ViewModels.Address;

namespace VelvetLeaves.ViewModels.Order
{
	public class CheckoutFormViewModel
    {
        [Required]
        public IList<CheckoutItemViewModel> Items { get; set; } = null!;

        [Required]
        public string Country { get; set; } = null!;

        [Required]
        public string City { get; set; } = null!;

        [Required]
        public string Address { get; set; } = null!;

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;

        public string? ZipCode { get; set; }


        public string? Email { get; set; } = null!;
    }
}
