

using VelvetLeaves.Common.Enums;

namespace VelvetLeaves.ViewModels.Order
{
	public class OrderListViewModel
	{
		public IEnumerable<OrderProductListViewModel> Products { get; set; } = new HashSet<OrderProductListViewModel>();
		

		public DateTime Date { get; set; }
		public decimal Total { get; set; }

		public OrderStatus Status { get; set; } 
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Country { get; set; }
		public string City { get; set; }
		public string StreetAddress { get; set; } = null!; 
		public string? ZipCode { get; set; }

		public string PhoneNumber { get; set; } = null!;



	}
}
