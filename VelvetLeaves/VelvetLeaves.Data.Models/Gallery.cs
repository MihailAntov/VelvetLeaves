

using System.ComponentModel.DataAnnotations;

using static VelvetLeaves.Common.ValidationConstants.Gallery;
using static VelvetLeaves.Common.ValidationConstants.Image;

namespace VelvetLeaves.Data.Models
{
    public class Gallery 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public ICollection<GalleryProduct> GalleriesProducts { get; set; } = new HashSet<GalleryProduct>();

        [Required]
        [MaxLength(IdMaxLength)]
        public string ImageId { get; set; } = null!;
    }
}
