using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelvetLeaves.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(250)]
        public string Description { get; set; } = null!;
        [InverseProperty("Favorites")]
        public virtual ICollection<ApplicationUser>? ApplicationUsers { get; set; }

        

    }
}
