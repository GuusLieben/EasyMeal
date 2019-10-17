using EasyMeal.Core.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace EasyMeal.Infrastructure.Meals
{
    public static class IdentitySeedData
    {
        private const string adminUser = "Guus";
        private const string adminPassword = "Secret123$";
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            //UserManager<IdentityUser> userManager = app.ApplicationServices
            //.GetRequiredService<UserManager<IdentityUser>>();

            using (IServiceScope scope = app.ApplicationServices.CreateScope())
            {
                UserManager<Cook> userManager = scope.ServiceProvider.GetRequiredService<UserManager<Cook>>();
                Cook user = await userManager.FindByNameAsync(adminUser);
                if (user == null)
                {
                    user = new Cook(adminUser, "Beheerder", "guus@avans.nl", "0612345678");
                    await userManager.CreateAsync(user, adminPassword);
                }
            }
        }
    }
}
