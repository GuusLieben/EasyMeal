using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IActor
    {
        string Firstname { get; set; }
        string Lastname { get; set; }
        string Email { get; set; }
        string Phonenumber { get; set; }
        string Password { get; set; }
    }
}
