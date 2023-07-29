using static VelvetLeaves.Common.ValidationConstants.Material;

using System.ComponentModel.DataAnnotations;

namespace VelvetLeaves.Data.Models
{
    public class Material
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;


        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();    

        public virtual ICollection<ProductSeries> ProductSeries { get; set; } = new HashSet<ProductSeries>();

        public bool IsActive { get; set; } = true;
    }
}
