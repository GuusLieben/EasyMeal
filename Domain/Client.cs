using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Client : IActor
    {
        public int ClientId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string Addition { get; set; }
        public DateTime BirthDate { get; set; }
        public DietRestrictions[] DietRestrictions { get; set; }
        public IEnumerable<Menu> OrderHistory { get; set; }
    }
}
