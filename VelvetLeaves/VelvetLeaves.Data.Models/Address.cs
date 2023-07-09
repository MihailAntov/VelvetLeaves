using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelvetLeaves.Data.Models
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Country { get; set; } = null!;

        [Required]
        public string City { get; set; } = null!;

        [Required]
        public string StreetAddress { get; set; } = null!;

        [Required]
        public int ZipCode { get; set; }
    }
}
