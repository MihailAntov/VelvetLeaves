using Microsoft.AspNetCore.Identity;


namespace VelvetLeaves.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        public virtual ICollection<Product> Favorites { get; set; } = new HashSet<Product>();

        public virtual ICollection<Address> Addresses { get; set; } = new HashSet<Address>();

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
