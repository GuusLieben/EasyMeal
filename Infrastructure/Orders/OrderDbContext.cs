using EasyMeal.Core.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EasyMeal.Infrastructure.Orders
{
    public class OrderDbContext : IdentityDbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Client>().Property(c => c.DietRestrictions).HasConversion(r => JsonConvert.SerializeObject(r), r => JsonConvert.DeserializeObject<List<string>>(r));

            Client client = new Client().Insert("Guus", "Lieben", "g.lieben@avans.nl", "+31612345678", "Breda", "Lovensdijkstraat", 16, "A", DateTime.Parse("1/1/2019"), new List<string>(), new List<ClientOrder>());
            client.Id = "-1";


            modelBuilder.Entity<Client>().HasData(client);
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientOrder> Orders { get; set; }
    }
}
