using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data;
using VelvetLeaves.Data.Models;
using VelvetLeaves.App;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.Services;
using VelvetLeaves.Web.Infrastructure.Extensions;
using VelvetLeaves.Data.Images;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<VelvetLeavesDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.Configure<ImageDatabaseSettings>(
    builder.Configuration.GetSection("ImageDatabase"));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<VelvetLeavesDbContext>();
    

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;

});

builder.Services.ConfigureExternalCookie(options =>
{
    options.LoginPath = "/User/Login";
    options.LogoutPath = "/Galleries/Featured";
});

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<IGalleryService, GalleryService>();
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IColorService, ColorService>();
builder.Services.AddSingleton<IImageService, ImageService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.SeedAdmin();
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name:"admin",
    pattern: "{area:exists}/{controller=Products}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Galleries}/{action=Featured}/{id?}");
app.MapRazorPages();

app.Run();
