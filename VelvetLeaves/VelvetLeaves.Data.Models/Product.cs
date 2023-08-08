
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static VelvetLeaves.Common.ValidationConstants.Product;
using static VelvetLeaves.Common.ValidationConstants.Image;
using static VelvetLeaves.Common.ValidationConstants.Color;
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

        [ForeignKey(nameof(ProductSeries))]
        [Required]
        public int ProductSeriesId { get; set; }

        [Required]
        public ProductSeries ProductSeries { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }

        public virtual ICollection<OrderProduct> ProductsOrders { get; set; } = new HashSet<OrderProduct>();

        public virtual ICollection<Color> Colors { get; set; } = new HashSet<Color>();

        public virtual ICollection<Material> Materials { get; set; } = new HashSet<Material>();
        public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
        public virtual ICollection<Image> Images { get; set; } = new HashSet<Image>();


        public bool IsActive { get; set; } = true;

        public bool IsAvailable { get; set; } = true;
    }
}
