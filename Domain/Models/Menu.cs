using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface Menu
    {
        IEnumerable<Meal> Meals { get; set; }
    }
}
