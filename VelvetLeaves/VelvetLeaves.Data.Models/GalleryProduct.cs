

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VelvetLeaves.Data.Models
{
    public class GalleryProduct
    {
        [ForeignKey(nameof(Gallery))]
        public int GalleryId { get; set; }

        [Required]
        public Gallery Gallery { get; set; } = null!;


        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        [Required]
        public Product Product { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        //position inside gallery 
        public int Position { get; set; }
    }
}
