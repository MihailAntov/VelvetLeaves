
using System.ComponentModel.DataAnnotations;
using static VelvetLeaves.Common.ValidationConstants.Product;

namespace VelvetLeaves.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public virtual ICollection<ApplicationUser>? ApplicationUsers { get; set; }

        

    }
}
