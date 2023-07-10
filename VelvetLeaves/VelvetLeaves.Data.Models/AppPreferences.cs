

using System.ComponentModel.DataAnnotations;

using static VelvetLeaves.Common.ValidationConstants.AppPreferences;

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

        [Required]
        [MaxLength(RootProductsNameMaxLength)]
        public string RootProductsName { get; set; } = null!;
    }
}
