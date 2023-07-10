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

        [Required]
        [MaxLength(UrlMaxLength)]
        public string ImageUrl { get; set; } = null!;
    }
}
