

using System.ComponentModel.DataAnnotations;
using static VelvetLeaves.Common.ValidationConstants.Category;

namespace VelvetLeaves.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Subcategory> Subcategories { get; set; } = new HashSet<Subcategory>();
    }
}
