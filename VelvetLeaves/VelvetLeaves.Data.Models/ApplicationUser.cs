using Microsoft.AspNetCore.Identity;


namespace VelvetLeaves.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        public virtual ICollection<Product>? Favorites { get; set; } 
    }
}
