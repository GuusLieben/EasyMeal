using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public abstract class IActor
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string Password { get; set; }
    }
}
