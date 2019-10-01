using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface Invoice
    {
        IClient Client { get; set; }
        Meal Meal { get; set; }
        DateTime Date { get; set; }
    }
}
