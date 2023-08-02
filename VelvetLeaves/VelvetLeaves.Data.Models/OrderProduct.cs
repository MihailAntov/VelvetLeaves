
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VelvetLeaves.Data.Models
{
	public class OrderProduct
	{
		[Required]
		[ForeignKey(nameof(Order))]
		public string OrderId { get; set; } = null!;

		[Required]
		public virtual Order Order { get; set; } = null!;


		[Required]
		[ForeignKey(nameof(Product))]
		public int ProductId { get; set; }

		[Required]
		public virtual Product Product { get; set; } = null!;

		public int Quantity { get; set; }
	}

}
