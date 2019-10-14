using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService_Meals.Models
{
    public class CreateMealModel
    {
        public DateTime DateValid { get; set; }

        public int StarterId { get; set; }
        public int MainId { get; set; }
        public int DessertId { get; set; }
    }
}
