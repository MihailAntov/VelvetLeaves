

namespace VelvetLeaves.ViewModels.Order
{
    public class AllOrderProcessViewModel
    {
        public IEnumerable<OrderProcessViewModel> Orders { get; set; } = new HashSet<OrderProcessViewModel>();
        public string Title { get; set; } = null!;
    }
}
