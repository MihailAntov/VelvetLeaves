

using System.ComponentModel.DataAnnotations;

namespace VelvetLeaves.Data.Models
{
    public class Color
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string ColorValue { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
