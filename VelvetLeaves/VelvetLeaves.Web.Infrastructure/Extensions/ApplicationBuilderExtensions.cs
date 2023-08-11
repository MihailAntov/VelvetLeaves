

using Ganss.Xss;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using VelvetLeaves.Data.Models;
using VelvetLeaves.Data.ObjectDatabase;
using VelvetLeaves.Data.ObjectDatabase.Contracts;
using VelvetLeaves.Services;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.Web.Infrastructure.Services;
using VelvetLeaves.Web.Infrastructure.Services.Contracts;
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
                var role = new IdentityRole
                {
                    Name = AdminRoleName,
                };

                if (!await roleManager.RoleExistsAsync(AdminRoleName))
                {
                    await roleManager.CreateAsync(role);
                }


                var admin = await userManager.FindByEmailAsync(AdminEmail);

                await userManager.AddToRoleAsync(admin, role.Name);
            }).GetAwaiter()
            .GetResult();



            return app;
        }

        public static IApplicationBuilder SeedAppPreferences(this IApplicationBuilder app)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();
            var services = scopedServices.ServiceProvider;
            IOptions<ObjectDatabaseSettings> objectDatabaseSettings = services.GetRequiredService<IOptions<ObjectDatabaseSettings>>();

            var mongoClient = new MongoClient(
            objectDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                objectDatabaseSettings.Value.DatabaseName);

            var _preferences = mongoDatabase.GetCollection<AppPreferences>(
                objectDatabaseSettings.Value.AppPreferencesCollectionName);

            var exists = _preferences.Find(i => i.Id == PreferencesKey).Any();

            if (exists)
            {
                return app;
            }

            AppPreferences preferences = new AppPreferences
            {
                Id = PreferencesKey,
                RootNavigationName = "Velvet Leaves",
                Currency = "лв.",
                BackGroundImageId = "64d55f3aa5226d52bc63e361",
                FavoriteColor = "pink",
                FavoriteIcon = "heart",
                Description = "Бижута от естествени копринени пашкули"
            };

            _preferences.InsertOne(preferences);



            return app;
        }

        public static  IApplicationBuilder SeedImages(this IApplicationBuilder app)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();
            var services = scopedServices.ServiceProvider;
            IImageService imageService = services.GetRequiredService<IImageService>();
            IHostingEnvironment hostingEnvironment = services.GetRequiredService<IHostingEnvironment>();

            Dictionary<string, string> imagesToSeed = new Dictionary<string, string>
            {
                            //background
                            {"64d55f3aa5226d52bc63e361","000/bg.jpg" },

                //Текстил
                    //чанти
                        //ленена чанта
                            //слънце
                            {"64d52335b30136c5a68bb051","001/1.jpg" },
                            {"64d52338464ff67d85ff46a5","001/8.jpg" },
                            {"64d5233c720097ef9dffa9ab","001/9.jpg" },
                            {"64d523401c23834259ea6b65","001/17.jpg" },
                            {"64d52343c1a58e96abb5c206","001/20.jpg" },
                            //синева
                            {"64d523475af695148db6b205","002/1.jpg" },
                            {"64d52349d406df65ce4b4e72","002/2.jpg" },
                            {"64d5234ce3785f17243b411c","002/5.jpg" },
                            {"64d5234f5a69fa9f747e5f18","002/9.jpg" },
                    //несесери
                        //ленен несесер
                            //ленен несесер
                            {"64d5235287a0f3693212c2a1","003/1.jpg" },
                            {"64d523565b62f7aaf0663a98","003/2.jpg" },
                            {"64d52359322458a957d81660","003/4.jpg" },
                            {"64d5235bf6729604d509bc8a","003/8.jpg" },
                            //ленен несесер
                            {"64d5235f274fb0fcf347d1b3","004/1.jpg" },
                            {"64d52362ecdfe6871993e1e4","004/2.jpg" },
                            {"64d52366fb8d548ef1e6a1cb","004/5.jpg" },
                            {"64d5236abb6d8a6883aea6a5","004/8.jpg" },
                    //подвързии
                        //ленена подвързия
                            //ленена подвързия за книга
                            {"64d5236e334387ef86d99937","005/1.jpg" },
                            {"64d52372fe1c9b730442e805","005/3.jpg" },
                            {"64d523760ebe3629aa66effc","005/5.jpg" },
                            {"64d5237b623df2b2ac3fc610","005/6.jpg" },
                            //ленена подвързия за Kindle
                            {"64d5237ebfa052d5f7b7e3cb","006/1.jpg" },
                            {"64d52381a7064dcc1dd461d5","006/2.jpg" },
                            {"64d52385751a53bf32894fb4","006/5.jpg" },
                            {"64d5238841449e1eef8fc29a","006/6.jpg" },
                //Бижута
                    //обеци
                        //3ка до ухо
                            //червени
                            {"64d5238d2acacb9e2043c933","007/1.jpg" },
                            {"64d52392f6a5f8843a780460","007/3.jpg" },
                            {"64d523961f6d033d54da856e","007/4.jpg" },
                            //жълти
                            {"64d5239a46383aa6559ff15e","008/1.jpg" },
                            {"64d5239dfb4154fc78c1b5f2","008/3.jpg" },
                            {"64d523a091c723288ab2703f","008/6.jpg" },
                        //гроздове
                            //шампанско
                            {"64d523a27541d354f5185ecf","009/1.jpg" },
                            {"64d523a54482b6933b4b9641","009/2.jpg" },
                            {"64d523a8417674952ae911aa","009/3.jpg" },
                            //сини
                            {"64d523ac76b19d54b131024b","010/1.jpg" },
                            {"64d523af7736cd67efd18bca","010/2.jpg" },
                            {"64d523b1a82f8b465badccfe","010/3.jpg" },
                            {"64d523b4aaae78c1fb2e0f19","010/4.jpg" },
                            //лилави
                            {"64d523c837c5cbc84815c6b2","011/1.jpg" },
                            {"64d523cbc940befd0ef0bbea","011/2.jpg" },
                            //жълти
                            {"64d523ceda1ac0b8527ffd26","012/1.jpg" },
                            {"64d523d1c01dda3483251e4c","012/2.jpg" },
                            //розови
                            {"64d523d49319f1ab11955ee0","013/1.jpg" },
                            {"64d523e02eab219eca427579","013/4.jpg" },
                            {"64d523e30dd3878eccd3ea1e","013/6.jpg" },
                            //жълти
                            {"64d523e7d30950cc175d4ee5","014/1.jpg" },
                            {"64d523e985893af2853dbaa4","014/2.jpg" },
                            {"64d523ed880a2cfea4e5a29a","014/5.jpg" },
                        //дълги
                            //зелено
                            {"64d523f115f347b097321f2a","015/1.jpg" },
                            {"64d523f45251d2a11816195f","015/2.jpg" },
                            {"64d523f7a6a8571b3eb12359","015/3.jpg" },
                            //сакура
                            {"64d523fabe152a47636bae7d","016/1.jpg" },
                            {"64d523fdeb4444d63ab86a55","016/2.jpg" },
                            {"64d523ff4215c2646cc8163e","016/3.jpg" },
                        //на синджир
                            //червени
                            {"64d524022c22a7bf5d6fb592","017/2.jpg" },
                            {"64d52405dd648aaccb6de56f","017/5.jpg" },
                            {"64d524084074dd02c95d5612","017/6.jpg" },
                            //бронз
                            {"64d5240c0d0a9f46840215f4","018/2.jpg" },
                            {"64d5240f1f6a4bf88ff5fe28","018/5.jpg" },
                            {"64d52413ca2cdb86d5dc5061","018/6.jpg" },
                        //тромбон
                            //тромбон
                            {"64d5241605cdc65069fb4e7c","019/1.jpg" },
                            {"64d524194292962f1698b35d","019/2.jpg" },
                            {"64d5241b4efab879d2b98106","019/3.jpg" },
                            {"64d5241ec70acdc88d85b2cf","019/4.jpg" },
                    //колиета
                        //гроздове
                            //жълто
                            {"64d52421cfb2a66f5536dbc6","020/1.jpg" },
                            {"64d5242462bf6e246eef6de5","020/2.jpg" },
                            {"64d5242760c55c37a36657d8","020/5.jpg" },
                            //розово
                            {"64d5242b9278a4b37dcc630b","021/1.jpg" },
                            {"64d5242e5935e047dede6793","021/4.jpg" },
                            {"64d524315e7d9e628e279e40","021/6.jpg" },
                        //на обръч
                            //червен
                            {"64d52434e25395fb8679db94","022/1.jpg" },
                            {"64d5243d1a39817b5412e11d","022/2.jpg" },
                            {"64d524415910ab1c2728156e","022/3.jpg" },
                            //зелен
                            {"64d524457ff5157cd75d74b1","023/1.jpg" },
                            {"64d52448f4eb7a0a7f25a51a","023/2.jpg" },
                            {"64d5244a9e32fb59f283d635","023/3.jpg" },
                        //сребро
                            //сребърно колие
                            {"64d5244e355f07301da86f9d","024/1.jpg" },
                            {"64d524501bda417d5761bfca","024/2.jpg" },
                            {"64d5245377429792e179d3bf","024/3.jpg" },
                            {"64d52455958cb65afbfd6ae8","024/4.jpg" },
                            //сребърно колие
                            {"64d5245b5f00130edb99f651","025/2.jpg" },
                            {"64d5245e9b617cd236346b63","025/3.jpg" },
                            {"64d52461873681ea5d64d875","025/4.jpg" },
                            {"64d52464dac819b2d0d9651a","025/5.jpg" },
                        //кожа
                            //зелено
                            {"64d52468d463b9450c90da10","026/1.jpg" },
                            {"64d5246c78ebed5232e6790b","026/2.jpg" },
                            //червено
                            {"64d5246f1c85d65d8278ed46","027/1.jpg" },
                            {"64d52471ba01308173853a57","027/2.jpg" },
                            //колие на кожа с цветя
                            {"64d524758723c98b4517d0e4","028/1.jpg" },
                            {"64d52477d20e0caee58a1b13","028/2.jpg" },
                        //велур
                            //лилаво
                            {"64d52479338c4bae74412ae2","029/1.jpg" },
                            {"64d5247d00dfdad417f95d9a","029/2.jpg" },
                            {"64d5247fce219f6b15944ce6","029/3.jpg" },
                            //синьо-лилаво
                            {"64d5249591db48402680da4f","030/1.jpg" },
                            {"64d524983f05edf1b19fbfcf","030/2.jpg" },
                            {"64d5249cf2a4faf6783dcba7","030/3.jpg" },
                            //оранжево
                            {"64d5249fbd5f98393548eaf3","031/1.jpg" },
                            {"64d524a14f2def8ce5fe2053","031/2.jpg" },
                            {"64d524a4d08826759b124b81","031/3.jpg" },
                            //тюркоаз
                            {"64d52481af9cd319228bc03e","032/1.jpg" },
                            {"64d524848355e8e0ca5c7c64","032/2.jpg" },
                            //черно-бяло
                            {"64d524894f0d449e6e7f0be5","033/1.jpg" },
                            {"64d5248ef11f97cf0d936c79","033/2.jpg" },
                            {"64d52490c7197f5948d686e0","033/3.jpg" },
                        //въже
                            //жълто-синьо
                            {"64d524a8a106e8030a0f5810","034/1.jpg" },
                            {"64d524ace356ce0f5b5e84c6","034/2.jpg" },
                            {"64d524b05db296b5147b774a","034/3.jpg" },
                            {"64d524b586fa7d40023defa1","034/4.jpg" },
                            //пролет
                            {"64d524b9579b4b54285e15ed","035/1.jpg" },
                            {"64d524bc9c0bf598bdbe9551","035/2.jpg" },
                            {"64d524bf2b882738a30506c5","035/3.jpg" },
                        //стомана
                            //листо
                            {"64d524c23a6c7f3087010b63","036/1.jpg" },
                            {"64d524c58d113c6f7108c444","036/2.jpg" },
                            {"64d524c8d973ed6ecd116daf","036/3.jpg" },
                    //гривни
                        //сребро
                            //розова
                            {"64d524cb8237c4c8cab1c94d","037/1694.jpg" },
                            //жълта
                            {"64d524ce181e34c33340dd05","038/1697.jpg" },
                        //кожа
                            //зелена
                            {"64d524d23b4f7df4df352f9f","039/1.jpg" },
                            {"64d524d540e46b0cea6cc523","039/2.jpg" },
                            {"64d524d99bb7990b020777b9","039/3.jpg" },
                            {"64d524db4c9f4a9647db7009","039/4.jpg" },
                            //синьо-жълта 
                            {"64d524de44d6b9ac55e41954","040/1.jpg" },
                            {"64d524e1def6a193ed8df8f6","040/2.jpg" },
                            {"64d524e404b5bd7f13be1c5b","040/3.jpg" },
                            {"64d524e80992abcef8352a65","040/4.jpg" },
                            {"64d524ebc6f3675710bbd9dd","040/5.jpg" },
                    //пръстени
                        //сребро
                            //бял
                            {"64d524fa4584a8013259e40d","041/1.jpg" },
                            {"64d52504405b952082fb05d1","041/2.jpg" },
                            {"64d52507173da7d7420d2657","041/3.jpg" },
                            {"64d5250a13661437bd07c952","041/4.jpg" },
                            //син
                            {"64d5250e6b4ba5e401ed0500","042/1.jpg" },
                            {"64d52512e2aa2cc2c81f5b6e","042/2.jpg" },
                            {"64d52515302802a83f0af2e0","042/3.jpg" },
                        //стомана
                            //мак
                            {"64d5251be13c2530fda92d19","043/1.jpg" },
                            {"64d5251e9c3ab859c753c597","043/2.jpg" },
                            {"64d52521e58195d2403b6e15","043/3.jpg" },
                            //жълт
                            {"64d5252751ecfe48e09e1f15","044/1.jpg" },
                            {"64d5252abf960bb7827bb75b","044/2.jpg" },
                            {"64d5252d8c5ead2168fbd1cb","044/3.jpg" },
                            {"64d525319813433aa6afe1ac","044/4.jpg" }

                
                            
            };

            foreach (KeyValuePair<string, string> image in imagesToSeed)
            {


                Task.Run(async () =>
                {
                    string[] args = image.Value.Split('/');
                    if(!await imageService.ExistsByIdAsync(image.Key))
                    {                    
                    string imgFolderNumber = args[0];
                    string imgName = args[1];
                    string path = Path.Combine(hostingEnvironment.WebRootPath, "seed",imgFolderNumber, imgName);
                    byte[] bytes = await File.ReadAllBytesAsync(path);
                    string content = Convert.ToBase64String(bytes);
                    await imageService.CreateFromStringAsync(image.Key, content);
                    }


                }).GetAwaiter()
                .GetResult();
            }

            

            return app;
        }


        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {


            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IGalleryService, GalleryService>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IColorService, ColorService>();
            services.AddSingleton<IObjectDbContext, ObjectDbContext>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<ISubcategoryService, SubcategoryService>();
            services.AddScoped<IProductSeriesService, ProductSeriesService>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IHelperService, HelperService>();
            services.AddScoped<IFavoriteService, FavoriteService>();
            services.AddScoped<IHtmlSanitizer, HtmlSanitizer>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
