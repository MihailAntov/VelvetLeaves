using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VelvetLeaves.Common;

namespace VelvetLeaves.Data.Models
{
    public class ProductSeries 
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(ValidationConstants.ProductSeries.NameMaxLength)]
        [Required]
        public string Name { get; set; } = null!;
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();

        [MaxLength(ValidationConstants.Product.DescriptionMaxLength)]
        [Required]
        public string DefaultDescription { get; set; } = null!;
        public decimal DefaultPrice { get; set; }

        [MaxLength(ValidationConstants.Product.NameMaxLength)]
        [Required]
        public string DefaultName { get; set; } = null!;

        public virtual ICollection<Material> DefaultMaterials { get; set; } = new HashSet<Material>();
        public virtual ICollection<Tag> DefaultTags { get; set; } = new HashSet<Tag>();

        public virtual ICollection<Color> DefaultColors { get; set; } = new HashSet<Color>();

        [ForeignKey(nameof(Subcategory))]
        [Required]
        public int SubcategoryId { get; set; }

        [Required]
        public Subcategory Subcategory { get; set; } = null!;

    }
}
