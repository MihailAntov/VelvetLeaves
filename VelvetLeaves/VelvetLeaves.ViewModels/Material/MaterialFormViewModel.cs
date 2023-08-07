
using System.ComponentModel.DataAnnotations;
using VelvetLeaves.Common.Validation;
using static VelvetLeaves.Common.ValidationConstants.Material;

namespace VelvetLeaves.ViewModels.Material
{
    public class MaterialFormViewModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "Must be between {2} and {1} symbols.")]
        [SanitizeStringInput]
        public string Name { get; set; } = null!;
    }
}
