

using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace VelvetLeaves.ViewModels.User
{
    public class LoginFormViewModel
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

      
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }


        
    }
}
