
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

        
        public int? ZipCode { get; set; }

		[ForeignKey(nameof(User))]
		[Required]
        public string UserId { get; set; } = null!;

        [Required]
        public ApplicationUser User { get; set; } = null!;
    }
}
