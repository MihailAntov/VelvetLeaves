

using System.ComponentModel.DataAnnotations;
using VelvetLeaves.Common.Validation;
using static VelvetLeaves.Common.ValidationConstants.Color;

namespace VelvetLeaves.ViewModels.Colors
{
    public class ColorFormViewModel
    {
        [Required]
        [StringLength(ColorNameMaxLenth, MinimumLength = ColorNameMinLength, ErrorMessage = "Must be between {2} and {1} symbols.")]
        [DataType(DataType.Text)]
        [SanitizeStringInput]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(ColorLength, MinimumLength = ColorLength, ErrorMessage = "Must be between {2} and {1} symbols.")]
        [DataType(DataType.Text)]
        [SanitizeStringInput]
        public string Color { get; set; } = null!;
    }
}
