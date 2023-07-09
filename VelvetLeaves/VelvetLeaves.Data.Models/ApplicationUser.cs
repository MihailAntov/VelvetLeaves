using Microsoft.AspNetCore.Identity;


namespace VelvetLeaves.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        public virtual ICollection<Product>? Favorites { get; set; }

        public virtual ICollection<Address>? Addresses { get; set; }
    }
}
