using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IClient : IActor
    {
        int ClientId { get; set; }
        string City { get; set; }
        string Street { get; set; }
        int HouseNumber { get; set; }
        string Addition { get; set; }
        DateTime BirthDate { get; set; }
        DietRestrictions[] DietRestrictions { get; set; }
        IEnumerable<Order> OpenOrders { get; set; }
        IEnumerable<Order> OrderHistory { get; set; }
    }
}
