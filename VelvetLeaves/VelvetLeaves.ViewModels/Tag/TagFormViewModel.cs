

using System.ComponentModel.DataAnnotations;
using VelvetLeaves.Common.Validation;
using static VelvetLeaves.Common.ValidationConstants.Tag;

namespace VelvetLeaves.ViewModels.Tag
{
    public class TagFormViewModel
    {
        [Required]
        [SanitizeStringInput]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "Must be between {2} and {1} symbols.")]
        public string Name { get; set; } = null!;
    }
}
