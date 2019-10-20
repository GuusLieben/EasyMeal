using System;
using System.ComponentModel.DataAnnotations;

namespace EasyMeal.Core.Domain
{
    public class ClientOrder
    {
        [Key]
        public int Id { get; set; }
        public string ClientId { get; set; }
        public int DishId { get; set; }
        public DateTime Date { get; set; }
        public DishSize Size { get; set; }
    }
}
