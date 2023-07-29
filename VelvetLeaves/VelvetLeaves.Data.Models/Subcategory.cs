using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static VelvetLeaves.Common.ValidationConstants.Category;
using static VelvetLeaves.Common.ValidationConstants.Image;


namespace VelvetLeaves.Data.Models
{
    public class Subcategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public virtual Category Category { get; set; } = null!;


        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();

        public virtual ICollection<ProductSeries> ProductSeries { get; set; } = null!;

        [Required]
        [MaxLength(IdMaxLength)]
        public string ImageId { get; set; } = null!;

        public bool IsActive { get; set; } = true;

    }
}
