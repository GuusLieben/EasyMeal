using Domain;
using DomainModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Orders
{
    public class OrderDbContext : IdentityDbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Client>().OwnsMany<ClientOrder>(c => c.OrderHistory).HasOne<Client>(o => o.Client);
            modelBuilder.Entity<Client>().Property(c => c.DietRestrictions).HasConversion(r => JsonConvert.SerializeObject(r), r => JsonConvert.DeserializeObject<List<string>>(r));

            Client client = new Client("Breda", "Lovensdijkstraat", 16, "A", DateTime.Parse("1/1/2019"), new List<string>(), new List<ClientOrder>())
            {
                Firstname = "Guus",
                Lastname = "Lieben",
                Id = "-1"
            };
            ClientOrder order = new ClientOrder
            {
                Client = client,
                MealId = -5,
                Date = DateTime.Parse("1/2/2019"),
                Size = DishSize.Medium,
                Id = -10
            };

            modelBuilder.Entity<Client>().HasData(client);
            modelBuilder.Entity<ClientOrder>().HasData(order);
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientOrder> Orders { get; set; }
    }
}
