

using VelvetLeaves.Common.Enums;

namespace VelvetLeaves.ViewModels.Order
{
	public class OrderProcessViewModel
	{
		public IEnumerable<OrderProductListViewModel> Products { get; set; } = new HashSet<OrderProductListViewModel>();
		public string Id { get; set; } = null!;

		public string Date { get; set; } = null!;
		public decimal Total { get; set; }

		public OrderStatus Status { get; set; }
		public string Recipient { get; set; } = null!;
		public string Address { get; set; } = null!;
		public string? ZipCode { get; set; }

		public string PhoneNumber { get; set; } = null!;
	}
}
