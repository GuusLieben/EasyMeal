using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface Order
    {
        Meal Meal { get; set; }
        DateTime Date { get; set; }
    }
}
