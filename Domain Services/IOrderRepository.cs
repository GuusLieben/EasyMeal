using System.Collections.Generic;

namespace EasyMeal.Core.Domain.Services
{
    public interface IOrderRepository
    {
        void AddOrder(ClientOrder co);

        IEnumerable<ClientOrder> GetOrdersForClient(string clientId);

        Client GetClient(string email);

        IEnumerable<ClientOrder> GetOrdersForClientForMonth(string clientId, int month, int year);
        void CancelOrder(ClientOrder co);
    }
}
