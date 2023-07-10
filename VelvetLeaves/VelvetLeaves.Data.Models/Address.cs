
using System.ComponentModel.DataAnnotations;

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

        [Required]
        public int ZipCode { get; set; }
    }
}
