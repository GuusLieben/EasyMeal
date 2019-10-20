using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EasyMeal.Core.Domain.Services;
using EasyMeal.Infrastructure.Orders;
using EasyMeal.Infrastructure.Meals;
using EasyMeal.Core.Domain;

namespace EasyMeal.Web.Orders
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<OrderDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("OrderDbConnection"), b => b.MigrationsAssembly("Infrastructure"));
            });

            services.AddDbContext<MealDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MealDbConnection"), b => b.MigrationsAssembly("Infrastructure"));
            });

            services.AddDefaultIdentity<Client>()
                .AddEntityFrameworkStores<OrderDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<IOrderRepository, EFOrderRepository>();
            services.AddScoped<IReadOnlyRepository, EFReadOnlyRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Public}/{action=Index}/{id?}");
            });

            Infrastructure.Orders.IdentitySeedData.EnsurePopulated(app);
            UserManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<Client>>();
            SignInManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<SignInManager<Client>>();
        }

        public static UserManager<Client> UserManager { get; set; }
        public static SignInManager<Client> SignInManager { get; set; }
    }
}
