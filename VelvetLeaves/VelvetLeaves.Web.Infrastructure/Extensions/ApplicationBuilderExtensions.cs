

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using VelvetLeaves.Data.Models;
using static VelvetLeaves.Common.ApplicationConstants;

namespace VelvetLeaves.Web.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedAdmin(this IApplicationBuilder app)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            var services = scopedServices.ServiceProvider;
            UserManager<ApplicationUser> userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole> roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task.Run(async () =>
            {
                if(await roleManager.RoleExistsAsync(AdminRoleName))
                {
                    return;
                }
                var role = new IdentityRole
                {
                    Name = AdminRoleName,
                };
                await roleManager.CreateAsync(role);

                var admin = await userManager.FindByEmailAsync(AdminEmail);

                await userManager.AddToRoleAsync(admin, role.Name);
            }).GetAwaiter()
            .GetResult();



            return app;
        }
    }
}
