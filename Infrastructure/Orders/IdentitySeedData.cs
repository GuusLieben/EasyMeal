using EasyMeal.Core.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EasyMeal.Infrastructure.Orders
{
    public static class IdentitySeedData
    {
        private const string user = "Guus";
        private const string userPassword = "Secret123$";
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            //UserManager<IdentityUser> userManager = app.ApplicationServices
            //.GetRequiredService<UserManager<IdentityUser>>();

            using (IServiceScope scope = app.ApplicationServices.CreateScope())
            {
                UserManager<Client> userManager = scope.ServiceProvider.GetRequiredService<UserManager<Client>>();
                Client client = await userManager.FindByNameAsync(user);
                if (client == null)
                {
                    // public Client(string firstname, string lastname, string email, string phonenumber, string city, string street, int houseNumber, string addition, DateTime birthDate)
                    client = new Client(user, "Lieben", "guus@avans.nl", "0612345678", "Breda", "Lovensdijkstraat", 16, "A", DateTime.Parse("23/7/2019"));
                    await userManager.CreateAsync(client, userPassword);
                }
            }
        }
    }
}
