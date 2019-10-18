using EasyMeal.Core.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace EasyMeal.Infrastructure.Orders
{
    public static class IdentitySeedData
    {
        private const string user = "Henk";
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
                    client = new Client().Insert(user, "Lieben", "henk@avans.nl", "+31612345678", "Breda", "Lovensdijkstraat", 16, "A", DateTime.Parse("1/1/2019"), new List<string>(), new List<ClientOrder>());
                    await userManager.CreateAsync(client, userPassword);
                }
            }
        }
    }
}
