
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static VelvetLeaves.Common.ValidationConstants.Address;


namespace VelvetLeaves.Data.Models
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(CountryMaxLength)]
        public string Country { get; set; } = null!;

        [Required]
        [MaxLength(CityMaxLength)]
        public string City { get; set; } = null!;

        [Required]
        [MaxLength(StreetAddressMaxLength)]
        public string StreetAddress { get; set; } = null!;

		[MaxLength(ZipCodeMaxLength)]
        public string? ZipCode { get; set; }

		[ForeignKey(nameof(User))]
        public string? UserId { get; set; } = null!;

        public ApplicationUser? User { get; set; } = null!;

        [Required]
        [MaxLength(FirstNameMaxLength)]

        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]

        public string LastName { get; set; } = null!;

        [Required]
		[MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;
    }
}
