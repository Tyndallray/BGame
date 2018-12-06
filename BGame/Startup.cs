using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using BGame.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BGame.Models.UserModels;
using Microsoft.AspNetCore.Identity;
namespace BGame
{
    public class Startup
    {
        IConfiguration Configuration { get; }

        public Startup(IConfiguration Configuration) => this.Configuration = Configuration;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BGameDbContext>(options => options.UseSqlServer(
                Configuration["ConnectionStrings:DefaultConnection"]));
            
            services.AddTransient<IGameItem, EFGameItemRepository>();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            //user part
           // services.AddTransient<IUserInterface, EFUserRepository>();
            services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlServer(
            Configuration["BGameIdentity:ConnectionString"]));
            services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<AppIdentityDbContext>()
            .AddDefaultTokenProviders();

            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: null, template: "{ controller = Admin}/{ action = Index}/{ id ?}",
                   defaults: new { controller = "Admin", action = "Index" });
                routes.MapRoute(name: null, template: "{ controller = Cart}/{ action = Index}/{ id ?}",
                   defaults: new { controller = "Cart", action = "Index" });
            });
            SeedData.EnsurePopulated(app);
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
