

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data.Models;

namespace VelvetLeaves.Data.Seeding
{
    public static class AdminSeeder
    {
        public static void SeedAdmin(this ModelBuilder builder, string? email, string? password)
        {
            if(email == null)
            {
                throw new ArgumentNullException(nameof(email));
            }

            if(password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }
            
            var hasher = new PasswordHasher<ApplicationUser>();

            var admin = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = email,
                NormalizedUserName = email.ToUpper(),
                Email = email,
                NormalizedEmail = email.ToUpper(),
            };
            admin.PasswordHash = hasher.HashPassword(admin, password);

            builder.Entity<ApplicationUser>()
                .HasData(new List<ApplicationUser> { admin });
        }
    }
}
