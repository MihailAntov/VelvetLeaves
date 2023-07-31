

namespace VelvetLeaves.Web.Infrastructure.Models
{
    public class ShoppingCart
    {
        public IEnumerable<ShoppingCartItem> Items { get; set; } = new HashSet<ShoppingCartItem>();
    }
}
