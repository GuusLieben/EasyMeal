using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModels
{
    public class ClientOrder
    {
        [Key]
        public int Id { get; set; }

        public Client Client { get; set; }
        public int MealId { get; set; }
        public DateTime Date { get; set; }
        public DishSize Size { get; set; }
    }
}
