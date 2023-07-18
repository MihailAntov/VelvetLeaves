﻿using static VelvetLeaves.Common.ValidationConstants.Material;

using System.ComponentModel.DataAnnotations;

namespace VelvetLeaves.Data.Models
{
    public class Material
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;


        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();    
    }
}