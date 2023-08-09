using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data;
using VelvetLeaves.Data.Models;
using VelvetLeaves.App;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.Services;
using VelvetLeaves.Web.Infrastructure.Extensions;
using VelvetLeaves.Data.ObjectDatabase;
using VelvetLeaves.Web.Infrastructure.Services;
using VelvetLeaves.Web.Infrastructure.Services.Contracts;
using VelvetLeaves.Web.Infrastructure.Filters;
using Ganss.Xss;
using VelvetLeaves.Data.ObjectDatabase.Contracts;
using VelvetLeaves.App.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<VelvetLeavesDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.Configure<ObjectDatabaseSettings>(
    builder.Configuration.GetSection("ObjectDatabase"));

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
    options.LogoutPath = "/Home/Index";
});

builder.Services.AddControllersWithViews(options=>
{
    options.Filters.Add<LoggingActionFilter>();
    //options.Filters.Add<ImageResourceFilter>();
    //options.Filters.Add<StringResourceFilter>();

});
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<IGalleryService, GalleryService>();
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IColorService, ColorService>();
builder.Services.AddSingleton<IObjectDbContext, ObjectDbContext>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<ISubcategoryService, SubcategoryService>();
builder.Services.AddScoped<IProductSeriesService, ProductSeriesService>();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IHelperService, HelperService>();
builder.Services.AddScoped<IFavoriteService, FavoriteService>();
builder.Services.AddScoped<IHtmlSanitizer, HtmlSanitizer>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddSignalR();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.SeedAdmin();

//Uncomment this to seed initial images and preferences
//app.SeedImages();
app.SeedAppPreferences();



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
app.UseSession();

app.MapControllerRoute(
    name:"admin",
    pattern: "{area:exists}/{controller=Products}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.MapHub<OrderTrackerHub>("/OrderUpdate");

app.Run();
