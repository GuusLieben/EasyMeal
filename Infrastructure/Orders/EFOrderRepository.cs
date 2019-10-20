using EasyMeal.Core.Domain;
using EasyMeal.Core.Domain.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyMeal.Infrastructure.Orders
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly OrderDbContext context;

        public EFOrderRepository(OrderDbContext context)
        {
            this.context = context;
        }

        public void AddOrder(ClientOrder co)
        {
            context.Add(co);
            context.Clients.FirstOrDefault(c => c.Id.Equals(co.ClientId)).OrderHistory.Add(co);
            context.SaveChanges();
        }

        public Client GetClient(string email)
        {
            return context.Clients.Where(c => c.Email.Equals(email)).SingleOrDefault();
        }

        public IEnumerable<ClientOrder> GetOrdersForClient(string clientId)
        {
            return context.Orders.Where(co => co.ClientId.Equals(clientId)).ToList();
        }

        public void CancelOrder(int id)
        {
            ClientOrder co = context.Orders.Where(o => o.Id == id).FirstOrDefault();
            CancelOrder(co);
        }

        public void CancelOrder(ClientOrder co)
        {
            context.Remove(co);
            context.SaveChanges();
        }

        public IEnumerable<ClientOrder> GetOrdersForClientForMonth(string clientId, int month, int year)
        {
            var orders = GetOrdersForClient(clientId);
            return orders.Where(co => co.Date.Month == month && co.Date.Year == year).ToList();
        }
    }
}
