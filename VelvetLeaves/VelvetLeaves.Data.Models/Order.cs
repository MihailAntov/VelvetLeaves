
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static VelvetLeaves.Common.ValidationConstants.Address;

using VelvetLeaves.Common.Enums;

namespace VelvetLeaves.Data.Models
{
    public class Order 
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public string? UserId { get; set; } = null!;

        [Required]
        public virtual ApplicationUser? User { get; set; } = null!;

        [Required]
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();

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

        [Required]
		[MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
		[MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

		[Required]
		[MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;


        [Required]
        public OrderStatus OrderStatus { get; set; }



    }
}
