
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static VelvetLeaves.Common.ValidationConstants.Product;
using static VelvetLeaves.Common.ValidationConstants.Image;
using System.Drawing;

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

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; } = new HashSet<ApplicationUser>();

        [ForeignKey(nameof(Subcategory))]
        public int SubcategoryId { get; set; }
        [Required]
        public Subcategory Subcategory { get; set; } = null!;

        [Required]
        [MaxLength(UrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();


        public string? Color { get; set; }

        
    }
}
