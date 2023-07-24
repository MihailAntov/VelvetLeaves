

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using VelvetLeaves.Data.Models;
using VelvetLeaves.Services.Contracts;
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
                if (await roleManager.RoleExistsAsync(AdminRoleName))
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

        public static IApplicationBuilder SeedImages(this IApplicationBuilder app)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();
            var services = scopedServices.ServiceProvider;
            IImageService imageService = services.GetRequiredService<IImageService>();
            IHostingEnvironment hostingEnvironment = services.GetRequiredService<IHostingEnvironment>();

            Dictionary<string, string> imagesToSeed = new Dictionary<string, string>
            {
                {"64be89ae1409e5a61554e6ed","redsilver.jpg" },
                {"64be8c68cac3fdf11a06fbbb","redsilver.jpg" },
                {"64be8c6df878c3764a814981","redsilver.jpg" },
                {"64be8c733df251037e15d70a","redbluesteel.jpg" },
                {"64be8c7a0ef21ca57c247498","redbluesteel.jpg" },
                {"64be8c813d909293463359d6","redbluesteel.jpg" },
                {"64be8c870b7f086367ebb6a5","greensilvernecklace.jpg" },
                {"64be8c8d7d5c466b820b73af","greensilvernecklace.jpg" },
                {"64be8c9332b088f8d6063040","blueglass.jpg" },
                {"64be8c99f991d074063b5098","blueglass.jpg" },
                {"64be8c9f41c19cda7ab19853","handbag.jpg" },
                {"64be8ca5b7f1ea12383c364a","handbag.jpg" },
                {"64be8caa293917f47210277e","handbag2.jpg" },
                {"64be8cae1813d7aff61e173b","handbag2.jpg" },
                {"64be8cb3b390e17c62039322","book.jpg" },
                {"64be8cb81a39dd6ed0351ebb","book.jpg" },
            };

            foreach (KeyValuePair<string, string> image in imagesToSeed)
            {


                Task.Run(async () =>
                {
                    
                        string path = Path.Combine(hostingEnvironment.WebRootPath, "seed", image.Value);
                        byte[] bytes = await File.ReadAllBytesAsync(path);
                        string content = Convert.ToBase64String(bytes);




                        await imageService.CreateFromStringAsync(image.Key, content);
                    
                    
                }).GetAwaiter()
                .GetResult();
            }



            return app;
        }
    }
}
