

namespace VelvetLeaves.Service.Models.ShoppingCart
{
    public class ShoppingCart
    {
        public IList<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
        
    }
}
