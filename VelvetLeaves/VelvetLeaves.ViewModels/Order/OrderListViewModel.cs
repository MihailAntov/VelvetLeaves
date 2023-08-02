

namespace VelvetLeaves.ViewModels.Order
{
	public class OrderListViewModel
	{
		public IEnumerable<OrderProductListViewModel> Products { get; set; } = new HashSet<OrderProductListViewModel>();

		public string Date { get; set; } = null!;
		public decimal Total { get; set; }

		public string Status { get; set; } = null!;
		public string Recipient { get; set; } = null!; 
		public string Address { get; set; } = null!; 
		public string? ZipCode { get; set; }

		public string PhoneNumber { get; set; } = null!;


	}
}
