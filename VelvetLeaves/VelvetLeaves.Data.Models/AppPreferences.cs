

using System.ComponentModel.DataAnnotations;

namespace VelvetLeaves.Data.Models
{
    public class AppPreferences
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string BackgroundUrl { get; set; } = null!;

        [Required]
        public string FaviconUrl { get; set; } = null!;
    }
}
