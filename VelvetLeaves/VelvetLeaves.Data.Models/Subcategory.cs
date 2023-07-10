using System.ComponentModel.DataAnnotations;
using static VelvetLeaves.Common.ValidationConstants.Category;

namespace VelvetLeaves.Data.Models
{
    public class Subcategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public virtual Category Category { get; set; } = null!;


        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();

    }
}
