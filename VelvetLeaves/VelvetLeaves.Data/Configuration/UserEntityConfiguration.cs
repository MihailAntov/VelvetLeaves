

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data.Models;

namespace VelvetLeaves.Data.Configuration
{
    public static class UserEntityConfiguration
    {
        
        public static void SeedUsers(this ModelBuilder builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            var user = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "user@vls.com",
                NormalizedUserName = "USER@VLS.COM",
                Email = "user@vls.com",
                NormalizedEmail = "USER@VLS.COM",
            };
            user.PasswordHash = hasher.HashPassword(user, "123456");

            var moderator = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "moderator@vls.com",
                NormalizedUserName = "MODERATOR@VLS.COM",
                Email = "moderator@vls.com",
                NormalizedEmail = "MODERATOR@VLS.COM",
            };
            moderator.PasswordHash = hasher.HashPassword(moderator, "123456");

            var admin = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin@vls.com",
                NormalizedUserName = "ADMIN@VLS.COM",
                Email = "admin@vls.com",
                NormalizedEmail = "ADMIN@VLS.COM",
            };
            admin.PasswordHash = hasher.HashPassword(admin, "123456");

            

            builder.Entity<ApplicationUser>()
                .HasMany(u=> u.Addresses)
                .WithOne(a=> a.User)
                .HasForeignKey(a=>a.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<ApplicationUser>()
                .HasData(new List<ApplicationUser> { user, moderator, admin });
        }
    }
}
