

namespace VelvetLeaves.ViewModels.User
{
    public class UserPromoteViewModel
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserId { get; set; } = null!;

        public bool IsAdmin { get; set; }
        public bool IsModerator { get; set; }


    }
}
