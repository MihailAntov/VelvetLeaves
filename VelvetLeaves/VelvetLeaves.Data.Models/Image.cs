using static VelvetLeaves.Common.ValidationConstants.Image;

using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace VelvetLeaves.Data.Models
{
    public class Image
    {
		[Key]
		[MaxLength(IdMaxLength)]
		public string Id { get; set; } = null!;

		[ForeignKey(nameof(Product))]
		[Required]
		public int ProductId { get; set; }

		[Required]
		public Product Product { get; set; } = null!;



	}
}
