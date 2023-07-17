using static VelvetLeaves.Common.ValidationConstants.Color;

using System.ComponentModel.DataAnnotations;

namespace VelvetLeaves.Data.Models
{
    public class Color
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ColorNameMaxLenth)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(ColorLength)]
        public string ColorValue { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
