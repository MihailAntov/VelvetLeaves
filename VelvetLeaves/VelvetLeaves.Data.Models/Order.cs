
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string UserId { get; set; } = null!;

        [Required]
        public virtual ApplicationUser User { get; set; } = null!;

        [Required]
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();

        [Required]
        [ForeignKey(nameof(Address))]
        public Guid AddressId { get; set; } 
        
        [Required]
        public Address Address { get; set; } = null!;

        [Required]
        public OrderStatus OrderStatus { get; set; }



    }
}
